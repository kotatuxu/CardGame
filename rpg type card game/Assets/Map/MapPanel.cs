using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPanel : MonoBehaviour
{
    public void MapClose(){
        gameObject.SetActive(false);
    }
    public void StageSelect(){
        gameObject.SetActive(true);
    }
}
