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
    public Graveyard graveyard;
    public Enemy enemy;         
    public EnemyDeck enemydeck;  
    public EnemyHand enemyhand;
    public EnemyGraveyard enemygraveyard;
    public SetButton setbutton;
    public Card cardPrefab;
    public List<Card> battlecardList = new List<Card>();    //カードを選択した枚数
    public List<Card> EnemybattlecardList = new List<Card>(); //上と同じだが、順番も兼ねる
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
        E_SLASH,
        E_GUARD,
        E_MAGIC,
        CardCount,   //カードの種類の最大値
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
        enemy.Init();
        
        for(int i = 0; i < 10; i++){    //プレイヤーのカード生成
            Card card = Instantiate(cardPrefab,playerDeckTransform,false);  //カードの生成（カードプレハブをプレイヤーデッキへ。座標０）
            int cardID = Random.Range(0,(int)CardID.E_SLASH);    //カードIDをランダムに生成する（０～カードの種類）
            card.Init(cardID,true,true);     //カードのInitをする（上で得たカードID,battlecardである(どこでもクリックできないように)）
            deck.Add(card);     //手札に加える(上でInitしたカード)
            deckcardlist.Create(cardID);
        }
        for(int i = 0; i < 10; i++){    //エネミーのカード生成
            Card enemycard = Instantiate(cardPrefab,enemyDeckTransform,false);
            int cardID = Random.Range((int)CardID.E_SLASH,(int)CardID.CardCount);
            Debug.Log(cardID);
            enemycard.Init(cardID,false,false);
            enemydeck.Add(enemycard);
        }
        //card.Init("スラッシュ");
        phase = Phase.DRAW;
    }
    void DrawPhase(){   //カードを引くフェーズ
        Debug.Log("DrawPhase");
        int CardCount = 10;     //Random.Rangeの最大値
        for(int i = 0; i < 5; i++){     //カード５枚引く処理
            Card card = deck.Pull(Random.Range(0,deck.cardList.Count));   //Random.Range(最小値,最大値)
            Card enemycard = enemydeck.Pull(Random.Range(0,enemydeck.enemycardList.Count));
            EnemybattlecardList.Add(enemycard);
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
        Card _enemycard = EnemybattlecardList[turn];
        _enemycard.CardDisplay();
        if(_card.cardSpeed < _enemycard.cardSpeed){     //0が速い 3が遅い
            Debug.Log("プレイヤーのターンから");
            _card.icardcon.Process();
            _enemycard.icardcon.Process();
        }else{
            Debug.Log("エネミーから");
            _enemycard.icardcon.Process();
            _card.icardcon.Process();
        }
        Debug.Log("ダメージ処理");
        player.OnDamage();
        enemy.OnDamage();
        graveyard.Add(_card);   //バトル終わったカードを墓地に送る
        //hand.Pull(_card.battlenumber);      //これだとbattlenumberの１とHandのリストの１が違う。。
                                                //バトルナンバーはクリックされた順番。ハンドのリストはハンドにカードが入れられた時の順番。
                                                //ほしいのはバトルするカードがハンドのリストの何番目に入ってるか。
                                                //別解、ハンドリストをバトルナンバー順にソートする。ことができれば。。
                                                
        enemygraveyard.Add(_enemycard);
        //enemyhand.Pull(_enemycard.battlenumber);
        Debug.Log(turn);
    }

    phase = Phase.END;
    }
    void EndPhase(){
        EnemybattlecardList.Clear();
        battlecardList.Clear();
        Debug.Log("EndPhase");
        if(enemydeck.enemycardList.Count == 0){
            for(int i = 0; i<10; i++){
                Card _enemycard = enemygraveyard.cardList[0];
                enemydeck.Add(_enemycard);
                enemygraveyard.Pull(0);
            }
        }
        if(deck.cardList.Count == 0){
            for(int i = 0; i < 10 ; i++){
            Card _card = graveyard.cardList[0];
            deck.Add(_card);
            graveyard.Pull(0);
            }
        }
        phase = Phase.DRAW;
    }
}
