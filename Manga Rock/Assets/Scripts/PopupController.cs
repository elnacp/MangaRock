using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    [SerializeField] Canvas aplication;
    [SerializeField] Canvas popups;


    private void Start()
    {
        popups.enabled = false;

    }

    public void ActivatePopup()
    {
        
        popups.enabled = true;
       

    }


    public void AddMangasCollection()
    {
        ActivatePopup();
    }

    public void EditarCollection()
    {
        ActivatePopup();
    }
}
