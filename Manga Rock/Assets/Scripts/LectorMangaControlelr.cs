using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LectorMangaControlelr : MonoBehaviour
{
    [SerializeField] GameObject tamañoLetra;
    [SerializeField] GameObject colorPage;
    [SerializeField] GameObject directionPage;

    [SerializeField] Text textRight;
    [SerializeField] Text textLeft;
    [SerializeField] Button leftArrow;
    [SerializeField] Button rightArrow;

    [SerializeField] Image directionImage;
    [SerializeField] Sprite right;
    [SerializeField] Sprite left;

    [SerializeField] Text[] textManga;

    [SerializeField] Slider textSize;

    [SerializeField] Image background;

    [SerializeField] GameObject panels;

    private int actualPage = 1;
    private int finalPage = 0;
    private bool isLeftRight = true;

    private void Start()
    {
        panels.SetActive(false);
    }

    //Add num of pages
    public void AddPages(int pages)
    {
        isLeftRight = true;
        textRight.text = pages.ToString();
        textLeft.text = 1.ToString();
        finalPage = pages;
    }

    //State of the page buttons
    public void StatePage()
    {
        if (isLeftRight)
        {
            if(actualPage == finalPage)
            {
                rightArrow.interactable = false;
            }
            else
            {
                rightArrow.interactable = true;
            }
            if(actualPage == 1)
            {
                leftArrow.interactable = false;
            }
            else
            {
                leftArrow.interactable = true;
            }
        }
        else
        {
            if (actualPage == finalPage)
            {
                leftArrow.interactable = false;
            }
            else
            {
                leftArrow.interactable = true;
            }
            if (actualPage == 1)
            {
                rightArrow.interactable = false;
            }
            else
            {
                rightArrow.interactable = true;
            }
        }
    }

    //click right arrow
    public void RightArrow()
    {       
        if(isLeftRight)
        {
            if(actualPage != finalPage)
            {
                actualPage++;
            }
            textLeft.text = actualPage.ToString();
            StatePage();
        }
        else
        {
            if(actualPage != 1)
            {
                actualPage--;
            }
            textRight.text = actualPage.ToString();
            StatePage();
        } 
    }

    //click left arrowe
    public void LeftArrow()
    {
        if (isLeftRight)
        {
            if (actualPage != 1)
            {
                actualPage--;
            }
            textLeft.text = actualPage.ToString();
            StatePage();

        }
        else
        {
            if (actualPage != finalPage)
            {
                actualPage++;
            }
            textRight.text = actualPage.ToString();
            StatePage();
        }

    }

    //change direction of the lector
    public void ChangeDirection()
    {
        HidePages();
        if (panels.activeSelf)
        {
            directionPage.SetActive(true);
        }

    }

    //Right direction
    public void RightDirection()
    {
        isLeftRight = true;
        textLeft.text = actualPage.ToString();
        textRight.text = finalPage.ToString();

    }

    //left direction
    public void LeftDirection()
    {
        isLeftRight = false;
        textLeft.text = finalPage.ToString();
        textRight.text = actualPage.ToString();
    }

    //change the color of the background
    public void ChangeColor()
    {
        HidePages();

        if (panels.activeSelf)
        {
            colorPage.SetActive(true);
        }
    }

    //change the background with the color of the button
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

    //change the size of the letter
    public void SizeLetter()
    {
        
        foreach(Text item in textManga)
        {
            switch (textSize.value)
            {
                case 1: 
                    item.fontSize = 14;
                    break;
                case 2:
                    item.fontSize = 16;
                    break;
                case 3:
                    item.fontSize = 18;
                    break;
                case 4:
                    item.fontSize = 20;
                    break;
                case 5:
                    item.fontSize = 22;
                    break;
            }
        }
        

    }

    //change the size
    public void ChangeSizeLetter()
    {
        HidePages();

        if(panels.activeSelf)
        {
            tamañoLetra.SetActive(true);
        }

        

    }

    //hide the pages
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

        tamañoLetra.SetActive(false);
        colorPage.SetActive(false);
        directionPage.SetActive(false);
    }

}
