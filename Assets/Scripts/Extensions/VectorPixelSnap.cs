using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorPixelSnap
{
    public static int PPU = 64;
    public static Vector2 PixelPerfect(this Vector2 vector)
    {
        //int pixelsPerUnit = UniversalSettings.PixelsPerUnit;
        Vector2 vectorInPixels = new Vector2(
            Mathf.Round(vector.x * PPU),
            Mathf.Round(vector.y * PPU));

        var debug = false;
        if (debug)
        {
            Debug.Log("original vector: " + vector.x + " " + vector.y);
            Debug.Log("Clamp X: " + vectorInPixels.x + " into " + vectorInPixels.x / PPU);
            Debug.Log("Clamp Y: " + vectorInPixels.y + " into " + vectorInPixels.y / PPU);
        }
        return vectorInPixels / PPU;
    }

    public static Vector3 PixelPerfect(this Vector3 vector)
    {
        //int pixelsPerUnit = UniversalSettings.PixelsPerUnit;
        Vector3 vectorInPixels = new Vector3(
            Mathf.RoundToInt(vector.x * PPU),
            Mathf.RoundToInt(vector.y * PPU),
            Mathf.Round(vector.z * PPU));

        //Debug.Log("Clamp X: " + vectorInPixels.x + " into " + vectorInPixels.x / pixelsPerUnit);
        //Debug.Log("Clamp Y: " + vectorInPixels.y + " into " + vectorInPixels.y / pixelsPerUnit);
        return vectorInPixels / PPU;
    }
}
