using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MangaDeleteCollection : MonoBehaviour
{
    [SerializeField] Text title;
    [SerializeField] Text autor;
    [SerializeField] RawImage image;
    [SerializeField] GameObject bin;

    ColeccionBibliotecaClass data;

    private bool isDelete = false;

    //Add mangas in the list
    public void AddManga(ColeccionBibliotecaClass manga)
    {
        title.text = manga.titulo;
        autor.text = manga.autor;
        StartCoroutine(GetImage(manga.url));

        data = manga;
        bin.SetActive(false);
        isDelete = false;
    }

    //Get image from url
    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }

    //Delete manga
    public void DeleteManga()
    {
        isDelete = !isDelete;
        if (isDelete)
        {
            bin.SetActive(true);
            FindObjectOfType<EditarCollection>().AddDeleteList(data);
        }
        else
        {
            bin.SetActive(false);
            FindObjectOfType<EditarCollection>().RemoveFromDeleteList(data);
        }
    }
}
