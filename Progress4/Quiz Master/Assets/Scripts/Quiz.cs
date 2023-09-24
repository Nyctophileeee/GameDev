using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButtons;
    [SerializeField] Sprite defaultColorSprite;
    [SerializeField] Sprite correctColorSprite;
    int correctAnswerIndex;
    
    

    void Start()
    {
        questionText.text = question.GetQuestion();
        for(int i = 0; answerButtons.Length > i; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
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
    }
}
