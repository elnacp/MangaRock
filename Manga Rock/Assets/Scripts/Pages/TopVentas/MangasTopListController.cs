using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MangasTopListController : MonoBehaviour
{
    [SerializeField] Text title;
    [SerializeField] Text autor;
    [SerializeField] Text valoracion;
    [SerializeField] GameObject genrePrefab;
    [SerializeField] GameObject contentGenre;

    [SerializeField] RawImage image;
    [SerializeField] Text number;

    private MangaClass mangaData;

    public void UpdateMangaInfo(MangaClass manga, string number)
    {
        this.title.text = manga.titulo;
        this.autor.text = manga.autor;
        this.valoracion.text = manga.valoracion.ToString();

        if(manga.genero.Contains(","))
        {
            string[] generos = manga.genero.Split(',');
            foreach(string e in generos)
            {
                GameObject prefab = Instantiate(genrePrefab, contentGenre.transform);
                prefab.transform.GetChild(0).GetComponent<Text>().text = e;
            }
        }else
        {
            GameObject prefab = Instantiate(genrePrefab, contentGenre.transform);
            prefab.transform.GetChild(0).GetComponent<Text>().text = manga.genero;
        }

        //Image

        StartCoroutine(GetImage(manga.url));

        this.number.text = number;

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
