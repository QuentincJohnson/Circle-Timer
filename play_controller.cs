using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
//-------^^^^^^^^^--------------// Recognizing Unity 


[System.Serializable]//allows variables to be seen in Unity UI
public class play_controller : MonoBehaviour
{
///eating the existane of variables
    public float timer;
    float pressT;

    //circles
    public GameObject prep;
    public GameObject prep1;
    public GameObject prep2;
    public GameObject Hit;

    //audio
    public AudioSource beat;
    
    bool first;   // 
    bool second;  // cpu bool
    bool third;   //

    bool fourth;  // player bool 


    void Start()   // Use this for initialization
    {
        timer = 0;
        first = second = third = fourth = true;

        //setting size of circles 
        prep.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        prep1.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        prep2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

    void Update()  // Update is called once per frame
    {
        //running voids made below 
        getcount();
        resizePlay();
        press();
        timerreset();
    }

    void getcount() // stores the time in secons in "timer"
    {
        timer += Time.deltaTime;

    }

    void timerreset() // resets timer and bools when timer reaches over 4 
    {
        if (timer > 4.0f)
        {
            timer = 0;
            first = second = third = fourth = true;
        }
    }

    void press()// handles logic for pressing the button on time
    {
        if (Input.GetKeyDown(KeyCode.Space))//checks if space is PRESSED
        {
            pressT = timer;

            if (pressT > 3.88f || pressT < 0.36f && fourth == true)//checks if space is pressed ON TIME
            {
                //plays notes and resizes cirle
                beat.Play(0);
                fourth = false;
                Hit.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }

            //printing numbers or debuging 
            print(pressT);
            print(timer);

        }

    }

    void resizePlay() // resizes the CPU Circles and plays a sound according to the time 
        // handes CPU behaviors for the players Circle
    {
        if (timer > 1 && timer < 2 && first == true)// circle 1
        {
            //Audio
            beat.Play(0);
            first = false;

            //Visual
            Hit.transform.localScale = new Vector3(0.1f, 0.1f, 0f);
            prep.transform.localScale = new Vector3(0.2f, 0.2f, 0f);
        }
        if (timer > 2 && timer < 3 && second == true)// circle 2
        {
            //Audio
            beat.Play(0);
            second = false;

            //Visual
            prep.transform.localScale = new Vector3(0.1f, 0.1f, 0f);
            prep1.transform.localScale = new Vector3(0.2f, 0.2f, 0f);
        }
        if (timer > 3 && timer < 4 && third == true)// circle 3
        {
            //Audio
            beat.Play(0);
            third = false;

            //Visual
            prep1.transform.localScale = new Vector3(0.1f, 0.1f, 0f);
            prep2.transform.localScale = new Vector3(0.2f, 0.2f, 0f);
        }

        if (timer > 3.99f) //player circle CPU behavior
        {
            prep2.transform.localScale = new Vector3(0.1f, 0.1f, 0f);
        }
    }
}
