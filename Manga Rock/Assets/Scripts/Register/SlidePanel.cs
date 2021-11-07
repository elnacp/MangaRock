using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePanel : MonoBehaviour
{
    public GameObject panel;

    public void PanelSlide()
    {
        if(panel != null)
        {
            Animator animator = panel.GetComponent<Animator>();
            if(animator != null)
            {
                bool isOpen = animator.GetBool("show");
                animator.SetBool("show", !isOpen);
            }
        }
    }

    public bool PanelState()
    {
        return panel.GetComponent<Animator>().GetBool("show");
    }
}
