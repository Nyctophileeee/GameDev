using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Itai!!!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Package")
        {
            Debug.Log("Package Pickup!");
            hasPackage = true;
        }

        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package Recevied!");
            hasPackage = false;
        }
    }
}
