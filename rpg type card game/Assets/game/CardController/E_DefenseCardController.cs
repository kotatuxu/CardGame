using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_DefenseCardController : ICardController 
{
    private Player player = GameMaster.Instance.player;
    private Enemy enemy = GameMaster.Instance.enemy;
    public override void Init(){
    }
    public override void Process()
	{
        enemy.finaldm *= 0.2f;
		enemy.finaldm = Mathf.Ceil(enemy.finaldm);
    }
}