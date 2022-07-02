using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Random;

public class QuestionMaster : MonoBehaviour {

    //varibles for question display
    public string answer;
    public int totalCorrect = 0;
    public int totalQuestions = 0;

    public QuestionSets2 ques;

    //game object variables
    public string input = " ";
    //public GameObject inputField;
    public InputField yourInputField;
    public Text textDisplay;

    public GameObject gameOver;
    public GameObject questionScreen;
    public GameObject win;
    public GameObject pause;
    private bool trigger = false;

    public void Update()
    {
        if ((Input.GetKeyDown("enter") || Input.GetKey("return")) && questionScreen.active == true)
        {
            inputNumCheck();
        }
    }

    public void inputNumCheck()
    {
        input = yourInputField.text.Trim();
        
        if (input.Equals(answer.ToString()) == true)
        {
            //access time set normal 
            Time.timeScale = 1f;
            questionScreen.SetActive(false);
            //tally correct answer
            totalCorrect++;
            trigger = false;
        }
        else
        {
            //turn off controls for user
            questionScreen.SetActive(false);
            gameOver.SetActive(true);
        }

        //increment questions
        totalQuestions++;
    }

    public void displayQuestion(string question) 
    {
        textDisplay.text = question.ToString();
        
    }

    public void QuestionCheck()
    {
        if (Time.timeScale == 0f && trigger == false && gameOver.active == false && win.active == false && pause.active == false)
        {

            GenerateQuestions();
            questionScreen.SetActive(true);
            trigger = true;
            yourInputField.ActivateInputField();
            yourInputField.text = "";

        }

    }
        
    void GenerateQuestions() {

        string answerQuestion;
        string question;

        string temp = ques.questionQueue.Dequeue();
        Debug.Log("temp " + temp);

        answerQuestion = temp.Substring(0, temp.IndexOf("!"));

        question = temp.Substring(temp.IndexOf("!")+1);

        answer = answerQuestion.Trim();
        
        Debug.Log("answer " + answerQuestion);
        Debug.Log("question " + question);

        //display question
        displayQuestion(question);
    }


} 
        
    