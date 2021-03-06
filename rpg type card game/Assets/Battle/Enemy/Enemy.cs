using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public EnemyHand enemyhand;
    public EnemyDeck enemydeck;
    public EnemyGraveyard enemygraveyard;
    public int maxenemyhp;
    public float finaldm;
    public int enemyhp;
    public string name;
    public int enemyad;
    public float getenemycd;
    public int enemyap;
    public EnemyHpText enemyhptext;
    private EnemyEntity m_enemyEntity;
    public Transform enemyDeckTransform;
    private Image m_Image;
    public Sprite m_sprite;
    private string[] m_enemyname = new string[]{
        "gomi1",
        "test1",
        "test2_adc",
        "enemyCount"
    };

    public void Init(int ID){     //ゲームマスターからIDと戦闘用かどうか
    m_enemyEntity = (EnemyEntity)Resources.Load<EnemyEntity>("EnemyInfo/"+m_enemyname[ID]);  //これを参照します
    name = m_enemyEntity.name;   //これでロード完了
    enemyad = m_enemyEntity.enemyad;
    enemyap = m_enemyEntity.enemyap;
    m_sprite = m_enemyEntity.icon;
    maxenemyhp = m_enemyEntity.maxenemyhp;
    getenemycd = m_enemyEntity.getenemycd;      //弱点の弱さ
    enemyhp = maxenemyhp;
    enemyhptext.E_HpText(maxenemyhp,enemyhp);
    m_Image = GetComponent<Image>();    //ImageつかねーからGetしたぜ
    m_Image.sprite = m_sprite;
    }

    public void OnDamage()
    {
        enemyhp -= (int)finaldm;
        enemyhptext.E_HpText(maxenemyhp,enemyhp);    //ダメージ後の体力調整
        finaldm = 0;

    }
    public void turn(){

    }
    public void Phase(){
        
    }
}