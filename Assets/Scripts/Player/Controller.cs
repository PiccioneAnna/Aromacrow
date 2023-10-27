using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Controller : MonoBehaviour
    {

        #region Fields

        // Components
        private Rigidbody2D rb;
        private Animator animator;

        // Tilemap
        [SerializeField] TilemapMarkerManager tilemapMarkerManager;
        [SerializeField] TilemapReader tileMapReader;
        Vector3Int selectedTilePosition;
        public bool useGrid = false;

        // Animation states
        string currentState;
        const string GROUND_IDLE = "Crow_Ground_Idle";
        const string GROUND_LEFT = "Crow_Ground_Left";
        const string GROUND_RIGHT = "Crow_Ground_Right";
        const string GROUND_UP = "Crow_Ground_Up";
        const string GROUND_DOWN = "Crow_Ground_Down";
        const string AIR_LEFT = "Crow_Air_Left";
        const string AIR_RIGHT = "Crow_Air_Right";
        const string AIR_UP = "Crow_Air_Up";
        const string AIR_DOWN = "Crow_Air_Down";

        // Stats
        private float speed;
        public float walkSpeed = 2f;
        public float runSpeed = 3.5f;

        public bool isFly;

        // Input
        float inputH;
        float inputV;

        #endregion

        #region Runtime
        // Start is called before the first frame update
        void Start()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
            animator = gameObject.GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            inputH = Input.GetAxisRaw("Horizontal");
            inputV = Input.GetAxisRaw("Vertical");

            // Check for states
            speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
            isFly = Input.GetKeyDown(KeyCode.Space) ? !isFly : isFly;

        }

        void FixedUpdate()
        {
            rb.velocity = new Vector2(inputH, inputV).normalized * speed;

            string tempState = DetermineAnimationState(inputH, inputV);

            ChangeAnimationState(tempState);
        }
        #endregion

        #region Animation
        private string DetermineAnimationState(float inputH, float inputV)
        {
            // Seperate states for fly and ground modes
            if (!isFly)
            {
                if (inputH == 0 && inputV == 0) { return GROUND_IDLE; }
                if (inputH < 0) { return GROUND_LEFT; }
                if (inputH > 0) { return GROUND_RIGHT; }
                if (inputV < 0) { return GROUND_DOWN; }
                if (inputV > 0) { return GROUND_UP; }
            }
            else
            {
                if (inputH < 0) { return AIR_LEFT; }
                if (inputH > 0) { return AIR_RIGHT; }
                if (inputV < 0) { return AIR_DOWN; }
                if (inputV > 0) { return AIR_UP; }
            }

            return currentState;
        }

        public void ChangeAnimationState(string newState)
        {
            if (newState == currentState) return;

            animator.Play(newState);

            currentState = newState;
        }
        #endregion

    }
}

