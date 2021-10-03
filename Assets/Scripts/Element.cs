using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Element : MonoBehaviour
{
    public enum Elements {Feu, Eau, Terre, Foudre, Lumiere, Vide, Aucun}; 

    public float minDuree;
    public float maxDuree;
    public Elements type;
    public Image elementImage;

    // Start is called before the first frame update

    void Awake() {
        type = (Elements)Random.Range(0,5);
        elementImage.sprite = Resources.Load<Sprite>(type.ToString());
        StartCoroutine(Lifespan());
    }

    void OnDestroy(){
        Vortex vortex = FindObjectOfType<Vortex>();
        vortex.StartCoroutine(vortex.Cooldown());
    }

    IEnumerator Lifespan () {
        float lifespan = Random.Range(minDuree, maxDuree);
        while (lifespan > 0f) {
            lifespan -= Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
