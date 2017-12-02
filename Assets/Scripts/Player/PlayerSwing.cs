using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
    [SerializeField]
    private Transform axeTransform;
    [SerializeField]
    private float swingSpeed;
    [SerializeField]
    private float timeBeforeReturn = 1;
    [SerializeField]
    private float returnTime = 1;

    private float speed;

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StopAllCoroutines();
            StartCoroutine(Swing());
        }
    }

    IEnumerator Swing()
    {
        speed += swingSpeed;
        float localTime = 0;

        while (localTime < timeBeforeReturn)
        {
            yield return null;
            localTime += Time.deltaTime;
            axeTransform.Rotate(0, 0, speed * Time.deltaTime);
        }
        speed = 0;
        localTime = 0;
        float startRotation = axeTransform.transform.localEulerAngles.z;
        while (localTime < returnTime)
        {
            yield return null;
            localTime += Time.deltaTime;
            axeTransform.localEulerAngles = Vector3.forward * Mathf.LerpAngle(startRotation, 0, localTime / returnTime);
        }
    }
}
