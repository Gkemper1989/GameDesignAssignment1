using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variables
    [SerializeField] float speed = 10.0f;
    private float horizontalInput;
    private float verticalInput;

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector2.down * speed * Time.deltaTime * horizontalInput);
        transform.Translate(Vector2.right * speed * Time.deltaTime * verticalInput);
    }
}
