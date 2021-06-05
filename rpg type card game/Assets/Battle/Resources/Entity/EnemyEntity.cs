using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="EnemyEntity", menuName ="Create EnemyEntity")]
public class EnemyEntity : ScriptableObject
{
    public string name;
    public int maxenemyhp;
    public int enemyad;
    public float getenemycd;
    public int enemyap;
    public Sprite icon;
}