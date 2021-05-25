using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxenemyhp;
    public float finaldm;
    public int enemyhp;
    public int enemyad;
    public int enemyap;
    public EnemyHpText enemyhptext;
    public Sprite icon;

    public void Init(){
        maxenemyhp = 100;     //とりあえずの初期設定
        enemyad = 10;
        enemyhp = maxenemyhp;     //maxhpから始まるだけ
        enemyhptext.E_HpText(maxenemyhp,enemyhp);    //初期hpを添えるだけ
    }

    public void OnDamage()
    {
        enemyhp -= (int)finaldm;
        enemyhptext.E_HpText(maxenemyhp,enemyhp);    //ダメージ後の体力調整
    }
}