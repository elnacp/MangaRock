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
    public void AddData(string url, string title, string author, int pages)
    {
        this.title.text = title;
        this.author.text = author;
        StartCoroutine(GetImage(url));
        this.pages = pages;
    }

    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }

    public void OpenLector()
    {
        if(pages != 0)
        {
            FindObjectOfType<PageController>().GoLectorMangas(pages);

        }
    }
}
