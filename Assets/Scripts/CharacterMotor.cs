using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedstoneHallows
{
    public class CharacterMotor : MonoBehaviour
    {
        public bool StopMovement;
        public float MoveSpeed;

        [SerializeField] private Rigidbody2D _rb;

        public Vector2 Input;
        protected Vector2 ForceDirection = Vector2.zero;

        public CinemachineBrain CamBrain;

        public virtual void AddForce(Vector2 force)
        {
            force = force / _rb.mass;
            if (force.magnitude < 0)
                force = Vector3.zero;
            ForceDirection += force;
        }



        private void UpdateMotor()
        {
            //Vector2 targetPosition = (Vector2)transform.position + Input * (StopMovement ? 0 : MoveSpeed) * Time.deltaTime;
            //Vector2 targetVelocity = (targetPosition - (Vector2)transform.position + ForceDirection) / Time.deltaTime;
            //transform.Translate(targetVelocity);

            Vector2 targetPosition = (Vector2)transform.position + Input * (StopMovement ? 0 : MoveSpeed) * Time.deltaTime;
            transform.position = targetPosition;
        }

        private void FixedUpdateMotor()
        {
            //_rb.MovePosition(transform.position + (Vector3)(Input * MoveSpeed) * Time.fixedDeltaTime);
            Vector2 targetPosition = _rb.position + Input * (StopMovement ? 0 : MoveSpeed) * Time.fixedDeltaTime;
            //_rb.MovePosition(targetPosition);
            Vector2 targetVelocity = (targetPosition - (Vector2)transform.position + ForceDirection) / Time.fixedDeltaTime;
            _rb.velocity = Input * MoveSpeed;
            if (CamBrain)
                CamBrain.ManualUpdate();
        }

        private void Update()
        {
            UpdateMotor();

        }

        private void FixedUpdate()
        {
            //FixedUpdateMotor();
        }

        private void Awake()
        {
            //_rb.AddForce(new Vector2(2f,0), ForceMode2D.Impulse);
            //FollowPlayer.Instance.MyPlayer = transform;
        }
    }
}