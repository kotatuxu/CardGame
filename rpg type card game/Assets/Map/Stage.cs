using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public BattleScene battlescene;
    public MapPanel mappanel;
    public void OnClick(){
        battlescene.BattleStart();
        GameMaster.Instance.BattleStart();
        mappanel.MapClose();
    }
}
