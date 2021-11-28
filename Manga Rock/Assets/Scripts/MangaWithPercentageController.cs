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

    public void AddData(string url, string title, string author, float percentage)
    {
        this.title.text = title;
        this.author.text = author;
        StartCoroutine(GetImage(url));
        this.percentageRead.text = percentage+"%";
    }

    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }

}
