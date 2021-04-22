
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {
    public List<Card> cardList = new List<Card>();
    // public void Add(Card _card){
    //     _card.transform.SetParent(this.transform);
    //     cardList.Add(_card);
    // }
    // public Card Pull(int _position){
    //     Card card = cardList[_position];
    //     cardList.Remove(card);
    //     return card;
    // }    
    public void Reset(){
        for(int i = 0; i < cardList.Count; i++){
            cardList[i].ResetCard();
        }
    }
}