using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DotController : MonoBehaviour
{
    [SerializeField] Sprite dotActive;
    [SerializeField] Sprite dotDeative;

    //Change the dot to active
    public void ActivateDot()
    {
        this.GetComponent<Image>().sprite = dotActive;
    }

    //Change the dot to deactive
    public void DeactivateDot()
    {
        this.GetComponent<Image>().sprite = dotDeative;
    }

}
