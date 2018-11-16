using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class play_controller : MonoBehaviour
{
///creating the existane of variables
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

    float hitT;


    // Use this for initialization
    void Start()
    {
        timer = 0;

        first = second = third = fourth = true;

        //setting size of circles 
        //Hit.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        prep.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        prep1.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        prep2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        getcount();
        resizePlay();
        press();
        timerreset();
    }

    void getcount()
    {
        timer += Time.deltaTime;

    }

    void timerreset()
    {
        if (timer > 4.0f)
        {
            timer = 0;
            first = second = third = fourth = true;
        }
    }

    void press()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

            pressT = timer;

            if (pressT > 3.88f || pressT < 0.36f && fourth == true)
            {
                beat.Play(0);
                fourth = false;
                Hit.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

            }

            print(pressT);
            print(timer);

        }

    }

    void resizePlay()
    {
        if (timer > 1 && timer < 2 && first == true)
        {
            beat.Play(0);
            first = false;

            Hit.transform.localScale = new Vector3(0.1f, 0.1f, 0f);
            prep.transform.localScale = new Vector3(0.2f, 0.2f, 0f);
        }
        if (timer > 2 && timer < 3 && second == true)
        {
            beat.Play(0);
            second = false;

            prep.transform.localScale = new Vector3(0.1f, 0.1f, 0f);
            prep1.transform.localScale = new Vector3(0.2f, 0.2f, 0f);
        }
        if (timer > 3 && timer < 4 && third == true)
        {
            beat.Play(0);
            third = false;

            prep1.transform.localScale = new Vector3(0.1f, 0.1f, 0f);
            prep2.transform.localScale = new Vector3(0.2f, 0.2f, 0f);
        }

        if (timer > 3.99f)
        {
            prep2.transform.localScale = new Vector3(0.1f, 0.1f, 0f);
        }

    }
}
