using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        PlayerCollision controller = other.GetComponent<PlayerCollision>();
        if (controller != null)
        {
            controller.PickUp();

            Destroy(gameObject);

        }

    }


}
