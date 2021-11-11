using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageController : MonoBehaviour
{

    public GameObject home;
    public GameObject library;
    public GameObject search;
    public GameObject notifications;
    public GameObject profile;

    public void ChangePage(string name)
    {
        HidePages();

        switch(name)
        {
            case "home": home.SetActive(true);
                break;
            case "library": library.SetActive(true);
                break;
            case "search": search.SetActive(true);
                break;
            case "notifications": notifications.SetActive(true);
                break;
            case "profile": profile.SetActive(true);
                break;

        }
    }

    public void HidePages()
    {
        home.SetActive(false);
        library.SetActive(false);
        search.SetActive(false);
        notifications.SetActive(false);
        profile.SetActive(false);

    }


}
