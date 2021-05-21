using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    private static GameMaster instance;
    public static GameMaster Instance{  //GameMaster.Instance.ほしいもの
        get{
        if(instance == null){
            instance = (GameMaster)FindObjectOfType(typeof(GameMaster));
        }
        return instance;
        }
    }
    public Player player;      
    public Deck deck;           
    public DeckCardList deckcardlist;   //デッキのカード（表示のみ
    public Hand hand;          
    public Enemy enemy;         
    public EnemyDeck enemydeck;  
    public EnemyHand enemyhand;
    public SetButton setbutton;
    public Card cardPrefab;
    public EnemyCard enemycardPrefab;
    public List<Card> battlecardList = new List<Card>();    //カードを選択した枚数
    public List<EnemyCard> EnemybattlecardList = new List<EnemyCard>(); //上と同じだが、順番も兼ねる
    //プレイヤーのデッキの場所を示す
    public int turn = 0;
    [SerializeField] Transform playerDeckTransform;
    [SerializeField] Transform playerHandTransform;
    [SerializeField] Transform enemyDeckTransform;
    [SerializeField] Transform enemyHandTransform;
    //カードを示す
    public enum CardID{     //定義する
        SLASH,
        GUARD,
        DODGE,
        CardCount   //カードの種類の最大値
    };
    public enum CharacterID{
        PLAYER,
        ENEMY,
    };
    enum Phase{
        INIT,
        DRAW,
        SELECT,
        BATTLE,
        END,
    };
    Phase phase;
    void Start () {
        phase = Phase.INIT;
    }   
    void Update () {
        switch(phase){
            case Phase.INIT:
            InitPhase();
            break;
            case Phase.DRAW:
            DrawPhase();
            break;
            case Phase.SELECT:
            SelectPhase();
            break;
            case Phase.BATTLE:
            BattlePhase();
            break;
            case Phase.END:
            EndPhase();
            break;
        }       
    }
    void InitPhase(){   //生成フェーズ
        Debug.Log("InitPhase");
        player.Init();
        
        for(int i = 0; i < 10; i++){    //プレイヤーのカード生成
            Card card = Instantiate(cardPrefab,playerDeckTransform,false);  //カードの生成（カードプレハブをプレイヤーデッキへ。座標０）
            int cardID = Random.Range(0,(int)CardID.CardCount);    //カードIDをランダムに生成する（０～カードの種類）
            card.Init(cardID,true);     //カードのInitをする（上で得たカードID,battlecardである(どこでもクリックできないように)）
            deck.Add(card);     //手札に加える(上でInitしたカード)
            deckcardlist.Create(cardID);
        }
        for(int i = 0; i < 10; i++){    //エネミーのカード生成
            EnemyCard enemycard = Instantiate(enemycardPrefab,enemyDeckTransform,false);
            int enemycardID = Random.Range(0,(int)EnemyCard.enemycardID.CardCount);
            enemycard.Init(enemycardID);
            enemydeck.Add(enemycard);
        }
        //card.Init("スラッシュ");
        phase = Phase.DRAW;
    }
    void DrawPhase(){   //カードを引くフェーズ
        Debug.Log("DrawPhase");
        int CardCount = 10;     //Random.Rangeの最大値
        for(int i = 0; i < 5; i++){     //カード５枚引く処理
            Card card = deck.Pull(Random.Range(0,CardCount));   //Random.Range(最小値,最大値)
            EnemyCard enemycard = enemydeck.Pull(Random.Range(0,CardCount));
            CardCount -= 1;     //Random.Rangeの最大値をデッキからカードを抜いた分引く（最大値の修正
            hand.Add(card);     //デッキのカードをハンドに渡す処理
            enemyhand.Add(enemycard);
        }
        phase = Phase.SELECT;
    }
    public void SelectPhase(){      //セレクトフェーズ
        //Debug.Log(battlecardList.Count);
        if(battlecardList.Count == 5){      //battlecardListはカード選択時＋１するよ
            setbutton.SetIventButton();     //battlecardListが５ならセットボタンを生成する
        }else{
            setbutton.CloseSetButton();     //battlecatdListが５でないならセットボタンをしまう
        }
    }
    public void NextPhaseBattle(){      //セットボタンクリックされた
        phase = Phase.BATTLE;
    }
    void BattlePhase(){     //バトルフェーズ
        Debug.Log("BattlePhase");
    for(int turn = 0; turn < 5; turn++){
        Card _card = battlecardList[turn];     //バトルカードリストの０番目を_cardとする
        EnemyCard _enemycard = EnemybattlecardList[turn];
        if(_card.cardSpeed < _enemycard.cardSpeed){     //0が速い 3が遅い
            Debug.Log("プレイヤーのターンから");
        }else{
            Debug.Log("エネミーから");
        }
        battlecardList.Remove(_card);   //バトルカードリストから削除
        EnemybattlecardList.Remove(_enemycard);
    }

    phase = Phase.END;
    }
    void EndPhase(){
        Debug.Log("EndPhase");
        //phase = Phase.DRAW;
    }
}
