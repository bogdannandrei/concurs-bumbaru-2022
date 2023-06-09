using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
   public List<QuestionsAndAnswers> QnA;
   public GameObject[] options;
   public int currentQuestion;

   public TMP_Text QuestionTxt;

    private void Start()
    {
        generateQuestion();
    }
    
    public void correct()
    {
        QnA.RemoveAt(currentQuestion);
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestion].Answers[i];    
            if(QnA[currentQuestion].CorrectAnswer==i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if(QnA.Count > 0)
        {
            currentQuestion = Random.Range(0,QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;

            SetAnswers();
        }
        else
        {
            Debug.Log("Out of questions");
        }
        

    }
}
