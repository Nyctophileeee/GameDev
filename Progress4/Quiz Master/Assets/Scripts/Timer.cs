using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
   
    [SerializeField] float questionTimer;
    [SerializeField] float answerTimer;
    float timeValue;   
    public bool isAnsweringQuestion = false;
    public bool loadNextQuestion;
    public float fillFraction;


    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer()
    {   
        timeValue -= Time.deltaTime;
        if(isAnsweringQuestion)
        {
            if(timeValue > 0)
            {
                fillFraction = timeValue / questionTimer;
            }
            else
            {
                isAnsweringQuestion = false;
                timeValue = answerTimer;
            }
        }
        else
        {
            if(timeValue > 0)
            {
                fillFraction = timeValue / answerTimer;
            }
            else
            {
                isAnsweringQuestion = true;
                timeValue = questionTimer;
                loadNextQuestion = true;
            }
        }

        Debug.Log($"{isAnsweringQuestion} {timeValue} : {fillFraction}, {loadNextQuestion}");
    }

    public void CancelTimer()
    {
        timeValue = 0;
    }


}
