using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MangaRecomendaciones : MonoBehaviour
{
    [SerializeField] RawImage image;
    [SerializeField] Text title;
    [SerializeField] Text autor;
    [SerializeField] Text precio;


    public void AddInfo(string url, string title, string autor, string precio)
    {
        StartCoroutine(GetImage(url));
        this.title.text = title;
        this.autor.text = autor;
        this.precio.text = precio + "€";


    }

    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }

}
