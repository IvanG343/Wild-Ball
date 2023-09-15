using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WildBall.Inputs;

namespace WildBall.Inputs
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerInput : MonoBehaviour
    {
        private Vector3 movement;
        private PlayerMovement playerMovement;

        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            float horizontal = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
            float vertical = Input.GetAxis(GlobalStringVars.VERTICAL_AXIS);
            movement = new Vector3(horizontal, 0, vertical).normalized;

            if (Input.GetKeyDown(KeyCode.Space) && playerMovement.isGrounded)
                playerMovement.CharacterJump();
        }

        private void FixedUpdate()
        {
            playerMovement.CharacterMove(movement);
        }

    }

}
