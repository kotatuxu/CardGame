using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckButton : MonoBehaviour
{
    public DeckCopyCopy deckcopycopy;
    public void MenuOpenAction(){
        gameObject.SetActive(true);
    }
    public void MenuCloseAction(){
        gameObject.SetActive(false);
    }

    public void OnClick()
    {
        deckcopycopy.DeckMenu();
        Debug.Log("deck押された!");  // ログを出力
    }
}
