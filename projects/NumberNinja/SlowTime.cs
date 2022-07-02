using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    public float time = 0f;
    bool trigger = false;
    public GameObject thisthing;
    public QuestionMaster ques;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = time;
            trigger = true;
            ques.QuestionCheck();
        }
    }

    private void Update()
    {
        if(trigger)
        {
            thisthing.SetActive(false);
        }
    }
}
