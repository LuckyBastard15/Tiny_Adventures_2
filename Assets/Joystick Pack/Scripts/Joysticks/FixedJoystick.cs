using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedJoystick : Joystick
{
    
    private void Update()
    {
        if(Time.deltaTime == 0)
        {
            //background.gameObject.SetActive(false);
        }
        else
        {
            //background.gameObject.SetActive(true);
        }
    }
}