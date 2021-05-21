using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCardController : ICardController 
{	
    private Player player = GameMaster.Instance.player;
    private Enemy enemy = GameMaster.Instance.enemy;
    public override void Init(int characternumber){
		if(characternumber == (int)GameMaster.CharacterID.PLAYER){
            player.OnDamage();
        }else{
            enemy.OnDamage();
        }
    }
    public override void Process(int characternumber)
	{
		Debug.Log("こうげき！！\n");
        //if(characternanber == GameMaster.CharacterID.PLAYER){
        //    int fainalad = GameMaster.Instance.Player.playerad - GameMaster.Instance.Enemy.enemyad
        //}
	}

}
