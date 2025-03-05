using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 90f; 

    void Start()
    {
        StartCoroutine(RotateClockwise());
    }

    IEnumerator RotateClockwise()
    {
        while (true)
        {
            float rotationAngle = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.forward, rotationAngle);
            yield return null;
        }
    }
}
