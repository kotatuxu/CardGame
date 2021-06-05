using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void MenuOpenAction(){
        gameObject.SetActive(true);
        
    }
    public void MenuCloseAction(){
        gameObject.SetActive(false);
    }
}
