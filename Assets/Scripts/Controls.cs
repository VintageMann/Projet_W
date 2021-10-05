using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controls : MonoBehaviour {
    PlayerControls controls;

    public Character player;
    public Vortex vortex;
    public Rigidbody bullet;
    public Rigidbody shield;

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
        bulletClone.transform.position = this.transform.position;
        bulletClone.transform.forward = new Vector3(aimInput.x, 0, aimInput.y);
    	bulletClone.GetComponent<Rigidbody>().AddForce(bulletClone.transform.forward * 1000);
    }

    public void OnShield(InputAction.CallbackContext ctx) {
        Rigidbody shieldClone = Instantiate(shield);
        shieldClone.transform.position = this.transform.position;
        shieldClone.transform.forward = new Vector3(aimInput.x, 0, aimInput.y);
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

    IEnumerator Cooldown() {
        float t = 1f; 
        controls.Player.Disable();
        while (t > 0) {
            t -= Time.deltaTime;
            yield return null;
        }
        controls.Player.Enable();
    }
}

