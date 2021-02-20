using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedstoneHallows
{
    public class FollowPlayer : MonoBehaviour
    {
        public static FollowPlayer Instance;
        public Transform MyPlayer;

        public float SmoothingRate = 1f;

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            if (MyPlayer == null)
                return;

            float dist = Vector3.Distance(transform.position, MyPlayer.position);
            float rate = Mathf.Max(SmoothingRate, dist * SmoothingRate) * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, MyPlayer.position, rate);
        }
    }
}