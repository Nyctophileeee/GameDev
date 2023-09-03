using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] float boostSpeed;
    [SerializeField] ParticleSystem minorCrash;
    [SerializeField] ParticleSystem fireEffect;
    [SerializeField] AudioClip hornSFX;
    float steerAmount;
    float moveAmount;
    
    bool canMove = true;

    void Update()
    {   
        KeyResponse();
        if(canMove)
        {
            steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
            moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
            transform.Rotate(0, 0, -steerAmount);
            transform.Translate(0, moveAmount, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Itai!!!");
        moveSpeed = moveSpeed - 3;
        CrashDetector(); 
        if(moveSpeed == 0)
        {
            canMove = false;
        }  
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Boost")
        {
            Debug.Log("Boosted");
            moveSpeed = boostSpeed;
        }
    }

    void KeyResponse()
    {
       if(Input.GetKey(KeyCode.R))
       {
            SceneManager.LoadScene("Level1");   
       }
       else if(Input.GetKey(KeyCode.H))
       {
            FindObjectOfType<AudioSource>().PlayOneShot(hornSFX);
       }
    }

    void CarMovement()
    {
        steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void CrashDetector()
    {
        if(moveSpeed == 3)
        {
            minorCrash.Play();
        }
        else if (moveSpeed == 0)
        {
            fireEffect.Play();
            minorCrash.Stop();
        }
    }
}
