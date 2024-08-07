using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements.Experimental;

public class Paddle : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float moveSpeed = 2f;
    private Vector3 startPosition;
    private bool activePaddles = true;

    /*
    private void Start() {
        //save start position
        startPosition = transform.position;
        //add resetPositon as a listener, will be called when onReset is called
        GameManager.instance.onReset += ResetPosition;
         GameManager.instance.gameUI.onStartGame += ActivatePaddles;
    }
    */


    private void Update() {
        float movement = ProcessInput();
        //if (activePaddles == true) {
            Move(movement);
        //}
    }

    private void Move(float value) {
        //rb2d.velocity.y = value * moveSpeed; -- classic unity :/
        Vector2 velo = rb2d.velocity;
        velo.x = moveSpeed * value;
        rb2d.velocity = velo;
    }

    private float ProcessInput() {
        float movement;
        movement = Input.GetAxis("MovePlayer");
        return movement;
    }

    private void ActivatePaddles() {
        activePaddles = true;
    }

    public void DeactivatePaddles() {
        activePaddles = false;
    }
}
