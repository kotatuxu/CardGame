using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseCardController : ICardController 
{
	private Player player = GameMaster.Instance.player;
	private Enemy enemy = GameMaster.Instance.enemy;
    public override void Init(){
    }
	public override void Process()
	{
        player.finaldm *= 0.2f;
		player.finaldm = Mathf.Ceil(player.finaldm);
	}
}
