using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactryCaseBattle : MonoBehaviour
{
    public ICardController CreateCard(int _cardID){
        if(_cardID == (int)GameMaster.CardID.SLASH){
            ICardController RetCard = new AttackCardController();
            return RetCard;
        }
        else if(_cardID == (int)GameMaster.CardID.GUARD){
            ICardController RetCard = new DefenseCardController();
            return RetCard;
        }
        else if(_cardID == (int)GameMaster.CardID.DODGE){
            ICardController RetCard = new DodgeCardController();
            return RetCard;
        }
        else{
            Debug.Log("エラー");
            return null;
        }

    }
}
