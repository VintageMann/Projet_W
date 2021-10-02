using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Projectile : MonoBehaviour
{
   public GameObject explosion;
   void OnCollisionEnter()
   {
       Instantiate(explosion,transform.position,transform.rotation);
       Destroy(gameObject);
   }
}

