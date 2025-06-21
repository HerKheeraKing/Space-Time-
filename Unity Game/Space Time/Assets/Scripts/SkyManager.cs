using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class SkyManager : MonoBehaviour
{
    // Sky speed
    public float skySpeed; 
    public VolumeProfile volumeProfile;
    private HDRISky hDRISky;


    void Start()
    {
        // Does profile contain a hdri sky override
       if(volumeProfile != null && volumeProfile.TryGet(out hDRISky))
       {
        // Set up hdri
           hDRISky.rotation.overrideState = true;
       }
       else
       {
          Debug.Log("HDRI sky override not found in volume profile");
       }
    }

    // Update is called once per frame
    void Update()
    {
        if(hDRISky != null)
        {
          // Update each frame for sky speed
          hDRISky.rotation.value =  Time.time * skySpeed; 
        }
        
    }
}
