using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckButton : MonoBehaviour
{
    private bool Click;
    [SerializeField]  DeckEscapeButton deckescapebutton;
    public void DeckOpenAction(){
        gameObject.SetActive(true);
    }
    public void DeckCloseAction(){
        gameObject.SetActive(false);
        Click = false;
    }
    public void DeckEscapeAction(){
        Click = false;
    }

    public void OnClick()
    {
        if(Click == false){
        GameMaster.Instance.deckcardlist.DeckOpen();
        deckescapebutton.OpenActive();
        Debug.Log("deck押された!");  // ログを出力
        Click = true;
        }else{
            deckescapebutton.CloseAction();
            GameMaster.Instance.deckcardlist.DeckCopyCopyClose();
            Click = false;
        }
    }
}
