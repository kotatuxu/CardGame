using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxplayerhp;
    public int playerhp;
    public int playerad;    //基礎攻撃力
    public float finaldm;     //最終算出ダメージ
    public GameMaster gamemaster;
    public Sprite icon;
    public Text text;
    public Hp hp;

    public void Init(){
        maxplayerhp = 100;     //とりあえずの初期設定
        playerad = 10;
        playerhp = maxplayerhp;     //maxhpから始まるだけ
        hp.HpText(maxplayerhp,playerhp);    //初期hpを添えるだけ
    }
    public void OnDamage(){
        playerhp -= (int)finaldm;
        hp.HpText(maxplayerhp,playerhp);    //ダメージ後の体力調整
    }
}