using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingRocks : MonoBehaviour
{

    [Header("---Floating Rocks---")]
    public float rotationSpeed; 
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
        // Rotate rocks at that position
        transform.Rotate(Vector3.up, rotationSpeed + Time.deltaTime);
    }
}
