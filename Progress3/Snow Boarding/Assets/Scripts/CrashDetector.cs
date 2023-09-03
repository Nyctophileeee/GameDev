using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float crashDelay;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    bool isPlay = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground")
        {
            CrashPlayer();
        }
    }

    void CrashPlayer()
    {
       if(!isPlay)
       {
            isPlay = true;
            FindAnyObjectByType<PlayerController>().DisableControl();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", crashDelay);
       }

    }

    void ReloadScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
