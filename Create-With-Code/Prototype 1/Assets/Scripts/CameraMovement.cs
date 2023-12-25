using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject toFollow;
    Vector3 offset = new Vector3(0, 7.7f, -7.25f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = toFollow.transform.position + offset;
    }
}
