using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MangaAddToCollectionList : MonoBehaviour
{
    [SerializeField] Text title;
    [SerializeField] Text autor;
    [SerializeField] RawImage image;
    [SerializeField] Image checkbox;

    [SerializeField] Sprite checkOn;
    [SerializeField] Sprite checkOff;

    private bool statelist = false;
    private ColeccionBibliotecaClass data = new ColeccionBibliotecaClass();

    //Add information to the manga collection list
    public void AddManga(ColeccionBibliotecaClass manga, bool state)
    {
        title.text = manga.titulo;
        autor.text = manga.autor;
        StartCoroutine(GetImage(manga.url));

        statelist = state;

        if(state)
        {
            FindObjectOfType<AñadirMangasCollectionController>().AddMangaList(manga);
        }

        if (state)
        {
            checkbox.sprite = checkOn;
        }
        else
        {
            checkbox.sprite = checkOff;
        }
        //isDelete = false;

        data = manga;
    }

    //Get image from url
    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }

    //Go to detail manga
    public void ClickManga()
    {
        statelist = !statelist;
        if(statelist)
        {
            checkbox.sprite = checkOn;
            FindObjectOfType<AñadirMangasCollectionController>().AddMangaList(data);
        }
        else
        {
            checkbox.sprite = checkOff;
            FindObjectOfType<AñadirMangasCollectionController>().DeleteMangaList(data);
        }
    }

    

}
