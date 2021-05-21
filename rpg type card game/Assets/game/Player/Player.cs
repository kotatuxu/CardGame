using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int def = 1;
    public bool dodge = false;
    public int maxplayerhp;
    public int playerdef;
    public int playerhp;
    public int playerad;
    public GameMaster gamemaster;
    public Sprite icon;
    public Text text;
    public Hp hp;

    public void Init(){
        maxplayerhp = 100;     //とりあえずの初期設定
        playerhp = maxplayerhp;     //maxhpから始まるだけ
        hp.HpText(maxplayerhp,playerhp);    //初期hpを添えるだけ
    }
    public void OnDamage()
    {
        
        if(dodge == true){
            Debug.Log("回避");
        }else{
            playerhp -= GameMaster.Instance.enemy.enemyad / def;
            if(playerhp <= 0){
                playerhp = 0;
            }
        }
        hp.HpText(maxplayerhp,playerhp);    //ダメージ後の体力調整
    }

}