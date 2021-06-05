using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScene : MonoBehaviour
{
    public MapPanel mappanel;
    public void BattleStart(){
        gameObject.SetActive(true);
    }
    public void BattleEnd(){
        gameObject.SetActive(false);
        mappanel.StageSelect();
    }
}
