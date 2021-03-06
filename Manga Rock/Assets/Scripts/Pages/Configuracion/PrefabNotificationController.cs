using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabNotificationController : MonoBehaviour
{
    [SerializeField] Text title;
    [SerializeField] Text state;
    [SerializeField] Image background;

    private bool stateButton = true;

    //Change the state of the notification to ON
    private void NotificationOn()
    {
        title.color = Color.white;
        state.color = Color.white;
        state.text = "ON";
        background.color = Color.black;
    }

    //Change the state of the notification to Off
    private void NotificationOff()
    {
        title.color = Color.black;
        state.color = Color.black;
        state.text = "OFF";
        background.color = Color.white;
    }
    
    //Click the notification and change the state
    public void ClickNotification()
    {
        stateButton = !stateButton;
        if(stateButton)
        {
            NotificationOn();
        }
        else
        {
            NotificationOff();
        }
    }
}
