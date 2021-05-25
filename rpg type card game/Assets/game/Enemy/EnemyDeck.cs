using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeck : MonoBehaviour
{
    public List<Card> enemycardList = new List<Card>();
        public void Add(Card _enemycard){
            Debug.Log(_enemycard);
        _enemycard.transform.SetParent(this.transform);
        enemycardList.Add(_enemycard);
    }
    public Card Pull(int _position){
        Card enemycard = enemycardList[_position];
        enemycardList.Remove(enemycard);
        return enemycard;
    }
}
