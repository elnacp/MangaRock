using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MangaWithNoPercentageControlle : MonoBehaviour
{
    [SerializeField] RawImage image;
    [SerializeField] Text title;
    [SerializeField] Text author;

    public void AddData(string url, string title, string author)
    {
        this.title.text = title;
        this.author.text = author;
        StartCoroutine(GetImage(url));
    }

    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }

}