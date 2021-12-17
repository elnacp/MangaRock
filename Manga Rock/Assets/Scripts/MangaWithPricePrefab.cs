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

    MangaClass mangaData;

    //Add information
    public void AddInformation(MangaClass manga)
    {
        StartCoroutine(GetImage(manga.url));
        this.title.text = manga.titulo;
        this.author.text = manga.autor;
        this.price.text = manga.precio + "€";

        this.mangaData = manga;
    }

    //Get image from url
    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }

    //Go to manga detail
    public void MangaDetail()
    {
        FindObjectOfType<PageController>().GoDetallesManga(mangaData);
    }
}

