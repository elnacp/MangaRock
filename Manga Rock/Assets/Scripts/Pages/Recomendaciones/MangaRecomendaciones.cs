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
    
    //Add information in the prefab of manga recomendation
    public void AddInfo(MangaClass manga)
    {
        StartCoroutine(GetImage(manga.url));
        title.text = manga.titulo;
        autor.text = manga.autor;
        precio.text = manga.precio + "€";

        mangaData = manga;
       
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
