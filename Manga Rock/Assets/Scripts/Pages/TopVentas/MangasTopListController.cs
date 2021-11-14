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

    public void UpdateMangaInfo(string title, string autor, string valoracio, string genre, string url, string number)
    {
        this.title.text = title;
        this.autor.text = autor;
        this.valoracion.text = valoracio;

        if(genre.Contains(","))
        {
            string[] generos = genre.Split(',');
            foreach(string e in generos)
            {
                GameObject prefab = Instantiate(genrePrefab, contentGenre.transform);
                prefab.transform.GetChild(0).GetComponent<Text>().text = e;
            }
        }else
        {
            GameObject prefab = Instantiate(genrePrefab, contentGenre.transform);
            prefab.transform.GetChild(0).GetComponent<Text>().text = genre;
        }

        //Image

        this.number.text = number;
    }



}
