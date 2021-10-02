using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireprojectile : MonoBehaviour
{
	public float bulletSpeed = 10;
	public Rigidbody bullet;
	PlayerControls controls;
    Vector3 move;
    public float speed = 3;

    void Awake(){
        controls = new PlayerControls();
        controls.Player.Fire.performed += ctx => Fire();
    }

    void Update(){
		Vector3 m = new Vector3(move.x, 0.0f, move.y) * speed * Time.deltaTime;
		transform.Translate(m, Space.World); 
    }

    void Fire(){
		Rigidbody bulletClone = Instantiate(bullet, transform.position, transform.rotation);
		bulletClone.velocity = transform.forward * bulletSpeed;
    }

    void OnEnable(){
        controls.Player.Enable();

    }

    void OnDisable(){
        controls.Player.Disable();

    }
}

