using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class starFacts : MonoBehaviour
{
    public GameObject textObject;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
          // Get mesh renderer
          MeshRenderer meshRenderer = textObject.GetComponent<MeshRenderer>();
          if(meshRenderer != null)
          {
            meshRenderer.enabled = true; 
          }
          else
          {
            Debug.Log("Mesh renderer not found");
          }
        
        }
    }
}
