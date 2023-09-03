using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float baseSpeed;
    [SerializeField] float boostSpeed;

    float tempCount;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindAnyObjectByType<SurfaceEffector2D>();
    }

    void Update() 
    {
        if(canMove)
        {
            RotatePlayer();
            Boost();
        }
        ShrctKey();

    }

    public void DisableControl()
    {
        canMove = false;
    }

    void Boost()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else surfaceEffector2D.speed = baseSpeed;
    }

    void RotatePlayer()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }

    void ShrctKey()
    {
        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("Level1");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Money")
        {
            Debug.Log("Gotcha!");
            Destroy(other.gameObject, 0.1f);
            tempCount = FindObjectOfType<FinishLine>().moneyCount + 1;
            FindObjectOfType<FinishLine>().moneyCount = tempCount;
        }
    }
}