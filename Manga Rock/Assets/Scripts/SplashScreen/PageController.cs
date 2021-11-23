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
    public GameObject genre;

    [SerializeField] GameObject navigationBar;
    [SerializeField] GameObject actionBarMenu;
    [SerializeField] GameObject actionBarBackWhite;
    [SerializeField] GameObject actionBarBackBlack;

    private string actualPage;

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

        actualPage = name;
    }

    public void GoGenrePage(string category)
    {
        HideBarsAndShowBack();
        genre.SetActive(true);
        genre.GetComponent<GenreController>().GoCategory(category);
    }

    

    public void BackButton()
    {
        ShowBarAndHideSubPages();
    }

    private void ShowBarAndHideSubPages()
    {
        ChangePage(actualPage);
        navigationBar.SetActive(true);
        actionBarMenu.SetActive(true);
        actionBarBackBlack.SetActive(false);

    }

    private void HideBarsAndShowBack()
    {
        HidePages();
        actionBarMenu.SetActive(false);
        navigationBar.SetActive(false);
        actionBarBackBlack.SetActive(true);
    }

    public void HidePages()
    {
        home.SetActive(false);
        library.SetActive(false);
        search.SetActive(false);
        notifications.SetActive(false);
        profile.SetActive(false);
        genre.SetActive(false);

    }


}
