using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MangaWithPricePrefab : MonoBehaviour
{
    [SerializeField] RawImage image;
    [SerializeField] Text title;
    [SerializeField] Text author;
    [SerializeField] Text price;

    public void AddInformation(string url, string title, string author, string price)
    {
        StartCoroutine(GetImage(url));
        this.title.text = title;
        this.author.text = author;
        this.price.text = price;
    }
    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }
}

