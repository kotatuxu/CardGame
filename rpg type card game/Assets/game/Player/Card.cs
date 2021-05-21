using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    //cardID
    public ICardController icardcon;
    private CardFactryCaseBattle factry;
    private Image m_Image;
    private bool battlecard;
    private CardEntity m_cardEntity;
    public int battlenumber = 0;    //
    public int cardSpeed = 0;
    private string[] m_cardname = new string[]{
        "SLASH",
        "GUARD",
        "DODGE"
    };
    private bool m_isSelect = false;    //選択されてる？
    //初期化関数
    public void Init(int ID,bool isbattle){     //ゲームマスターからIDと戦闘用かどうか
        m_cardEntity = (CardEntity)Resources.Load<CardEntity>("CardInfo/"+m_cardname[ID]);  //これを参照します
        name = m_cardEntity.name;   //これでロード完了
        m_Image = GetComponent<Image>();    //ImageつかねーからGetしたぜ
        m_Image.sprite = m_cardEntity.icon;
        //Debug.Log("このカードの名前は"+m_cardEntity.name);
        battlecard = isbattle;
        //todo..デッキの紹介文を追加する場合はファクトリーを変える処理を追加する
        factry = new CardFactryCaseBattle();
        icardcon = factry.CreateCard(ID);   //IDはゲームマスターのRandom.Range
    }
    //OnClick関数(Unity側呼び出し)
    public void OnClick(){
        if(battlecard == true){
            if(battlenumber <= 0){
                GameMaster.Instance.battlecardList.Add(this);
                battlenumber = GameMaster.Instance.battlecardList.Count;    //これいらないかも？
                Debug.Log(battlenumber);    //
            }
            else{
                GameMaster.Instance.battlecardList.Remove(this);
                battlenumber = 0;   //
            }
        }
    }
    //selectflagを取得
    public bool getselectflag(){
        return m_isSelect;
    }
}
