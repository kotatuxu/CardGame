using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    private Player player;
    public string name;
    private GameMaster gamemaster;
    private Menu menu;

    private void Start(){
        player = (Player)FindObjectOfType(typeof(Player));
        gamemaster = (GameMaster)FindObjectOfType(typeof(GameMaster));
        menu = (Menu)FindObjectOfType(typeof(Menu));
    }
    private bool isClick = false;
    public int number = 0;
    public void OnClick(){
        if(menu.MenuOpenComplete == false){
            if(gamemaster.SelectPhaseCardAction == true){
                if(gamemaster.number6 == false){
                    if(isClick == false ){
                        number = gamemaster.SelectCardCount;
                        gamemaster.SelectCardCount++;
                        isClick = true; 
                    } 
                }
            }
        }
    }
    //public void CardAction(){
    //    if(number == Turn){
    //    SelectCardAction();
    //    gamemaster.Turn++;
    //    gamemaster
    //    
    //    }
    //}
    public void ResetCard(){
        isClick = false;
        number = 0;
    }
    public Card(int cardID){
        Debug.Log("コンストラクタ");
        CardEntity cardEntity = (CardEntity)Resources.Load<CardEntity>("CardInfo/CardEntity1");
        name = cardEntity.name;
    }
}