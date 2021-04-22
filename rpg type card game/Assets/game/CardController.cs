using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    Card card;
    public void Init(int cardID)
    {
        card = new Card(cardID);
    }
}
