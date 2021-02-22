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

        private Vector2 PixelPerfectClamp(Vector2 moveVector, float pixelsPerUnit)
        {
            Vector2 vectorInPixels = new Vector2(
                Mathf.RoundToInt(moveVector.x * pixelsPerUnit),
                Mathf.RoundToInt(moveVector.y * pixelsPerUnit));

            Debug.Log("Clamp X: " + vectorInPixels.x + " into " + vectorInPixels.x / pixelsPerUnit);
            Debug.Log("Clamp Y: " + vectorInPixels.y + " into " + vectorInPixels.y / pixelsPerUnit);
            return vectorInPixels / pixelsPerUnit;
        }

        private void FixedUpdateMotor()
        {
            //_rb.velocity = Input * MoveSpeed;
            //var newPosition = PixelPerfectClamp(_rb.position + Input * MoveSpeed * Time.fixedDeltaTime,64);
            //_rb.MovePosition(newPosition);

            var newPosition = _rb.position + Input * MoveSpeed * Time.fixedDeltaTime;
            if (Input == Vector2.zero)
                newPosition = PixelPerfectClamp(newPosition, 64);
            _rb.MovePosition(newPosition);

            if (CamBrain)
                CamBrain.ManualUpdate();
        }

        private void FixedUpdate()
        {
            FixedUpdateMotor();
        }

        private void Awake()
        {
            //_rb.AddForce(new Vector2(2f,0), ForceMode2D.Impulse);
            //FollowPlayer.Instance.MyPlayer = transform;
        }
    }
}