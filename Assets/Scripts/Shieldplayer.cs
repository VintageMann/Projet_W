using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shieldplayer : MonoBehaviour{
	public Rigidbody player;
    public Rigidbody shield;
    PlayerControls controls;
    Vector2 aim;
    

    void Awake(){
        controls = new PlayerControls();
        controls.Player.Shield.performed += ctx => SpawnShield();
        controls.Player.Aim.performed += ctx => aim = ctx.ReadValue<Vector2>().normalized;
    }

    public void SpawnShield(){
    	Rigidbody newShield = Instantiate(shield);
        newShield.transform.position = player.transform.position;
        float degree = Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg;
        //bulletClone.transform.Rotate(0, degree, 0);
        newShield.transform.forward = new Vector3(aim.x, 0, aim.y);
    }

    void OnEnable(){
        controls.Player.Enable();
    }

    void OnDisable(){
        controls.Player.Disable();
    }
}
