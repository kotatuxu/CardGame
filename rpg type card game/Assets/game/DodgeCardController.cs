using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeCardController : ICardController 
{
	private Player player = GameMaster.Instance.player;
    public override void Init(int characternumber){
		if(characternumber == (int)GameMaster.CharacterID.PLAYER){
			Debug.Log("回避");
		}
    }
    public override void Process(int characternumber)
	{
		Debug.Log("回避！！\n");
	}
}
