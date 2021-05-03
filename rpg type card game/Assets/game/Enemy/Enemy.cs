using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int CurrentDef = 0;
    public int maxenemyhp;
    public int enemyhp;
    public int enemyad;
    public int enemyap;
    public EnemyHpText enemyhptext;
    public Sprite icon;


    public void OnDamage(int playerad)
    {
        enemyhp-= playerad;
        if(enemyhp <= 0){
            enemyhp = 0;
        }
        enemyhptext.E_HpText(maxenemyhp,enemyhp);
    }
}