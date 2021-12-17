using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MangaWithPercentageController : MonoBehaviour
{
    [SerializeField] RawImage image;
    [SerializeField] Text title;
    [SerializeField] Text author;
    [SerializeField] Text percentageRead;

    private int pages;

    //Add information
    public void AddData(string url, string title, string author, float percentage, int pages)
    {
        this.title.text = title;
        this.author.text = author;
        StartCoroutine(GetImage(url));
        this.percentageRead.text = percentage+"%";

        this.pages = pages;
    }

    //Get image from url
    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }

    //Open lector
    public void OpenLector()
    {
        FindObjectOfType<PageController>().GoLectorMangas(pages);
    }
}
