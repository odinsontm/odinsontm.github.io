using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

public class QuestionSets : MonoBehaviour
{
    //To enable or disable each level of question (only availible for teachers, freePlay, and MiniGame)
    public bool addEnabled = true;
    public bool addLvlOne = true;
    public bool addLvlTwo = true;
    public bool addLvlThree = true;
    public bool addLvlFour = true;

    public bool subEnabled = true;
    public bool subLvlOne = true;
    public bool subLvlTwo = true;
    public bool subLvlThree = true;
    public bool subLvlFour = true;

    //Queueing questions for game.
    public Queue<string> questionQueue = new Queue<string>();

    public void Start()
    {
        //need to call setQueue()
        setQueue();
        string q = " ";
        for (int i = 0; i < 26; i++)
        {
            q = questionQueue.Dequeue();
            Debug.Log(q);
        }

    }

    public void Update()
    {

    }

    public void setQueue()
    {
        //varibales for data transfer to string Queue
        int firstInt = 0;
        int secondInt = 0;
        int answer = 0;
        int[] temp = { };
        string questionString = " ";

        //array to randomize enabled questions
        string[] questionLevels = { "a1", "a2", "a3", "a4", "s1", "s2", "s3", "s4" };

        //new random for level enabled level randomization
        Random rand = new Random();
        int index = 0;

        while (questionQueue.Count < 25)
        {
            //randomized index each loop cycle
            index = UnityEngine.Random.Range(0, questionLevels.Length);

            if (addEnabled)
            {
                //If statements to check Enabled levels of addition
                if (addLvlOne == true && questionLevels[index] == "a1")
                {
                    //Load question into Queue
                    temp = randomArrayElement(AddLvlOne);
                    firstInt = temp[0];
                    secondInt = temp[1];
                    answer = firstInt + secondInt;
                    questionString = answer.ToString() + " ! " + firstInt.ToString() + " + " + secondInt.ToString();
                    questionQueue.Enqueue(questionString);
                }
                else if (addLvlTwo == true && questionLevels[index] == "a2")
                {
                    //Load question into Queue
                    temp = randomArrayElement(AddLvlTwo);
                    firstInt = temp[0];
                    secondInt = temp[1];
                    answer = firstInt + secondInt;
                    questionString = answer.ToString() + " ! " + firstInt.ToString() + " + " + secondInt.ToString();
                    questionQueue.Enqueue(questionString);
                }
                else if (addLvlThree == true && questionLevels[index] == "a3")
                {
                    //Load question into Queue
                    temp = randomArrayElement(AddLvlThree);
                    firstInt = temp[0];
                    secondInt = temp[1];
                    answer = firstInt + secondInt;
                    questionString = answer.ToString() + " ! " + firstInt.ToString() + " + " + secondInt.ToString();
                    questionQueue.Enqueue(questionString);
                }
                else if (addLvlFour == true && questionLevels[index] == "a4")
                {
                    //Load question into Queue
                    temp = randomArrayElement(AddLvlFour);
                    firstInt = temp[0];
                    secondInt = temp[0] + temp[1];
                    answer = temp[1];
                    questionString = answer.ToString() + " ! " + firstInt.ToString() + " + ____ = " + secondInt.ToString();
                    questionQueue.Enqueue(questionString);
                }
            } //end of addition Dis/Enabled

            if (subEnabled)
            {
                //If statements to check Enabled levels of subtraction
                if (subLvlOne == true && questionLevels[index] == "s1")
                {
                    //Load question into Queue
                    temp = randomArrayElement(SubLvlOne);
                    firstInt = temp[0];
                    secondInt = temp[1];
                    answer = firstInt - secondInt;
                    questionString = answer.ToString() + " ! " + firstInt.ToString() + " - " + secondInt.ToString();
                    questionQueue.Enqueue(questionString);
                }
                else if (subLvlTwo == true && questionLevels[index] == "s2")
                {
                    //Load question into Queue
                    temp = randomArrayElement(SubLvlTwo);
                    firstInt = temp[0];
                    secondInt = temp[1];
                    answer = firstInt - secondInt;
                    questionString = answer.ToString() + " ! " + firstInt.ToString() + " - " + secondInt.ToString();
                    questionQueue.Enqueue(questionString);
                }
                else if (subLvlThree == true && questionLevels[index] == "s3")
                {
                    //Load question into Queue
                    temp = randomArrayElement(SubLvlThree);
                    firstInt = temp[0];
                    secondInt = temp[1];
                    answer = firstInt - secondInt;
                    questionString = answer.ToString() + " ! " + firstInt.ToString() + " - " + secondInt.ToString();
                    questionQueue.Enqueue(questionString);
                }
                else if (subLvlFour == true && questionLevels[index] == "s4")
                {
                    //Load question into Queue
                    temp = randomArrayElement(SubLvlFour);
                    firstInt = temp[0];
                    secondInt = temp[0] - temp[1];
                    answer = temp[1];
                    questionString = answer.ToString() + " ! " + firstInt.ToString() + " - _____ = " + secondInt.ToString();
                    questionQueue.Enqueue(questionString);
                }
            } // end of subtraction Dis/Enabled

            /*NOTE: ! is a marker for the "answer" to each question which will be placed at the begining of the string
            when poping the queue will parse for the answer at the front using text.Substring(0, text.IndexOf("!")) and same thing 
            for the question but placing the answer substring to answer variable and further substring printed as the question*/

        } //end of while loop

    }

