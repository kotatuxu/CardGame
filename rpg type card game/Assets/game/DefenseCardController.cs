using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseCardController : ICardController 
{
	private Player player = GameMaster.Instance.player;
    public override void Init(int characternanber){
		if(characternanber == (int)GameMaster.CharacterID.PLAYER){
			player.CurrentDef = player.playerdef;
		}

    }
	public override void Process(int characternanber)
	{
		//if(characternanber == (int)GameMaster.CharacterID.PLAYER){
		//	player.
		//}
		Debug.Log("まもーる！！\n");
	}
}
