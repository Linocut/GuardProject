using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        PlayerCollision controller = other.GetComponent<PlayerCollision>();
        if (controller != null)
        {
            if (controller.guffinCheck() == true)
            {
                Debug.Log("Win");
                SceneManager.LoadScene("WinScene");
            }
            else if (controller.guffinCheck() == false)
            {
                Debug.Log("lose");
                SceneManager.LoadScene("LoseScene");
            }

        }

    }


}
