using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WishlistPrefab : MonoBehaviour
{
    [SerializeField] Text number;
    [SerializeField] RawImage image;
    [SerializeField] Text autor;
    [SerializeField] Text valoracio;
    [SerializeField] Text price;

    WishlistClass manga;

    public void AddInformation(WishlistClass manga, int index)
    {
        number.text = index.ToString();
        StartCoroutine(GetImage(manga.url));
        autor.text = manga.autor;
        valoracio.text = manga.valoracion.ToString();
        price.text = manga.precio + "€";

        this.manga = manga;
    }

    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }

    public void DeleteManga()
    {
        FirebasePageController firebase = FindObjectOfType<FirebasePageController>();
        firebase.DeleteMangaWishlist(manga);      
    }

    public string GetTitleManga()
    {
        return manga.titulo;
    }

}
