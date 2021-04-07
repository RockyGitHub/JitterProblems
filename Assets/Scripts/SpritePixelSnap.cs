using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePixelSnap : MonoBehaviour
{
    public Rigidbody2D RB;
    private void LateUpdate()
    {
        transform.position = RB.position.PixelPerfect();
    }
}
