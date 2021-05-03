using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeCardController : ICardController 
{
	private Player player = GameMaster.Instance.player;
    public override void Init(int characternanber){
		if(characternanber == (int)GameMaster.CharacterID.PLAYER){
			player.CurrentDef = 99999;
		}
    }
    public override void Process(int characternanber)
	{
		Debug.Log("回避！！\n");
	}
}
