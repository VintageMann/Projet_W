using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireprojectile : MonoBehaviour
{
	public float bulletSpeed = 10;
	public Rigidbody bullet;
    public float speed = 3;
    public float rotationRate = 360;
    public float wait = 500;
    PlayerControls controls;
    public float cooldown;
    Vector3 move;
    Vector3 aim;


    void Awake(){
        controls = new PlayerControls();
        controls.Player.Fire.performed += ctx => Fire();
        controls.Player.Aim.performed += ctx => aim = ctx.ReadValue<Vector2>().normalized;
    }

    void Update(){
        if( wait >= 1){
            wait--;
        }
        Debug.Log(wait);
    }

    
    void Fire(){
        if(wait == 0){
    		Rigidbody bulletClone = Instantiate(bullet, transform.position, transform.rotation);
    		bulletClone.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
            wait = 500;
            
        }   
    }

    public IEnumerator Cooldown() {
        float cd = cooldown;
        while (cd > 0f) {
            controls.Player.Fire.Disable();
            cd -= Time.deltaTime;
            yield return null;
        }
        controls.Player.Fire.Enable();
    }


    void OnEnable(){
        controls.Player.Enable();

    }
}

