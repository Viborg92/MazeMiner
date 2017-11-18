using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
    [SerializeField]
    private GameObject Arm;

    void Attack()
    {
        Arm.transform.Rotate(Vector3.right * Time.deltaTime);
    }


}
