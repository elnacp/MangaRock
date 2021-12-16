using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MangaWithNoPercentageControlle : MonoBehaviour
{
    [SerializeField] RawImage image;
    [SerializeField] Text title;
    [SerializeField] Text author;

    private int pages;

    //Add information related with manga
    public void AddData(string url, string title, string author, int pages)
    {
        this.title.text = title;
        this.author.text = author;
        StartCoroutine(GetImage(url));
        this.pages = pages;
    }

    //get image from url
    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }

    //Open the reader for mangas
    public void OpenLector()
    {
        if(pages != 0)
        {
            FindObjectOfType<PageController>().GoLectorMangas(pages);

        }
    }
}
