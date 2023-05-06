using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawn : MonoBehaviour
{
    public GameObject cat;




    // is put n the news paper, whent he colider that is a trigger detetcts a collision with the player game object, then it will use a world canvas
    private void OnTriggerEnter(Collider other)
    {

        cat.SetActive(true);



    }

}
