using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetallesMangaPageController : MonoBehaviour
{
    [SerializeField] RawImage image;
    [SerializeField] Text title;
    [SerializeField] Text author;
    [SerializeField] Text price;
    [SerializeField] Text genre;
    [SerializeField] Text language;
    [SerializeField] Text pages;
    [SerializeField] Text size;
    [SerializeField] Text review;

    [SerializeField] Transform contentMangasSameAutor;
    [SerializeField] Transform contentMangasSameColection;
    [SerializeField] Transform contentMangasSameCategory;

    [SerializeField] GameObject mangaPrefab;

    [SerializeField] FirebasePageController firebase;

    public void AddInformation(MangaClass manga)
    {
        StartCoroutine(GetImage(manga.url));
        title.text = manga.titulo;
        author.text = manga.autor;
        price.text = manga.precio + "€";

        if (manga.genero.Contains(","))
        {
            string[] generos = manga.genero.Split(',');
            genre.text = generos[0];
        }
        else
        {
            genre.text = manga.genero;
        }

        language.text = "ESP";
        pages.text = manga.paginas.ToString();
        size.text = manga.tamaño+" MB";
        review.text = manga.resumen;


        firebase.MangasSameAutor(manga.autor);
        firebase.MangasSameColection(manga.idColeccion);
        //firebase.MangasSameCategory(manga.genero);

    }

    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }

    public void ListMangasSameAutor(List<MangaClass> mangas)
    {
        foreach(MangaClass element in mangas)
        {
            GameObject prefab = Instantiate(mangaPrefab, contentMangasSameAutor);
            AddInformationPrefab(prefab, element);
        }
    }

    public void ListMangasSameColection(List<MangaClass> mangas)
    {
        foreach (MangaClass element in mangas)
        {
            GameObject prefab = Instantiate(mangaPrefab, contentMangasSameColection);
            AddInformationPrefab(prefab, element);
        }
    }

    private void AddInformationPrefab(GameObject prefab, MangaClass manga)
    {
        prefab.GetComponent<MangaWithPricePrefab>().AddInformation(manga.url, manga.titulo, manga.autor, manga.precio.ToString());
    }

    


}
