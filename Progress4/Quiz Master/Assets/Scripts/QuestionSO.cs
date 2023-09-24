using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor.Search;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{  
    [TextArea(2,6)]
    [SerializeField] string question = "Enter a new question";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnswerIndex;

    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }

    public string GetAnswer(int index)
    {
        return answers[index];
    }

    public string GetQuestion()
    {
        return question;
    }
    
}
