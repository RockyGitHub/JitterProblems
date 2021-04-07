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
        public bool PixelSnap;


        [SerializeField] private Rigidbody2D _rb;

        public Vector2 Input;

        public CinemachineBrain CamBrain;

        private Vector2 PixelPerfectClamp(Vector2 moveVector, float pixelsPerUnit)
        {
            Vector2 vectorInPixels = new Vector2(
                Mathf.RoundToInt(moveVector.x * pixelsPerUnit),
                Mathf.RoundToInt(moveVector.y * pixelsPerUnit));

            //Debug.Log("Clamp X: " + vectorInPixels.x + " into " + vectorInPixels.x / pixelsPerUnit);
            //Debug.Log("Clamp Y: " + vectorInPixels.y + " into " + vectorInPixels.y / pixelsPerUnit);
            return vectorInPixels / pixelsPerUnit;
        }

        private void FixedUpdateMotor()
        {
            var newPosition = _rb.position + Input * MoveSpeed * Time.fixedDeltaTime;
            if (PixelSnap)
                newPosition = PixelPerfectClamp(newPosition, 128);
            _rb.MovePosition(newPosition);

            if (CamBrain)
                CamBrain.ManualUpdate();

            if (Input == Vector2.zero)
            {
                _rb.MovePosition(newPosition.PixelPerfect());
            }
        }

        private void Update()
        {
            //_rb.position = PixelPerfectClamp(_rb.position,32);
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