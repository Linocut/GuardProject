using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsPaper : MonoBehaviour
{
   
    public GameObject newspaper;
   

    

    // is put n the news paper, whent he colider that is a trigger detetcts a collision with the player game object, then it will use a world canvas
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            newspaper.SetActive(true);
        }
        

    }
    private void OnTriggerExit(Collider other)
    {
        
        newspaper.SetActive(false);
        //
    }


}
