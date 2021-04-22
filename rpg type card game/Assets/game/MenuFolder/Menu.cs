using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    // ボタンが押された場合、今回呼び出される関数
    public MenuOpen menuopen;
    public bool MenuOpenComplete = false;
    public DeckButton deckbutton;
    public DeckCopyCopy deckcopycopy;
    public void OnClick()
    {
        if(MenuOpenComplete == true){
            menuopen.MenuCloseAction();
            deckbutton.MenuCloseAction();
            deckcopycopy.DeckCopyCopyClose();
            MenuOpenComplete = false;
        } 
        else{
            MenuOpenComplete = true;
            menuopen.MenuOpenAction();
            deckbutton.MenuOpenAction();
        }
    }
}
