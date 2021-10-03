using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Projectile : MonoBehaviour{
	public GameObject explosion;
	public float lifespan;

   void Start(){  
       Destroy(gameObject, lifespan);
   }
   public void setDirection(Vector2 direction) {
       
   }
}

//Instantiate(explosion,transform.position,transform.rotation);

