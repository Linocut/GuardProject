using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchCanvas : MonoBehaviour
{
    // This script allows for the Main Menu UI to utilize keyboard and gamepad inputs between different canvases.
    public GameObject OffCanvas; // For canvases that are turned off (ex: controls and credits menu's).
    public GameObject OnCanvas; // For the main menu canvas that is turned on.
    public GameObject FirstObject; // Must be attached to the button in the OffCanvas.
    
    public void Switch()
    {
        OffCanvas.SetActive (true);
        OnCanvas.SetActive (false);
        GameObject.Find("EventSystem").GetComponent<EventSystem> ().SetSelectedGameObject (FirstObject, null);
    }
}
