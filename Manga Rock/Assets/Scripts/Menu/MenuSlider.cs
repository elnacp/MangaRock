using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSlider : MonoBehaviour
{

    public GameObject menu;
    public GameObject background;

    public void Start()
    {
        background.SetActive(false);
    }

    public void Menu()
    {
        Animator animator = menu.GetComponent<Animator>();
        if (animator != null)
        {
            bool isOpen = animator.GetBool("show");
            if(!isOpen)
            {
                background.SetActive(true);
            }else
            {
                background.SetActive(false);
            }
            animator.SetBool("show", !isOpen);
        }
    }
}
