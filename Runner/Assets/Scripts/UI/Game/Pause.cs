using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField]
    GameObject panel;
    [SerializeField]
    GameObject joystick;
    public void _Pause()
    {
       
            panel.SetActive(true);
            Time.timeScale = 0f;
        joystick.SetActive(false);

        

    }
        
    
}
