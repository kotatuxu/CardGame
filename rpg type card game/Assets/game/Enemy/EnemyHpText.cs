using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpText : MonoBehaviour
{
    public Text text;
    public void E_HpText(int maxenemyhp,int enemyhp){
        text.text = enemyhp + "/" + maxenemyhp;
    }
}
