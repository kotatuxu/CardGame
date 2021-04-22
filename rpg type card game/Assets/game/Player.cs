using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Deck deck;
    public Hand hand;
    public int playerhp;
    public int playerad;
    public GameMaster gamemaster;
    public Sprite icon;

    public void OnDamage(int enemyad)
    {
        playerhp -= enemyad;
        if(playerhp <= 0){
            playerhp = 0;
        }
    }
    // public void Draw(){
    //     for(int i = 0; i < 5; i++){
    //         Card card = deck.Pull(0);
    //         hand.Add(card);
    //     }
    // }
}