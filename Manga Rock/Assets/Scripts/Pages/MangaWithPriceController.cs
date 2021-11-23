using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MangaWithPriceController : MonoBehaviour
{
    [SerializeField] RawImage image;
    [SerializeField] Text number;
    [SerializeField] Text title;
    [SerializeField] Text autor;
    [SerializeField] Transform contentGenre;
    [SerializeField] GameObject genrePrefab;
    [SerializeField] Text price;
    [SerializeField] Text valoracion;

    public void AddInformation(string url, string number, string title, string autor, string genre, string price, string valoracion)
    {
        StartCoroutine(GetImage(url));
        this.number.text = number;
        this.title.text = title;
        this.autor.text = autor;

        if (genre.Contains(","))
        {
            string[] generos = genre.Split(',');
            foreach (string e in generos)
            {
                GameObject prefab = Instantiate(genrePrefab, contentGenre);
                prefab.transform.GetChild(0).GetComponent<Text>().text = e;
            }
        }
        else
        {
            GameObject prefab = Instantiate(genrePrefab, contentGenre);
            prefab.transform.GetChild(0).GetComponent<Text>().text = genre;
        }

        this.price.text = price+ "€";
        this.valoracion.text = valoracion;
    }

    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }



}
