using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerRotation : MonoBehaviour
{
    float rotationSpeed = 800;
    
    void Update()
    {
        transform.Rotate(Vector3.back, Time.deltaTime * rotationSpeed);
    }
}
