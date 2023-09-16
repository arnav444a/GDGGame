using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void ShakeSmall()
    {
        StartCoroutine(Shake(0.3f, 0.3f));
    }
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = new Vector3(0, 0, -10);
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.fixedDeltaTime;

            float xOffset = Random.Range(-0.5f, 0.5f) * magnitude;
            float yOffset = Random.Range(-0.5f, 0.5f) * magnitude;

            transform.localPosition = new Vector3(xOffset, yOffset, originalPos.z);

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
