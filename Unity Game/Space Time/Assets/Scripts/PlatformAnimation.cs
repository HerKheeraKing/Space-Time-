using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAnimation : MonoBehaviour
{
    public void PlatformWalkDown()
    {
        StartCoroutine(WalkCoroutine(-3, 0.5f));
    }
    public void PlatformWalkUp()
    {
        StartCoroutine(WalkCoroutine(5, 0.5f));
    }

    IEnumerator WalkCoroutine(float value, float duration)
    {
        float oldValue = PlatformController.singleton.Heave;
        float currentTime = 0;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float pct = currentTime / duration;
            PlatformController.singleton.Heave = Mathf.Lerp(oldValue, value, pct);
            yield return 0;
        }
    }
}
