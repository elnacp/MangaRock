using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Actual time status bar
public class ActualTime : MonoBehaviour
{
    int sysHour = System.DateTime.Now.Hour;
    int minuts = System.DateTime.Now.Minute;

    private void Start()
    {
        this.GetComponent<Text>().text = sysHour + ":" +minuts;
    }

}
