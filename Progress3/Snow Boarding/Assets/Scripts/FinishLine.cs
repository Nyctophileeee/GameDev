using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float finishDelay;
    [SerializeField] ParticleSystem finishEffect;
    [SerializeField] public float moneyCount;
    [SerializeField] Color32 enoughMoney;
    [SerializeField] Color32 finishGame;

    [SerializeField] GameObject boxPart;
    [SerializeField] GameObject circlePart;
    SpriteRenderer colorLine;
    SpriteRenderer colorCircle;

    bool hasMoney;
    bool hasCompleted;
    

    void Start()
    {
        colorLine = boxPart.GetComponent<SpriteRenderer>();
        colorCircle = circlePart.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        ObjectiveClear();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player" && hasMoney)
        {
            hasCompleted = true;
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", finishDelay);
        }   
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(hasCompleted == true)
        {
            Debug.Log("Yow");
            colorCircle.color = finishGame;
            colorLine.color = finishGame;
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene("Level1");
    }

    void ObjectiveClear()
    {
        MoneyCount();
        if(hasMoney == true)
        {
            colorCircle.color = enoughMoney;
            colorLine.color = enoughMoney;
        }
    }

    void MoneyCount()
    {
        if(moneyCount == 12)
        {
            hasMoney = true;
        }
    }
}
