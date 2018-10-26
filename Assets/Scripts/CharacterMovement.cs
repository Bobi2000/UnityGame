﻿using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public int MovementSpeed = 10;

    private Rigidbody2D RigidBody;

    public Animator CharacterAnim;

    public void Awake()
    {
        this.RigidBody = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {


            float moveVectorX = Input.GetAxis("Horizontal");
            float moveVectorY = Input.GetAxis("Vertical");

            if (Input.GetKey(KeyCode.S) && !CharacterAnim.GetBool("IsDown"))
            {
                CharacterAnim.SetBool("IsDown", true);
            }
            else
            {
                CharacterAnim.SetBool("IsDown", false);
            }

            if (Input.GetKey(KeyCode.W) && !CharacterAnim.GetBool("IsUp"))
            {
                CharacterAnim.SetBool("IsUp", true);
            }
            else
            {
                CharacterAnim.SetBool("IsUp", false);
            }

            if (Input.GetKey(KeyCode.A) && !CharacterAnim.GetBool("IsLeft"))
            {
                CharacterAnim.SetBool("IsLeft", true);
            }
            else
            {
                CharacterAnim.SetBool("IsLeft", false);
            }

            if (Input.GetKey(KeyCode.D) && !CharacterAnim.GetBool("IsRight"))
            {
                CharacterAnim.SetBool("IsRight", true);
            }
            else
            {
                CharacterAnim.SetBool("IsRight", false);
            }

            this.transform.Translate(moveVectorX * this.MovementSpeed * Time.deltaTime, moveVectorY * this.MovementSpeed * Time.deltaTime, 0f);
        }
    }
}
