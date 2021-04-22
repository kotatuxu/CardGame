using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    public Player player;
    public Enemy enemy;
    public SetButton setbutton;
    public int SelectCardCount;
    public bool SelectPhaseCardAction = false;
    public int Turn;
    public List<int> cardList = new List<int>(){0,1,0,1,2};
    public bool number6 = false;
    //プレイヤーのデッキの場所を示す
    [SerializeField] Transform playerDeckTransform;
    [SerializeField] Transform playerHandTransform;
    //[SerializeField] Transform playerDeckCopyCopyTransform;
    //カードを示す
    [SerializeField] CardController cardPrefab;
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
    void InitPhase(){
        Debug.Log("InitPhase");
        //カードをデッキに生成する
        for(int i = 0; i < cardList.Count; i++){
        CardController card = Instantiate(cardPrefab, playerDeckTransform, false);
        card.Init(cardList[i]);
        }
        //Instantiate(cardPrefab, playerDeckCopyCopyTransform, false);
        //Instantiate(enemycardPrefab, enemyDeckTransform, false);
        phase = Phase.DRAW;
    }
    void DrawPhase(){
        Debug.Log("DrawPhase");
        SettingInitHand();
        //player.Draw();
        //enemy.Draw();
        phase = Phase.SELECT;
    }
    void SettingInitHand(){
        for(int i =0; i < 5; i++){
            GiveCardToHand(cardList,playerHandTransform);
        }
    }
    void GiveCardToHand(List<int> deck, Transform hand){
        int cardID = deck[0];
        deck.RemoveAt(0);
        CreateCard(cardID, hand);
    }
    void CreateCard(int cardID, Transform hand){
        CardController card = Instantiate(cardPrefab, hand, false);
        card.Init(cardID);
    }
    public void SelectPhase(){
        SelectPhaseCardAction = true;
        if(SelectCardCount == 5){
            setbutton.CardSetIvent();
            number6 = true;
        }
        //Debug.Log(SelectCardCount);
    }
    public void CardSelectClear(){
        phase = Phase.BATTLE;
    }
    void BattlePhase(){
        Debug.Log("BattlePhase");
        //card.CardAction(Trun = 0);
        //enemy.EnemyCardAction(Trun = 0);
        if(Turn == 5){
            phase = Phase.END;
        }
        else{
            phase = Phase.BATTLE;
        }
    }
    void EndPhase(){
        Debug.Log("EndPhase");
        //phase = Phase.DRAW;
    }
}
