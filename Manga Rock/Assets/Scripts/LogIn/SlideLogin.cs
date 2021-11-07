using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideLogin : MonoBehaviour
{

    public GameObject loginpanel;

    public void ShowHideMenu()
    {
        if(loginpanel != null)
        {
            Animator animator = loginpanel.GetComponent<Animator>();
            if(animator != null)
            {
                bool isOpen = animator.GetBool("show");
                animator.SetBool("show", !isOpen);
            }
        }
    }

    
}
