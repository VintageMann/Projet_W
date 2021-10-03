using System.Collections;
using UnityEngine;

public class Vortex : MonoBehaviour {

    public Element element;
    public float cooldown;
    private Element recentElement;
    public GameObject gameCanvas;

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
        recentElement = Instantiate(element, gameCanvas.transform);
    }

    public void DestroyRecetElement() {
        if (recentElement == null) {
            return;
        }
        Destroy(recentElement.gameObject);
    }

    public Element GetRecentElement() {
        return recentElement;
    }
}
