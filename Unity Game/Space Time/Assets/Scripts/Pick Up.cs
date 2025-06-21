using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
   // [SerializeField] AudioSource aud;
    [SerializeField] AudioClip pickUp;
    [SerializeField] float pickUpVol;
    public bool isPlaying = false;

   private void OnTriggerEnter(Collider collider) 
    {
        if(collider.gameObject.tag == "Player")
        {
            SoundManager.instance.soundTrackAud.PlayOneShot(pickUp, pickUpVol);
            isPlaying = true;
            Debug.Log("Star picked up");
            Debug.Log("Played SOUND");
            Destroy (gameObject);
            //StartCoroutine(DestroyAfterDelay(1.0f));
        }
    }

    private IEnumerator DestroyAfterDelay(float delay)
{
    yield return new WaitForSeconds(delay);
    Destroy(gameObject);
}
}
