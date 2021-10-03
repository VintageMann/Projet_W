using System.Collections;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public Vortex vortex;
    public Character player;
    PlayerControls controls;
    public float cooldown;
    public Rigidbody bullet;

    public float channelTime;
    
    void OnEnable(){
        controls = new PlayerControls();
        controls.Enable();
        controls.Player.Fire.performed += ctx => Fire();
        controls.Player.Channel.performed += ctx => StartCoroutine(Channel());
    }

    void OnDisable(){
        controls.Player.Disable();
    }

    IEnumerator Channel() {
        controls.Player.Disable();
        float ch = channelTime;
        while (ch > 0) {
            ch -= Time.deltaTime;
            yield return null;
        }
        Element recent = vortex.GetRecentElement();
        if (recent != null && player.holding == Element.Elements.Aucun) {
            player.PickElement(vortex.GetRecentElement());
            vortex.DestroyRecetElement();
        }
        
        controls.Player.Enable();
    }

    void Fire()
    {
        Rigidbody bulletClone = Instantiate(bullet, transform.position, transform.rotation);
        bulletClone.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
    }

    public IEnumerator Cooldown()
    {
        float cd = cooldown;
        while (cd >= 0f)
        {
            controls.Player.Fire.Disable();
            cd -= Time.deltaTime;
            yield return null;
        }
        controls.Player.Fire.Enable();
    }
}
