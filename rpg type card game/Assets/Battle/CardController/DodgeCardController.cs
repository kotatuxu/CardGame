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
        Debug.Log("回避！！");
        if(player.finaldm != 0){
            Debug.Log("回避成功！！");
            player.dodgestatus = 2;
        }
        player.finaldm = 0;
    }
}
