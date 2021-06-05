using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckEscapeButton : MonoBehaviour
{
    public DeckButton deckbutton;
    public void OpenActive(){
        gameObject.SetActive(true);
    }
    public void OnClick(){
        GameMaster.Instance.deckcardlist.DeckCopyCopyClose();
        deckbutton.DeckEscapeAction();
        gameObject.SetActive(false);
    }
    public void CloseAction(){
        gameObject.SetActive(false);

    }
}
