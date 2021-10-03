using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controls : MonoBehaviour {
    PlayerControls controls;

    public Character player;
    public Vortex vortex;
    public Rigidbody bullet;

    private Vector2 movementInput;
    private Vector2 aimInput;

    [SerializeField]
    private int playerSpeed;
    [SerializeField]
    private int dashDistance;
    [SerializeField]
    private float channelTime;

    void OnEnable() {
        controls = new PlayerControls();
        controls.Player.Enable();
        vortex = FindObjectOfType<Vortex>();
    }

    void OnDisable() {
        controls.Player.Disable();
    }

    public void OnMove(InputAction.CallbackContext ctx) {
        movementInput = ctx.ReadValue<Vector2>().normalized;
    }

    public void OnAim(InputAction.CallbackContext ctx) {
        aimInput = ctx.ReadValue<Vector2>().normalized;
    }

    public void OnDash(InputAction.CallbackContext ctx) {
        StartCoroutine(Dash());
    }

    public void OnChannel(InputAction.CallbackContext ctx) {
        StartCoroutine(Channel());
    }

    public void OnFire(InputAction.CallbackContext ctx) {
    	Rigidbody bulletClone = Instantiate(bullet);
        bulletClone.transform.position = player.transform.position;
        bulletClone.transform.forward = new Vector3(aimInput.x, 0, aimInput.y);
    	bulletClone.GetComponent<Rigidbody>().AddForce(bulletClone.transform.forward * 1000);
    }

    void Update() {
        Vector3 playerMovement = new Vector3 (movementInput.x, 0, movementInput.y) * playerSpeed * Time.deltaTime;
        transform.Translate(playerMovement);
    }

    IEnumerator Dash(){
        float duration = 0.15f;
        float time = 0f;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + new Vector3(aimInput.x, 0, aimInput.y) * dashDistance;
        while (time < duration) {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;    
    }

    IEnumerator Channel() {
        controls.Player.Disable();
        float ch = channelTime;
        while (ch > 0) {
            ch -= Time.deltaTime;
            yield return null;
        }
        Element recent = vortex.GetRecentElement();
        if (recent != null && player.holding == Element.Elements.Aucun) {
            player.PickElement(vortex.GetRecentElement());
            vortex.DestroyRecetElement();
        }    
        controls.Player.Enable();
    }
}

