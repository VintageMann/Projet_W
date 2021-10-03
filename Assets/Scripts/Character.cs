using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public int Health;
    public Element.Elements holding;
    public Element.Elements affinity;

    public void PickElement(Element element) {
        if (holding == Element.Elements.Aucun) {
            holding = element.type;
        }
    }
}
