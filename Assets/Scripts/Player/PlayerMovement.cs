using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall.Inputs
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 2.0f;
        private Rigidbody playerRB;

        public bool isGrounded = true;
        private void OnCollisionEnter()
        {
            isGrounded = true;
        }

        private void Awake()
        {
            playerRB = GetComponent<Rigidbody>();
        }

        public void CharacterMove(Vector3 movement)
        {
            playerRB.AddForce(movement * speed);
        }

        public void CharacterJump()
        {
            isGrounded = false;
            playerRB.AddForce(new Vector3(0f, 75f, 0f));
        }

    }

}
