using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LectorMangaControlelr : MonoBehaviour
{
    [SerializeField] GameObject tamaņoLetra;
    [SerializeField] GameObject colorPage;
    [SerializeField] GameObject directionPage;

    [SerializeField] Text paginasFinal;
    [SerializeField] Text paginaActual;
    [SerializeField] Button leftArrow;
    [SerializeField] Button rightArrow;


    [SerializeField] Button whiteBackground;
    [SerializeField] Button brownBackground;
    [SerializeField] Button blackbrackground;

    [SerializeField] Image background;

    [SerializeField] GameObject panels;

    private int actualPage = 1;
    private int finalPage = 0;

    private void Start()
    {
        panels.SetActive(false);
    }

    public void AddPages(int pages)
    {
        paginasFinal.text = pages.ToString();
        finalPage = pages;
    }

    public void StatePage()
    {
        if (actualPage == 1)
        {
            leftArrow.interactable = false;
        }
        else
        {
            leftArrow.interactable = true;
        }

        if (actualPage == finalPage)
        {
            rightArrow.interactable = false;
        }
        else
        {
            rightArrow.interactable = true;
        }
    }

    public void RightArrow()
    {
        if(actualPage != finalPage)
        {
            actualPage++;
        }
        paginaActual.text = actualPage.ToString();
        StatePage();
    }

    public void LeftArrow()
    {
        if(actualPage != 1)
        {
            actualPage--;
        }
        paginaActual.text = actualPage.ToString();
        StatePage();
    }

    public void ChangeDirection()
    {
        HidePages();
        if (panels.activeSelf)
        {
            directionPage.SetActive(true);
        }

    }

    public void ChangeColor()
    {
        HidePages();

        if (panels.activeSelf)
        {
            colorPage.SetActive(true);
        }
    }

    public void ChangeBackground(int number)
    {
        Color color = new Color();

        if (number == 1)
        {
            color = Color.white;
        }
        else
        {
            if (number == 2)
            {
                ColorUtility.TryParseHtmlString("#E3CDB3", out color);
            }
            else
            {
                ColorUtility.TryParseHtmlString("#525151", out color);
            }
        }

        color.a = 0.4f;
        background.color = color;
       
    }

    public void ChangeSizeLetter()
    {
        HidePages();

        if(panels.activeSelf)
        {
            tamaņoLetra.SetActive(true);
        }

    }

    private void HidePages()
    {
        if(panels.activeSelf)
        {
            panels.SetActive(false);    
        }
        else
        {
            panels.SetActive(true);
        }

        tamaņoLetra.SetActive(false);
        colorPage.SetActive(false);
        directionPage.SetActive(false);
    }

}
