using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Projectile : MonoBehaviour{
	public GameObject explosion;
	public float lifespan = 3f;

   void Start(){  
       Destroy(gameObject, lifespan);
   }
}

//Instantiate(explosion,transform.position,transform.rotation);

