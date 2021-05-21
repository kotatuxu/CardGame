using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHand : MonoBehaviour
{
    public List<EnemyCard> enemycardList = new List<EnemyCard>();

        public void Add(EnemyCard _enemycard){
            Debug.Log(_enemycard);
        _enemycard.transform.SetParent(this.transform);
        enemycardList.Add(_enemycard);
    }
        public EnemyCard Pull(int _position){
        EnemyCard enemycard = enemycardList[_position];
        enemycardList.Remove(enemycard);
        return enemycard;
    }
}
