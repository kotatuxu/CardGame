using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyhp;
    public int enemyad;
    public int enemyap;
    public Sprite icon;

    public void OnDamage(int playerad)
    {
        enemyhp-= playerad;
        if(enemyhp <= 0){
            enemyhp = 0;
        }
    }
}