using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetButton : MonoBehaviour
{
    public GameMaster gamemaster;
    public void CardSetIvent()
    {
        gameObject.SetActive(true);
        Debug.Log("ボタン出現");

    }
    public void OnClick()
    {
        Debug.Log("OnClickTest");
        gamemaster.CardSelectClear();
    }
    public void Reset(){
        gameObject.SetActive(false);
    }
}
