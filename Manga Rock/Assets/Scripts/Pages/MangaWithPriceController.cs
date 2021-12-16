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

    MangaClass mangaData;

    //Add information 
    public void AddInformation(MangaClass manga, string number)
    {
        StartCoroutine(GetImage(manga.url));
        this.number.text = number;
        this.title.text = manga.titulo;
        this.autor.text = manga.autor;

        if (manga.genero.Contains(","))
        {
            string[] generos = manga.genero.Split(',');
            foreach (string e in generos)
            {
                GameObject prefab = Instantiate(genrePrefab, contentGenre);
                prefab.transform.GetChild(0).GetComponent<Text>().text = e;
            }
        }
        else
        {
            GameObject prefab = Instantiate(genrePrefab, contentGenre);
            prefab.transform.GetChild(0).GetComponent<Text>().text = manga.genero;
        }

        this.price.text = manga.precio+ "€";
        this.valoracion.text = manga.valoracion.ToString();

        this.mangaData = manga;
    }

    //Get image from url
    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }

    //Go to manga details when manga is clicked
    public void MangaDetail()
    {
        FindObjectOfType<PageController>().GoDetallesManga(mangaData);
    }

}