    //helper method taking an array as input and pulling random array element from array
    private int[] randomArrayElement(int[,] array)
    {
        int[] qSet = { };
        int index = 0;

        Random rand = new Random();
        index = UnityEngine.Random.Range(0, array.Length);

        qSet[0] = array[index, 0];
        qSet[1] = array[index, 1];

        return qSet;
    }

    public string AlvlOneDes = "Adding doubles of numbers! EX: 3 + 3 = __";
    public string AlvlTwoDes = "Adding doubles +/- 1, Counting on review! EX: 4 + 5 = __ or 3 + 7 = __";
    public string AlvlThreeDes = "Adding 9's, Sums over 10! EX: 9 + 5 = __ or 8 + 6 = __";
    public string AlvlFourDes = "Fill in the blank addition! EX: 7 + __ = 13";

    //Embedded Arrays (Addition)
    //Level 1
    private int[,] AddLvlOne = new int[,] { { 3, 3 }, { 4, 4 }, { 2, 2 }, { 0, 0 }, { 1, 1 }, { 5, 5 }, { 10, 10 }, { 8, 8 }, { 7, 7 }, { 12, 12 }, { 9, 9 }, { 11, 11 }, { 6, 6 } };
    //Level 2 
    private int[,] AddLvlTwo = new int[,] {{11,12}, {3,4}, {6,7}, {2,3}, {7,8}, {12,13}, {10,11}, {8,9}, {10,11}, {6,7}, {6,5}, {3,2}, {8,9}, {5,6}, {13,12}, {7,8},
    {7,6}, {4,3}, {4,5}, {11,10}, {11,12}, {9,8}, {8,7}, {12,11}, {9,10}, {5,4}, {2,3}, {12,13}, {3,4}, {10,9}, {2,3}, {5,2}, {5,3}, {3,3},
    {2,5}, {6,3}, {4,2}, {2,4}, {7,2}, {6,2}, {3,5}, {3,7}, {6,1}, {2,6}, {2,8}};
    //Level 3 
    private int[,] AddLvlThree = new int[,] {{5,9}, {6,9}, {4,9}, {2,9}, {8,9}, {7,9}, {3,9}, {12,9}, {11,9}, {13,9}, {14,9}, {15,9}, {6,5}, {8,3}, {4,7}, {12,10},
    {10,8}, {7,5}, {8,5}, {9,6}, {6,6}, {5,6}, {7,10}, {9,8}, {5,9}, {8,6}, {12,12}, {10,10}, {3,9}, {8,8}, {7,6}, {9,4}, {10,6}, {8,9},
    {6,8}, {10,11}};
    //Level 4 
    private int[,] AddLvlFour = new int[,] {{3,3}, {4,4}, {2,2}, {0,0}, {1,1}, {5,5}, {10,10}, {8,8}, {7,7}, {12,12}, {9,9}, {11,11}, {6,6}, {11,12}, {3,4}, {6,7},
    {2,3}, {7,8}, {12,13}, {10,11}, {8,9}, {10,11}, {6,7}, {6,5}, {3,2}, {8,9}, {5,6}, {13,12}, {7,8}, {7,6}, {4,3}, {4,5}, {11,10}, {11,12},
    {9,8}, {8,7}, {12,11}, {9,10}, {5,4}, {2,3}, {12,13}, {3,4}, {10,9}, {2,3}, {5,2}, {5,3}, {3,3}, {2,5}, {6,3}, {4,2}, {2,4}, {7,2}, {6,2},
    {3,5}, {3,7}, {6,1}, {2,6}, {2,8}, {5,9}, {6,9}, {4,9}, {2,9}, {8,9}, {7,9}, {3,9}, {12,9}, {11,9}, {13,9}, {14,9}, {15,9}, {6,5}, {8,3},
    {4,7}, {12,10}, {10,8}, {7,5}, {8,5}, {9,6}, {6,6}, {5,6}, {7,10}, {9,8}, {5,9}, {8,6}, {12,12}, {10,10}, {3,9}, {8,8}, {7,6}, {9,4}, {10,6},
    {8,9}, {6,8}, {10,11}};

