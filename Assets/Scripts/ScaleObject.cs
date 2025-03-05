using UnityEngine;
using System.Collections;

public class ScaleObject : MonoBehaviour
{
    public float scaleFactor = 1.3f;
    public float scaleSpeed = 1f;

    private Vector3 initialScale;

    void Awake()
    {
        initialScale = transform.localScale;

        StartCoroutine(ScaleOverTime());
    }

    IEnumerator ScaleOverTime()
    {
        while (true)
        {
            Vector3 targetScale = initialScale * scaleFactor;
            float timer = 0f;
            while (timer < 1f)
            {
                timer += Time.deltaTime * scaleSpeed;
                transform.localScale = Vector3.Lerp(initialScale, targetScale, timer);
                yield return null;
            }

            timer = 0f;
            while (timer < 1f)
            {
                timer += Time.deltaTime * scaleSpeed;
                transform.localScale = Vector3.Lerp(targetScale, initialScale, timer);
                yield return null;
            }
        }
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    void OnEnable()
    {
        StartCoroutine(ScaleOverTime());
    }
}
