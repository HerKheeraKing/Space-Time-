using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    [Header("Asteroid Movement")]
    
    public float rotationSpeed;
    public float floatSpeed;
    public float floatRange;
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
        // Rotation of the asteroids
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Floating asteroid
        float newPos = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatRange;
        transform.position = new Vector3(transform.position.x, newPos, transform.position.z);
    }
}
