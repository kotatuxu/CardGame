using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="CardEntity", menuName ="Create CardEntity")]
public class CardEntity : ScriptableObject
{
    public string name;
    public Sprite icon;
    public int cardSpeed;
}
