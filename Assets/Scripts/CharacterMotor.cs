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
            Vector2 targetPosition = (Vector2)transform.position + Input * (StopMovement ? 0 : MoveSpeed) * Time.deltaTime;
            Vector2 targetVelocity = (targetPosition - (Vector2)transform.position + ForceDirection) / Time.deltaTime;
            transform.Translate(targetVelocity);
            //_rb.velocity = new Vector2(targetVelocity.x,targetVelocity.y);


            //_rb.MovePosition(transform.position + (Vector3)(Input * MoveSpeed) * Time.deltaTime);
            //var newPosition = transform.position + (Vector3)(Input * MoveSpeed) * Time.deltaTime;
            //newPosition = new Vector3(Round(newPosition.x), Round(newPosition.y));
            //Debug.Log(transform.p);
            //transform.position = newPosition;
        }

        private void Update()
        {
            //UpdateMotor();

        }

        private void FixedUpdate()
        {
            //_rb.MovePosition(transform.position + (Vector3)(Input * MoveSpeed) * Time.fixedDeltaTime);
            Vector2 targetPosition = _rb.position + Input * (StopMovement ? 0 : MoveSpeed) * Time.fixedDeltaTime;
            _rb.MovePosition(targetPosition);
            //Vector2 targetVelocity = (targetPosition - (Vector2)transform.position + ForceDirection) / Time.fixedDeltaTime;
            //_rb.velocity = targetVelocity;
            if (CamBrain)
                CamBrain.ManualUpdate();
        }

        private void Awake()
        {
            //_rb.AddForce(new Vector2(2f,0), ForceMode2D.Impulse);
            //FollowPlayer.Instance.MyPlayer = transform;
        }
    }
}