using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeCardController : ICardController 
{
	private Player player = GameMaster.Instance.player;
	private Enemy enemy = GameMaster.Instance.enemy;
    public override void Init(){
    }
    public override void Process()
	{
        player.finaldm = 0;
    }
}
