using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed;
    [SerializeField] float moveSpeed;   
    [SerializeField] float slowSpeed;
    [SerializeField] float boostSpeed;
    float steerAmount;
    float moveAmount;

    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }


    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Itai!!!");
        moveSpeed = slowSpeed;        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Boost")
        {
            Debug.Log("Boosted");
            moveSpeed = boostSpeed;
        }
    }
}
