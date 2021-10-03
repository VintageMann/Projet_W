using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireprojectile : MonoBehaviour
{
    public Rigidbody player;
	public float bulletSpeed = 10;
	public Rigidbody bullet;
    public float wait = 500;
    PlayerControls controls;
    public float cooldown;
    Vector2 aim;


    void Awake(){
        controls = new PlayerControls();
        controls.Player.Fire.performed += ctx => Fire();
        controls.Player.Aim.performed += ctx => aim = ctx.ReadValue<Vector2>().normalized;
    }
    void OnEnable(){
        controls.Player.Enable();
    }

    void OnDisable(){
        controls.Player.Disable();
    }

    void Fire(){
    	Rigidbody bulletClone = Instantiate(bullet);
        Debug.Log(bulletClone.transform.forward);
        bulletClone.transform.position = player.transform.position;
        float degree = Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg;
        //bulletClone.transform.Rotate(0, degree, 0);
        bulletClone.transform.forward = new Vector3(aim.x, 0, aim.y);
        Debug.Log(bulletClone.transform.forward);
    	bulletClone.GetComponent<Rigidbody>().AddForce(bulletClone.transform.forward * 1000);
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



}