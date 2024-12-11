using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letter : MonoBehaviour
{
    public GameObject letterUI;
    bool toggle;
    //public PlayerMovement player;
    public Renderer letterMash;

    public void openCloseLetter()
    {
        toggle = !toggle;
        if(toggle==false)
        {
            letterUI.SetActive(false);
            letterMash.enabled=true;
            //player.enabled = true;      
        }
        else
        {
            letterUI.SetActive(true);
            letterMash.enabled = false;
            //player.enabled = false; 
        }
    }
}
