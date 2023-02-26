using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public bool mcguffin;

    public void Start()
    {
        mcguffin = false;
    }

    public void PickUp()
    {
        mcguffin = true;
    }
    public bool guffinCheck()
    {
        return mcguffin;
    }





}
