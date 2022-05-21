using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private Vector2 target;
    [SerializeField] public float speed;
    public Animator anim;

    private void Awake(){
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update(){
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        body.velocity = new Vector2(body.velocity.x, Input.GetAxis("Vertical") * speed);

        if (horizontalInput > 0.01f){
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f){
            transform.localScale = new Vector3(-1, 1, 1);
        }

        anim.SetBool("run", horizontalInput != 0);

        // Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Debug.Log(mousePos);
    }
}