using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameMaster gamemaster;
    public Sprite icon;
    public Text text;
    public Hp hp;
    public int maxplayerhp;
    public int playerhp;
    public int playerct;
    public float playerad;    //基礎攻撃力
    public float finaldm;     //最終算出ダメージ
    public int dodgestatus;   //ドッジ後のクリティカル
    public int gaze;          //凝視する値（敵のカードを見抜く）

    public void Init(){
        maxplayerhp = 100;     //とりあえずの初期設定
        playerad = 10;
        playerct = 5;           //クリティカル５パーセント
        gaze = 2;               //敵のカード可視化
        playerhp = maxplayerhp;     //maxhpから始まるだけ
        hp.HpText(maxplayerhp,playerhp);    //初期hpを添えるだけ
    }
    public void OnDamage(){
        playerhp -= (int)finaldm;
        hp.HpText(maxplayerhp,playerhp);    //ダメージ後の体力調整
        finaldm = 0;
    }
    public void turn(){         //ターン内での処理（次の攻撃が～～等）
        if(dodgestatus != 0){   //ドッヂが０じゃないなら-1します（０以下にならないように）
            dodgestatus -= 1;

        }
    }
    public void Phase(){        //状態異常とかの管理
    dodgestatus = 0;

    }
}