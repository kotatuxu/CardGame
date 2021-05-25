using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {
    public List<Card> cardList = new List<Card>();
        public void Add(Card _card){
            Debug.Log(_card);
        _card.transform.SetParent(this.transform);
        cardList.Add(_card);
    }
    public Card Pull(int _position){    //カードをデッキから消す処理    
        Card card = cardList[_position];
        cardList.Remove(card);      //カードリストからこれを削除する      
        return card;
    }
    // ボタンが押された場合、今回呼び出される関数
}
