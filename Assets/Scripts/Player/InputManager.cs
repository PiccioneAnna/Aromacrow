using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class InputManager : MonoBehaviour
    {
        // Components
        private Rigidbody2D rb;

        // Stats
        private float speed;
        public float walkSpeed = 2f;
        public float runSpeed = 3.5f;

        // Input
        float inputH;
        float inputV;


        // Start is called before the first frame update
        void Start()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            inputH = Input.GetAxisRaw("Horizontal");
            inputV = Input.GetAxisRaw("Vertical");

            // Check for sprint
            speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        }

        void FixedUpdate()
        {
            rb.velocity = new Vector2(inputH, inputV).normalized * speed;
        }
    }
}

