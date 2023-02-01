using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    CharacterController PlayerControl;
    Vector3 MoveDirection;
    public float speed = 5;
    private float moveX;
    private float moveZ;

    public bool Grounded = true;
    public float PlayerHeight;
    public float GroundDrag;
    public LayerMask WhatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        PlayerControl = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Grounded = Physics.Raycast(transform.position,Vector3.down,PlayerHeight * 0.5f + 0.2f,WhatIsGround);

        if(Grounded){
            rb.drag = GroundDrag;
        }
        else{
            rb.drag = 0;
        }

     MovementInput();
    }

    private void FixedUpdate() {
        Move();
    }
    void MovementInput(){
       moveX = Input.GetAxisRaw("Horizontal");
       moveZ = Input.GetAxisRaw("Vertical");


    }

    void Move(){
        MoveDirection = transform.right * moveX * speed + transform.forward * moveZ * speed;

        rb.AddForce(MoveDirection.normalized*speed*10f,ForceMode.Force);
    }

    private void OnDrawGizmos() {
        Gizmos.DrawRay(transform.position,Vector3.down*(PlayerHeight*0.5f+0.2f));
        Gizmos.color = Color.blue;
    }
}
