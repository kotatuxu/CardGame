using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCardController : ICardController 
{	
    private Player player = GameMaster.Instance.player;
    private Enemy enemy = GameMaster.Instance.enemy;
    public override void Init(){
    }
    public override void Process()
	{
        //ここにカードを吸収する処理を書く
		Debug.Log("こうげき！！\n");
        enemy.finaldm = player.playerad;
        //クリティカル確率
        int ct = Random.Range(0,100);
        if(player.dodgestatus != 0){
            ct = 0;
            Debug.Log("回避後！！");
        }
        Debug.Log("クリット期待値=" + ct);
        //クリティカル処理＆ダメージ増減処理
        if(ct <= player.playerct){
            Debug.Log("クリティカル！！");
            enemy.finaldm *= enemy.getenemycd;
            enemy.finaldm = Mathf.Ceil(enemy.finaldm);
            }
        //if(characternanber == GameMaster.CharacterID.PLAYER){
        //    int fainalad = GameMaster.Instance.Player.playerad - GameMaster.Instance.Enemy.enemyad
        //}
	}
}
