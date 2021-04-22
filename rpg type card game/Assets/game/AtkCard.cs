using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkCard : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    public Sprite icon;
    public void Action()
    {
        enemy.OnDamage(player.playerad);
    }
}
