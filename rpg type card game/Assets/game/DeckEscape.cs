using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckEscape : MonoBehaviour
{
    public DeckCopyCopy deckcopycopy;
    public void OnClick(){
        deckcopycopy.DeckCopyCopyClose();
    }
}
