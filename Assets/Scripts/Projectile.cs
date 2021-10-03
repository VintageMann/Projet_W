using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Projectile : MonoBehaviour{
	public GameObject explosion;
	public float lifespan;

   void OnTriggerEnter(Collider col){
	//all projectile colliding game objects should be tagged "Enemy" or whatever in inspector but that tag must be reflected in the below if conditional
	if(col.gameObject.tag == "shield")
	{
		Destroy(col.gameObject);
		//add an explosion or something
		//destroy the projectile that just caused the trigger collision
		Destroy(gameObject);
	}
	else{
		Destroy(gameObject, lifespan);
	}
}

}

//Instantiate(explosion,transform.position,transform.rotation);

