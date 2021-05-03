using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetButton : MonoBehaviour
{
    public void OnClick()
    {
        GameMaster.Instance.NextPhaseBattle();
    }
    public void SetIventButton()
    {
        gameObject.SetActive(true);

    }
    public void CloseSetButton(){
        gameObject.SetActive(false);
    }
}
