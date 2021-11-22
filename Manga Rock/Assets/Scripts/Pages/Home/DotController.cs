using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DotController : MonoBehaviour
{
    [SerializeField] Sprite dotActive;
    [SerializeField] Sprite dotDeative;

    public void ActivateDot()
    {
        this.GetComponent<Image>().sprite = dotActive;
    }

    public void DeactivateDot()
    {
        this.GetComponent<Image>().sprite = dotDeative;
    }

}
