using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckCardList : MonoBehaviour
{
    [SerializeField] Transform deckcardlistTransform;   //ここで場所指定するからSerializeでもいいのかも？
    public List<Card> cardList = new List<Card>();      //Addとほぼ同じしょり～
        //Deckに渡されるカードと同じIDのカードを生成する
        public void Create(int cardID){
            Card card = Instantiate(GameMaster.Instance.cardPrefab,deckcardlistTransform,false);
            //cardをInitしてcardIDとbattlecardをfalseにする
            card.Init(cardID,false);
        cardList.Add(card);
    }
    public void DeckOpen(){
        gameObject.SetActive(true);
    }
    public void DeckCopyCopyClose(){
        gameObject.SetActive(false);
    }
}
