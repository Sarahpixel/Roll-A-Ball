using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObjects : MonoBehaviour
{
    public float waitTime = 5;
    public float speed = 10;
    bool rotated=false;
    Vector3 startRotation;
    public Vector3 toRotation = new Vector3 (0, 90, 0);
    public Vector3 rotationAxis;
    public float rotationSpeed;

    private void start()
    {
        startRotation= transform,eulerAngles;
        StartCoroutine(Rotate));
    }

    IEnumerator Rotate()
    {
        Vector3 newRot = rotated ? startRotation : toRotation;
        var toAngle = Quaternion.Euler(newRot);
        while (transform.rotation != toAngle)
        {
            transform.rotation= Quaternion,RotateTowards(transform.rotation, toAngle, speed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitSeconds(waitTime);
        rotated = !rotated;
        StartCoroutine(Rotate));
    }

    void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * waitTime.deltaTime);

    }
}
