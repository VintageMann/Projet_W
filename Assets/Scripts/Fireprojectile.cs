using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireprojectile : MonoBehaviour
{
	public float bulletSpeed = 10;
	public Rigidbody bullet;
    public float speed = 3;
    public float rotationRate = 360;
    PlayerControls controls;
    Vector3 move;
    Vector3 aim;


    void Awake(){
        controls = new PlayerControls();
        controls.Player.Fire.performed += ctx => Fire();
        controls.Player.Aim.performed += ctx => aim = ctx.ReadValue<Vector2>().normalized;
    }

    void Update(){
    }

    void Fire(){
		Rigidbody bulletClone = Instantiate(bullet, transform.position, transform.rotation);
		bulletClone.GetComponent<Rigidbody>().AddForce(transform.forward * 10000);
        

    }

    void OnEnable(){
        controls.Player.Enable();

    }

    void OnDisable(){
        controls.Player.Disable();

    }
}