    public string SublvlOneDes = "Subtracting 0's and 1's! EX: 8 - 0 = __ or 8 - 1 = __";
    public string SublvlTwoDes = "Subtracting (0 to 10) EX: 8 - 6 = ";
    public string SublvlThreeDes = "Subtracting up to & over 10! EX: ";
    public string SublvlFourDes = "Fill in the blank subtraction! EX: 14 - __ = 5";

    //Embedded Arrays (Subtraction)
    //Level 1
    private int[,] SubLvlOne = new int[,] { { 7, 0 }, { 13, 0 }, { 0, 0 }, { 10, 0 }, { 100, 1 }, { 45, 0 }, { 3000, 0 }, { 8, 1 }, { 7, 1 }, { 10, 1 }, { 11, 1 }, { 12, 1 }, { 9, 1 }, { 13, 1 } };
    //Level 2
    private int[,] SubLvlTwo = new int[,] {{9,1}, {5,1}, {6,3}, {6,4}, {2,2}, {5,2}, {6,2}, {3,3}, {4,1}, {5,4}, {4,3}, {3,2}, {10,9}, {8,4}, {6,2}, {9,3},
    {9,3}, {7,5}, {9,8}, {7,2}, {6,4}, {8,3}, {8,5}, {10,3}, {9,4}, {9,8}, {7,4}, {8,7}, {4,1}, {6,3}, {10,8}, {5,2}, {5,3}, {3,3},
    {10,5}, {6,3}, {4,2}, {7,7}, {7,2}, {6,2}};
    //Level 3
    private int[,] SubLvlThree = new int[,] {{11,2}, {12,12}, {12,9}, {10,4}, {10,5}, {13,12}, {14,6}, {11,5}, {13,8}, {17,9}, {15,7}, {12,4}, {10,9}, {16,8}, {18,9}, {14,7},
    {11,6}, {13,4}, {17,8}, {12,5}, {15,6}, {14,8}, {15,7}, {12,8}, {13,6}, {15,9}, {14,6}, {11,8}, {13,7}, {13,8}, {14,9}, {12,2}, {14,9}, {12,7},
    {11,5}, {14,11}, {17,16}, {18,10}, {13,9}, {15,5}};
    //Level 4
    private int[,] SubLvlFour = new int[,] {{7,0}, {13,0}, {0,0}, {10,0}, {100,1}, {45,0}, {3000,0}, {8,1}, {7,1}, {10,1}, {11,1}, {12,1}, {9,1}, {13,1},
    {9,1}, {5,1}, {6,3}, {6,4}, {2,2}, {5,2}, {6,2}, {3,3}, {4,1}, {5,4}, {4,3}, {3,2}, {10,9}, {8,4}, {6,2}, {9,3},
    {9,3}, {7,5}, {9,8}, {7,2}, {6,4}, {8,3}, {8,5}, {10,3}, {9,4}, {9,8}, {7,4}, {8,7}, {4,1}, {6,3}, {10,8}, {5,2}, {5,3}, {3,3},
    {10,5}, {6,3}, {4,2}, {7,7}, {7,2}, {6,2}, {11,2}, {12,12}, {12,9}, {10,4}, {10,5}, {13,12}, {14,6}, {11,5}, {13,8}, {17,9}, {15,7}, {12,4}, {10,9}, {16,8}, {18,9}, {14,7},
    {11,6}, {13,4}, {17,8}, {12,5}, {15,6}, {14,8}, {15,7}, {12,8}, {13,6}, {15,9}, {14,6}, {11,8}, {13,7}, {13,8}, {14,9}, {12,2}, {14,9}, {12,7},
    {11,5}, {14,11}, {17,16}, {18,10}, {13,9}, {15,5}};


}