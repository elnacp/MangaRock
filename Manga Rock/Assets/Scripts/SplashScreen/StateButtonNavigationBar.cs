using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateButtonNavigationBar : MonoBehaviour
{

    [SerializeField] Sprite disable_img;
    [SerializeField] Sprite active_img;

    //Disable button
    public void DisableButton()
    {
        this.GetComponent<Image>().sprite = disable_img;
    }

    //Activate button
    public void ActiveButton()
    {
        this.GetComponent<Image>().sprite = active_img;
    }
}
