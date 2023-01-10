using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        double gesture_1 = 0.1;
        //double gesture_2 = 0.7;
        //double gesture_3;
        //double gesture_4;
        //double gesture_5;



        if (gesture_1 >= 0.8)
        {
            anim.SetBool("hand_5", true);
        }
        else if (gesture_1 >= 0.6)
        {
            anim.SetBool("hand_4", true);
        }
        else if (gesture_1 >= 0.4)
        {
            anim.SetBool("hand_3", true);
        }
        else if (gesture_1 >= 0.2)
        {
            anim.SetBool("hand_2", true);
        }
        else
        {
            anim.SetBool("hand_1", true);
        }

        /*
         
           if (gesture_2 >= 0.8)
        {
            anim.SetBool("hand_5", true);
        }
        else if (gesture_2 >= 0.6)
        {
            anim.SetBool("hand_4", true);
        }
        else if (gesture_2 >= 0.4)
        {
            anim.SetBool("hand_3", true);
        }
        else if (gesture_2 >= 0.2)
        {
            anim.SetBool("hand_2", true);
        }
        else
        {
            anim.SetBool("hand_1", true);
        }
         
         */

        /*
         
           if (gesture_2 >= 0.8)
        {
            anim.SetBool("hand_5", true);
        }
        else if (gesture_2 >= 0.6)
        {
            anim.SetBool("hand_4", true);
        }
        else if (gesture_2 >= 0.4)
        {
            anim.SetBool("hand_3", true);
        }
        else if (gesture_2 >= 0.2)
        {
            anim.SetBool("hand_2", true);
        }
        else
        {
            anim.SetBool("hand_1", true);
        }
         
         */


        /*
         
           if (gesture_2 >= 0.8)
        {
            anim.SetBool("hand_5", true);
        }
        else if (gesture_2 >= 0.6)
        {
            anim.SetBool("hand_4", true);
        }
        else if (gesture_2 >= 0.4)
        {
            anim.SetBool("hand_3", true);
        }
        else if (gesture_2 >= 0.2)
        {
            anim.SetBool("hand_2", true);
        }
        else
        {
            anim.SetBool("hand_1", true);
        }
         
         */





        /*
         
           if (gesture_2 >= 0.8)
        {
            anim.SetBool("hand_5", true);
        }
        else if (gesture_2 >= 0.6)
        {
            anim.SetBool("hand_4", true);
        }
        else if (gesture_2 >= 0.4)
        {
            anim.SetBool("hand_3", true);
        }
        else if (gesture_2 >= 0.2)
        {
            anim.SetBool("hand_2", true);
        }
        else
        {
            anim.SetBool("hand_1", true);
        }
         
         */


    }
}
