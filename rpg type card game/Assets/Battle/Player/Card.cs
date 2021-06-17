using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    //cardID
    public ICardController icardcon;
    [SerializeField] Transform transform;
    private Image m_Image;
    private Sprite m_sprite;
    public int cardID;
    private bool battlecard;
    private CardEntity m_cardEntity;
    public NumberIcon numbericon;
    public int battlenumber = 0;    
    public int cardSpeed = 0;
    private string[] m_cardname = new string[]{
        "SLASH",
        "GUARD",
        "DODGE",
        "E_SLASH",
        "E_GUARD",
        "E_MAGIC",
        "E_CONFUSED"
    };
    private bool m_isSelect = false;    //選択されてる？
    //初期化関数
    public void Init(int ID,bool isbattle,bool isDisplay){     //ゲームマスターからIDと戦闘用かどうか
        m_cardEntity = (CardEntity)Resources.Load<CardEntity>("CardInfo/"+m_cardname[ID]);  //これを参照します
        name = m_cardEntity.name;   //これでロード完了
        m_sprite = m_cardEntity.icon;
        if(isDisplay == true){
            CardDisplay();
        }
        //Debug.Log("このカードの名前は"+m_cardEntity.name);
        cardID = m_cardEntity.ID;
        cardSpeed = m_cardEntity.cardSpeed;
        battlecard = isbattle;
        //todo..デッキの紹介文を追加する場合はファクトリーを変える処理を追加する
        CardFactryCaseBattle factry = GameMaster.getcardfactry;
        icardcon = GameMaster.getcardfactry.CreateCard(ID);   //IDはゲームマスターのRandom.Range
        Debug.Log("初期化");
    }
    //OnClick関数(Unity側呼び出し)
    public void OnClick(){
        if(battlecard == true){     //選択できるカードか
            if(battlenumber == 0){    //１度選択されているかどうか
                GameMaster.Instance.battlecardList.Add(this);
                battlenumber = GameMaster.Instance.battlecardList.Count;
                numbericon.Init(battlenumber);
                Vector3 pos = this.transform.position;
                pos.y += 120;
                this.transform.position = pos;       //＋20した数字に移動
                Debug.Log(battlenumber);    
            }
            else{
                int test = battlenumber;
                Vector3 pos = this.transform.position;
                pos.y += -120;
                this.transform.position = pos;       //＋20した数字に移動
                GameMaster.Instance.IconResetProcess(test);
                Debug.Log("Remove");
                battlenumber = 0;   
                GameMaster.Instance.battlecardList.Remove(this);
                Debug.Log("バトルナンバー" + battlenumber);
                Debug.Log("合計選択数" + GameMaster.Instance.battlecardList.Count);
                Debug.Log("自分の番号" + battlenumber);
            }
        }
    }
    //表にする
    public void DataClear(){
        battlenumber = 0;
    }
    public void E_DataClear(){
        battlenumber = 0;
        m_Image = GetComponent<Image>();    //ImageつかねーからGetしたぜ
        m_Image.sprite = null;
    }
    public void CardDisplay(){
        m_Image = GetComponent<Image>();    //ImageつかねーからGetしたぜ
        m_Image.sprite = m_sprite;
    }
    
    //selectflagを取得
    public bool getselectflag(){
        return m_isSelect;
    }
}
