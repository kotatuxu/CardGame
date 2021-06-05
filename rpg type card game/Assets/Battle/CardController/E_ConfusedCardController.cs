using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ConfusedCardController : ICardController 
{
    private Player player = GameMaster.Instance.player;
    private Enemy enemy = GameMaster.Instance.enemy;
    public override void Init(){
    }
    public override void Process()
	{
		Debug.Log("惑い");
    }
}