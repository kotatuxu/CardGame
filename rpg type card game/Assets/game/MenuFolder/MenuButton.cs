using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour {

    // ボタンが押された場合、今回呼び出される関数
    public Menu menu;
    public bool MenuOpenComplete;
    public DeckEscapeButton deckescapebutton;
    public DeckButton deckbutton;
    public void OnClick()
    {
        if(MenuOpenComplete == false){
            menu.MenuOpenAction();
            deckbutton.DeckOpenAction();
            MenuOpenComplete = true;
            Debug.Log("Open");
        }
        else{
            MenuOpenComplete = false;
            GameMaster.Instance.deckcardlist.DeckCopyCopyClose();
            deckescapebutton.CloseAction();
            menu.MenuCloseAction();
            deckbutton.DeckCloseAction();
            Debug.Log("Close");
        }
    }
}
