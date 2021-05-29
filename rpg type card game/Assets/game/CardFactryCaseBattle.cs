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
        else if(_cardID == (int)GameMaster.CardID.E_SLASH){
            ICardController RetCard = new E_AttackCardController();
            return RetCard;
        }
        else if(_cardID == (int)GameMaster.CardID.E_GUARD){
            ICardController RetCard = new E_DefenseCardController();
            return RetCard;
        }
        else if(_cardID == (int)GameMaster.CardID.E_MAGIC){
            ICardController RetCard = new E_MagicCardController();
            return RetCard;
        }
        else if(_cardID == (int)GameMaster.CardID.E_CONFUSED){
            ICardController RetCard = new E_ConfusedCardController();
            return RetCard;
        }else{
            Debug.Log("エラー");
            return null;
        }

    }
}
