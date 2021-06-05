using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{
    public Text text;
    public void HpText(int maxplayerhp,int playerhp){

        text.text = playerhp + "/" + maxplayerhp;
    }
}
