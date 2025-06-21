using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingStars : MonoBehaviour
{
    [Header("---Bouncing Stars---")]
    public float bounceSpeed; 
    public float bounceHeight; 
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        // Get current position
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // New Y position 
        float posY = startPos.y + Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        // Rotate rocks at that position
        transform.position = new Vector3(startPos.x, posY, startPos.z);
    }
}
