using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float lifespan;
	void Start(){  
		Destroy(gameObject, lifespan);
	}

    void OnTriggerEnter2D(Collider2D col){       
		if(col.gameObject.name == "bullet"){
			Destroy(GameObject.FindGameObjectWithTag("bullet"));
			Destroy(gameObject);
		}
 	}
}
