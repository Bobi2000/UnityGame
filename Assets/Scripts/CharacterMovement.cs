using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public int MovementSpeed = 10;

    private Rigidbody2D RigidBody;

    public void Awake()
    {
        this.RigidBody = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        float moveVectorX = Input.GetAxis("Horizontal");
        float moveVectorY = Input.GetAxis("Vertical");
        
        this.transform.Translate(moveVectorX * this.MovementSpeed * Time.deltaTime, moveVectorY * this.MovementSpeed * Time.deltaTime, 0f);
    }
}
