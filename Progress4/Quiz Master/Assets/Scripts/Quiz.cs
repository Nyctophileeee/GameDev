using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;

    [Header("Answer Buttons")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;

    [Header("Button Color")]
    [SerializeField] Sprite defaultColorSprite;
    [SerializeField] Sprite correctColorSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;
    
    
    void Start()
    {   
        timer = FindObjectOfType<Timer>();
        GetNextQuestion();
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if(timer.loadNextQuestion)
        {
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
    }

    public void OnAnswerSelected(int index)
    {
        if(index == question.GetCorrectAnswerIndex())
        {
            string rightAns = question.GetAnswer(question.GetCorrectAnswerIndex());
            questionText.text = $"Correcct! {rightAns} is what you find in every rainbow.";
            Image temporaryColor = answerButtons[index].GetComponent<Image>();
            temporaryColor.sprite = correctColorSprite;
        }
        else
        {
            string rightAns = question.GetAnswer(question.GetCorrectAnswerIndex());
            questionText.text = $"Wrong! {rightAns} is what you find in every rainbow.";
            Image temporaryColor = answerButtons[question.GetCorrectAnswerIndex()].GetComponent<Image>();
            temporaryColor.sprite = correctColorSprite;
        }
        SetButtonState(false);
        timer.CancelTimer();
    }

    void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprite();
        DisplayQuestion();
    }


    void DisplayQuestion()
    {
        questionText.text = question.GetQuestion();
        for(int i = 0; answerButtons.Length > i; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }

    void SetButtonState(bool state)
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Button ansButton = answerButtons[i].GetComponent<Button>();
            ansButton.interactable = state;
        }
    }

    void SetDefaultButtonSprite()
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Image imgButton = answerButtons[i].GetComponent<Image>();
            imgButton.sprite = defaultColorSprite;
        }
    }


}   
