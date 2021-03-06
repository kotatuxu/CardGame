
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {
    public List<Card> cardList = new List<Card>();
    public void Add(Card _card){
        _card.transform.SetParent(this.transform);
        cardList.Add(_card);
    }
    public Card Pull(int _position){        
        Card card = cardList[_position];    //_positionの数の場所をカードをcardとする
        cardList.Remove(card);              //そのcardをcardListから削除する
        return card;
    }    
}