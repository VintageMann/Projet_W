using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Deplacement : MonoBehaviour
{
    PlayerControls controls;
    
    Vector2 move;
    Vector2 aim;
    public float speed;
    public float dashDistance;
    public Vector3 targetRotation;

    void Awake(){
        controls = new PlayerControls();
        controls.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>().normalized;
        controls.Player.Move.canceled += ctx => move = Vector2.zero;
        controls.Player.Dash.performed += ctx => StartCoroutine(Dash());
        controls.Player.Aim.performed += ctx => aim = ctx.ReadValue<Vector2>().normalized;
    }

    void Update(){
        Vector3 m = new Vector3(move.x, 0.0f, move.y) * speed * Time.deltaTime;
        transform.Translate(m, Space.World);
    }

    void OnEnable(){
        controls.Player.Enable();
    }

    void OnDisable(){
        controls.Player.Disable();
    }

    IEnumerator Dash(){
        float duration = 0.2f;
        float time = 0f;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + new Vector3(aim.x, 0, aim.y) * dashDistance;
        while (time < duration) {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;    
    }
}

