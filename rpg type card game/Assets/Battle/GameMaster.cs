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
    private static CardFactryCaseBattle CFCB;
    public static CardFactryCaseBattle getcardfactry{  
        get{
        if(CFCB == null){
            CFCB = new CardFactryCaseBattle();
        }
        return CFCB;
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
    public MapPanel mappanel;
    public BattleScene battlescene;
    public NumberIcon numbericon;
    public List<Card> battlecardList = new List<Card>();    //カードを選択した枚数
    public List<Card> EnemybattlecardList = new List<Card>(); //上と同じだが、順番も兼ねる
    //プレイヤーのデッキの場所を示す
    public int turn = 0;
    [SerializeField] Transform playerDeckTransform;
    [SerializeField] Transform playerHandTransform;
    [SerializeField] Transform enemyDeckTransform;
    [SerializeField] Transform enemyHandTransform;
    //カードを示す
    public enum EnemyID{
        gomi1,
        test1,
        test2_adc,
        EnemyCount,
    };
    public enum CardID{     //定義する
        SLASH,
        GUARD,
        DODGE,
        E_SLASH,
        E_GUARD,
        E_MAGIC,
        E_CONFUSED,
        CardCount,   //カードの種類の最大値
    };
    enum Phase{
        LOBBY,
        STAGESELECT,
        INIT,
        DRAW,
        SELECT,
        BATTLE,
        END,
        BATTLEEND,
    };
    Phase phase;
    void Update () {
        switch(phase){
            case Phase.LOBBY:
            Lobby();
            break;
            case Phase.STAGESELECT:
            StageSelect();
            break;
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
            case Phase.BATTLEEND:
            BattleEnd();
            break;
        }       
    }
    void Lobby(){
        Debug.Log("一応ロビーいったよ");
        phase = Phase.STAGESELECT;
    }
    void StageSelect(){
        mappanel.StageSelect();
        Debug.Log("StageSelectPhase");
    }
    public void BattleStart(){      //セットボタンクリックされた
        phase = Phase.INIT;
    }
    void InitPhase(){   //生成フェーズ
        Debug.Log("InitPhase");
        player.Init();
        int enemyID = Random.Range(0,(int)EnemyID.EnemyCount);
        enemy.Init(enemyID);
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
            //Debug.Log(cardID);
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
            card.numbericon = Instantiate(numbericon,card.transform,false);
            card.numbericon.NotActive();
            enemyhand.Add(enemycard);
        }
        phase = Phase.SELECT;
    }
    public void SelectPhase(){      //セレクトフェーズ
        for(int i = 0; i < player.gaze; i++){       //敵のセレクトカードをgaze分見れる
        Card _card = enemyhand.enemycardList[i];
        _card.CardDisplay();
        }
        //Debug.Log(battlecardList.Count);
        if(battlecardList.Count == 5){      //battlecardListはカード選択時＋１するよ
            setbutton.SetIventButton();     //battlecardListが５ならセットボタンを生成する
        }else{
            setbutton.CloseSetButton();     //battlecatdListが５でないならセットボタンをしまう
        }
    }
    public void IconResetProcess(int test){     //カードの番号絵を書き換える
        for(int i = 0; i < battlecardList.Count; i++){  //１度選択されたすべてのカードの番号を見直す。
            Card _card = battlecardList[i];
            _card.numbericon.Reset(_card,test);
        }
    }
    public void NextPhaseBattle(){      //セットボタンクリックされた
        phase = Phase.BATTLE;
    }
    void BattlePhase(){     //バトルフェーズ
    phase = Phase.END;
    Debug.Log("BattlePhase");
    for(int turn = 0; turn < 5; turn++){
        Card _card = battlecardList[turn];     //バトルカードリストの０番目を_cardとする
        Card _enemycard = EnemybattlecardList[turn];
        _enemycard.CardDisplay();
        if(_card.cardSpeed < _enemycard.cardSpeed){     //0が速い 3が遅い
            Debug.Log("プレイヤー先行");
            _card.icardcon.Process();
            _enemycard.icardcon.Process();
        }else{
            Debug.Log("エネミー先行");
            _enemycard.icardcon.Process();
            _card.icardcon.Process();
        }
        Debug.Log("ダメージ処理");
        Debug.Log("エネミーに" + enemy.finaldm +"ダメージ！！");
        enemy.OnDamage();
        if(enemy.enemyhp <= 0){
            battlescene.EndBattle();
            phase = Phase.BATTLEEND;
            break;
        }
        Debug.Log("プレイヤーに" + player.finaldm + "ダメージ！！");
        player.OnDamage();
        if(player.playerhp <= 0){
            Debug.Log("ゲーム終了");
            battlescene.EndBattle();
            phase = Phase.LOBBY;
            break;
        }
        player.turn();
        graveyard.Add(_card);   //バトル終わったカードを墓地に送る
        enemy.turn();
        enemygraveyard.Add(_enemycard);
        //カードの添え字検索
        _card.DataClear();
        int arrayNO = hand.cardList.FindIndex(c => c.battlenumber == _card.battlenumber);
        Card it = hand.Pull(arrayNO);
        //Debug.Log(arrayNO);
        _enemycard.E_DataClear();
        arrayNO = enemyhand.enemycardList.FindIndex(c => c.battlenumber == _enemycard.battlenumber);
        it = enemyhand.Pull(arrayNO);
        //Debug.Log(arrayNO);
        //Debug.Log(turn + "経過");
        }
 
    }
    void EndPhase(){
        EnemybattlecardList.Clear();
        battlecardList.Clear();
        Debug.Log("EndPhase");
        player.Phase();
        enemy.Phase();
        if(enemydeck.enemycardList.Count == 0){     //墓地から手札へ
            for(int i = 0; i<10; i++){
                Card _enemycard = enemygraveyard.cardList[0];
                enemydeck.Add(_enemycard);
                enemygraveyard.Pull(0);
            }
        }
        if(deck.cardList.Count == 0){
            for(int i = 0; i < 10 ; i++){
            Card _card = graveyard.cardList[0];
            _card.numbericon.NotActive();
            deck.Add(_card);
            graveyard.Pull(0);
            }
        }
        phase = Phase.DRAW;
    }
    void BattleEnd(){
        Debug.Log("バトルエンド");
        for(int i = 0; i < hand.cardList.Count; i++){
            Card _card = hand.cardList[i];
            Destroy(_card.gameObject);
        }
        for(int i = 0; i < deck.cardList.Count; i++){
            Card _card = deck.cardList[i];
            Destroy(_card.gameObject);
        }
        for(int i = 0; i < graveyard.cardList.Count; i++){
            Card _card = graveyard.cardList[i];
            Destroy(_card.gameObject);
        }
        
        hand.cardList.Clear();
        EnemybattlecardList.Clear();
        battlecardList.Clear();
        deck.cardList.Clear();
        graveyard.cardList.Clear();
    }
}
