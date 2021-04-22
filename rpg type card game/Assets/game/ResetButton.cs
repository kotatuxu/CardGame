using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public GameMaster gamemaster;
    public SetButton setbutton;
    public Hand hand;
    //[SerializeField] GameObject cardPrefab;
    public void OnClick(){
        gamemaster.SelectCardCount = 0;
        gamemaster.number6 = false;        
        setbutton.Reset();
        for(int i = 0; i < gamemaster.cardList.Count; i++){
            gamemaster.cardList[i].ResetCard();
        }
    }
}
