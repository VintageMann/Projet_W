using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vortex : MonoBehaviour {

    public GameObject element;
    public float cooldown;

    void Awake () {
        StartCoroutine(Cooldown());
    }

    void Update() {
    }

    public IEnumerator Cooldown() {
        float cd = cooldown;
        while (cd > 0f) {
            cd -= Time.deltaTime;
            yield return null;
        }
        GameObject cloneElement = Instantiate(element);
    }

}
