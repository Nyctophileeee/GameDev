using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    float cooldown;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnDog();
        }

        cooldown -= Time.deltaTime;
    }

    void SpawnDog()
    {
        if(cooldown <= 0)
        {
            cooldown = 1;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
