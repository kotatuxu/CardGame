using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCardController : ICardController 
{	
    private Player player = GameMaster.Instance.player;
    private Enemy enemy = GameMaster.Instance.enemy;
    public override void Init(){
    }
    public override void Process()
	{
		Debug.Log("こうげき！！\n");
        enemy.finaldm = player.playerad;

        //if(characternanber == GameMaster.CharacterID.PLAYER){
        //    int fainalad = GameMaster.Instance.Player.playerad - GameMaster.Instance.Enemy.enemyad
        //}
	}

}
