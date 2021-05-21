using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseCardController : ICardController 
{
	private Player player = GameMaster.Instance.player;
    public override void Init(int characternumber){
		if(characternumber == (int)GameMaster.CharacterID.PLAYER){
			player.def = 80;
		}

    }
	public override void Process(int characternumber)
	{
		//if(characternanber == (int)GameMaster.CharacterID.PLAYER){
		//	player.
		//}
		Debug.Log("まもーる！！\n");
	}
}
