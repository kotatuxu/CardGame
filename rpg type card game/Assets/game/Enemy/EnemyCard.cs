using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCard : MonoBehaviour
{
    private Image m_Image;
    public int cardSpeed = 1;
    public enum enemycardID{
        SLASH,
        GUARD,
        MAGIC,
        CardCount
    };
    private EnemyCardEntity m_enemycardEntity;
    private string[] m_enemycardname = new string[]{
        "SLASH",
        "GUARD",
        "MAGIC"
    };
    private bool m_isSelect = false;    //選択されてる？
    //初期化関数
    public void Init(int ID){
        m_enemycardEntity = (EnemyCardEntity)Resources.Load<EnemyCardEntity>("EnemyCardInfo/"+m_enemycardname[ID]);
        Debug.Log("このエネミーカードの名前は"+m_enemycardEntity.name);
        name = m_enemycardEntity.name;
        m_Image = GetComponent<Image>();
        m_Image.sprite = m_enemycardEntity.icon;
    }
}
