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

    public void AddInformation(MangaClass manga)
    {
        StartCoroutine(GetImage(manga.url));
        this.title.text = manga.titulo;
        this.author.text = manga.autor;
        this.price.text = manga.precio + "€";

        this.mangaData = manga;
    }
    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }

    public void MangaDetail()
    {
        FindObjectOfType<PageController>().GoDetallesManga(mangaData);
    }
}

