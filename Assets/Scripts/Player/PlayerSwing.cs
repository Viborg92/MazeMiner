using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player swing.
/// Handles the attack of the player, check if the left mouse button has been pushed the executes a swing.
/// </summary>
public class PlayerSwing : MonoBehaviour
{
    [SerializeField, Tooltip("The child on the playerpref called AxeArm")]
    private Transform axeTransform;
    [SerializeField, Tooltip("The speed of the pickaxe when swinged")]
    private float swingSpeed;
    [SerializeField, Tooltip("The time before the axe returns to the orginal rotation")]
    private float timeBeforeReturn = 1;
    [SerializeField, Tooltip("The time it takes to return to the orginal postion")]
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