using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WishlistPrefab : MonoBehaviour
{
    [SerializeField] Text number;
    [SerializeField] Text title;
    [SerializeField] RawImage image;
    [SerializeField] Text autor;
    [SerializeField] Text valoracio;
    [SerializeField] Text price;
    [SerializeField] Button addCard;

    WishlistClass manga;

    //Include all the information
    public void AddInformation(WishlistClass manga, int index)
    {
        title.text = manga.titulo;
        number.text = index.ToString();
        StartCoroutine(GetImage(manga.url));
        autor.text = manga.autor;
        valoracio.text = manga.valoracion.ToString();
        price.text = manga.precio + "€";

        this.manga = manga;
    }

    //Get the image from url
    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }

    //Ask to delete the manga (open the popup)
    public void DeleteManga()
    {
        FindObjectOfType<PopupController>().DeleteMangaWishlistPopup(manga);
    }
    
    //Return the title 
    public string GetTitleManga()
    {
        return manga.titulo;
    }

    //Goes to manga details
    public void MangaDetail()
    {
        MangaClass new_manga = new MangaClass();
        new_manga.autor = manga.autor;
        new_manga.genero = manga.genero;
        new_manga.id = manga.id;
        new_manga.idioma = manga.idioma;
        new_manga.paginas = manga.paginas;
        new_manga.precio = manga.precio;
        new_manga.resumen = manga.resumen;
        new_manga.tamaño = manga.tamaño;
        new_manga.titulo = manga.titulo;
        new_manga.url = manga.url;
        new_manga.valoracion = manga.valoracion;
        new_manga.idColeccion = manga.idColeccion;
        FindObjectOfType<PageController>().GoDetallesManga(new_manga);
    }

    //Add manga to shoplist
    public void AddMangaToCar()
    {
        string username = FindObjectOfType<HomeInit>().GetUser().username;

        Dictionary<string, object> new_manga = new Dictionary<string, object>
        {
            {"titulo", manga.titulo },
            {"autor", manga.autor },
            {"precio", manga.precio },
            {"cantidad", 1 },
            {"url", manga.url },
            {"username", username  },
        };
        FindObjectOfType<FirebasePageController>().AddToShopList(new_manga);
        addCard.interactable = false;
    }




}
