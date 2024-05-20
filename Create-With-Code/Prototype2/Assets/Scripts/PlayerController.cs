using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 15;
    float horizontalInput;
    [SerializeField] float xRange;
    [SerializeField] GameObject projectilePrefab;

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        FoodSpawn();
    }

    void PlayerMovement()
    {
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput *Time.deltaTime * speed);
    }

    void FoodSpawn()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
