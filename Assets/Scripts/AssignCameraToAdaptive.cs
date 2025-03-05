using UnityEngine;
using System.Collections;

public class AssignCameraToAdaptive : MonoBehaviour
{
    public float checkInterval = 0.5f;

    void Start()
    {
        StartCoroutine(CheckForAdaptiveObject());
    }

    IEnumerator CheckForAdaptiveObject()
    {
        while (true)
        {
            GameObject adaptiveObject = GameObject.FindWithTag("ADAPTIVE");
            if (adaptiveObject != null)
            {
                Camera mainCamera = Camera.main;
                if (mainCamera == null)
                {
                    Debug.LogError("Main camera not found.");
                    yield break;
                }

                Canvas adaptiveCanvas = adaptiveObject.GetComponent<Canvas>();
                if (adaptiveCanvas != null)
                {
                    adaptiveCanvas.worldCamera = mainCamera;
                    Debug.Log("Main camera assigned to the Canvas with tag 'ADAPTIVE'.");
                    yield break;
                }
                else
                {
                    Debug.LogError("Object with tag 'ADAPTIVE' does not have a Canvas component.");
                    yield break;
                }
            }

            yield return new WaitForSeconds(checkInterval);
        }
    }
}
