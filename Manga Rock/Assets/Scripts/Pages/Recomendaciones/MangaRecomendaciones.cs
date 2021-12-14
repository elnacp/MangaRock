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

    private MangaClass mangaData;

    public void AddInfo(MangaClass manga)
    {
        StartCoroutine(GetImage(manga.url));
        title.text = manga.titulo;
        autor.text = manga.autor;
        precio.text = manga.precio + "€";

        mangaData = manga;
       
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
