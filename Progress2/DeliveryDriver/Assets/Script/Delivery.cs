using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32();
    [SerializeField] Color32 noPackageColor = new Color32();
    [SerializeField] float timeToDestroy;
    bool hasPackage;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package Pickup!");
            hasPackage = true;
            Destroy(other.gameObject, timeToDestroy);
            spriteRenderer.color = hasPackageColor;
        }

        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package Recevied!");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
