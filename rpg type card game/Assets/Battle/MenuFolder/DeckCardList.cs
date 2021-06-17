using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckCardList : MonoBehaviour
{
    [SerializeField] Transform deckcardlistTransform;   //ここで場所指定するからSerializeでもいいのかも？
    public List<Card> deckcardList = new List<Card>();      //Addとほぼ同じしょり～
        //Deckに渡されるカードと同じIDのカードを生成する
        public void Create(int cardID){
            Card card = Instantiate(Resources.Load<Card>("Prefab/Card"),deckcardlistTransform,false);
            //cardをInitしてcardIDとbattlecardをfalseにする
            card.Init(cardID,false,true);
        deckcardList.Add(card);
    }
    public void DeckOpen(){
        gameObject.SetActive(true);
    }
    public void DeckCopyCopyClose(){
        gameObject.SetActive(false);
    }
}
