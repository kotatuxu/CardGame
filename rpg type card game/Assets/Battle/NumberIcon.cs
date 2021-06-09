using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberIcon : MonoBehaviour
{
    
    private Image m_Image;
    private Sprite m_sprite;
    public void NotActive(){
        gameObject.SetActive(false);
    }
    public void Init(int number){
        gameObject.SetActive(true);
        m_Image = GetComponent<Image>();    //ImageつかねーからGetしたぜ
        m_Image.sprite = Resources.Load<Sprite>("Number/"+number);

    }
    public void Reset(Card card,int savenumber){
        m_Image = GetComponent<Image>();    //ImageつかねーからGetしたぜ
        if(card.battlenumber == savenumber){      //for文で来た番号がクリックしたカードならスプライトを消す
            gameObject.SetActive(false);
            m_Image.sprite = null;
        }else{
            if(card.battlenumber > savenumber -1){  //for文で来た番号がクリックしたカード以上なら-1して
                card.battlenumber -= 1;
            }
            //その番号の絵を写す
            m_Image.sprite = Resources.Load<Sprite>("Number/"+card.battlenumber);
        }
    }
}
