using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    [SerializeField] PlatformController platformController;
    Rigidbody ballBody;

    void Start()
    {
        ballBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // use the MapRange function to re-map the y position of the ball from it's current
        // min/max values into the min/max values of our servos.
    }

    public static float MapRange(float val, float oldMin, float oldMax, float newMin, float newMax)
    {
        float slope = (newMax - newMin) / (oldMax - oldMin);
        float newVal = newMin + slope * (val - oldMin);
        return Mathf.Clamp(newVal, Mathf.Min(newMin, newMax), Mathf.Max(newMin, newMax));
    }

    private void OnMouseUp()
    {
        ballBody.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
    }
}
