using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="EnemyCardEntity", menuName ="Create EnemyCardEntity")]
public class EnemyCardEntity : ScriptableObject
{
    public string name;
    public int number;
    public int type;
    public Sprite icon;
    public int cardSpeed;
}