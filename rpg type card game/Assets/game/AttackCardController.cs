using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCardController : ICardController 
{	
    public override void Init(int characternanber){

    }
    public override void Process(int characternanber)
	{
		Debug.Log("こうげき！！\n");
        //if(characternanber == GameMaster.CharacterID.PLAYER){
        //    int fainalad = GameMaster.Instance.Player.playerad - GameMaster.Instance.Enemy.enemyad
        //}
	}

}
