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
    
    [SerializeField] Transform contentCommentarios;
    [SerializeField] GameObject prefabCommentario;
    [SerializeField] Text verMas;

    [SerializeField] GameObject mangaPrefab;

    [SerializeField] FirebasePageController firebase;
    [SerializeField] HomeInit homeinit;

    [SerializeField] Button wishlist_button;
    private List<ComentarioClass> comentariosManga = new List<ComentarioClass>();

    private bool showComments;

    MangaClass mangaData = new MangaClass();
    WishlistClass mangaWishlist;
    private bool isAdded = false;

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
        verMas.text = "Expandir";

        showComments = false;
        ClearComments();

        firebase.MangasSameAutor(manga.autor);
        firebase.MangasSameColection(manga.idColeccion);
        firebase.MangasSameCategory(manga.genero);
        firebase.GetCommentsOfManga(manga.id);

        mangaData = manga;


        mangaWishlist = new WishlistClass();
        mangaWishlist.username = homeinit.GetUser().username;
        mangaWishlist.autor = manga.autor;
        mangaWishlist.genero = manga.genero;
        mangaWishlist.id = manga.id;
        mangaWishlist.idioma = manga.idioma;
        mangaWishlist.paginas = manga.paginas;
        mangaWishlist.precio = manga.precio;
        mangaWishlist.resumen = manga.resumen;
        mangaWishlist.tamaño = manga.tamaño;
        mangaWishlist.titulo = manga.titulo;
        mangaWishlist.url = manga.url;
        mangaWishlist.valoracion = manga.valoracion;
        mangaWishlist.idColeccion = manga.idColeccion;

        firebase.InfoWishlist(mangaWishlist);

    }

    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }

    public void SaveComments(List<ComentarioClass> list)
    {
        foreach(ComentarioClass comentario in list)
        {
            comentariosManga.Add(comentario);
        }
    }

    public void ShowOrHideComentarios()
    {
        ClearComments();
        showComments = !showComments;
        if(showComments)
        {
            verMas.text = "Cerrar";
            foreach(ComentarioClass comment in comentariosManga)
            {
                GameObject prefab = Instantiate(prefabCommentario, contentCommentarios);
                prefab.GetComponent<ComentarioController>().AddInformation(comment, null);
            }
        }
        else
        {
            verMas.text = "Expandir";
        }

    }

    private void ClearComments()
    {
        foreach(Transform child in contentCommentarios)
        {
            if(child.tag == "comment")
            {
                Destroy(child.gameObject);
            }
        }
    }

    public void ListMangasSameAutor(List<MangaClass> mangas)
    {
        DeleteContent(contentMangasSameAutor);
        foreach(MangaClass element in mangas)
        {
            GameObject prefab = Instantiate(mangaPrefab, contentMangasSameAutor);
            AddInformationPrefab(prefab, element);
        }
    }

    public void StateWishButton(bool state)
    {
        if(state)
        {
            wishlist_button.GetComponent<WishlistButtonAnimation>().WishListButtonActive();
            isAdded = true;
        }
        else
        {
            wishlist_button.GetComponent<WishlistButtonAnimation>().WishListButtonDeactive();
            isAdded = false;
        }
    }

    public void ListMangasSameColection(List<MangaClass> mangas)
    {
        DeleteContent(contentMangasSameColection);
        foreach (MangaClass element in mangas)
        {
            GameObject prefab = Instantiate(mangaPrefab, contentMangasSameColection);
            AddInformationPrefab(prefab, element);
        }
    }

    public void ListMangasSameCategory(List<MangaClass> mangas)
    {
        DeleteContent(contentMangasSameCategory);
        foreach (MangaClass element in mangas)
        {
            GameObject prefab = Instantiate(mangaPrefab, contentMangasSameCategory);
            AddInformationPrefab(prefab, element);
        }
    }

    private void AddInformationPrefab(GameObject prefab, MangaClass manga)
    {
        prefab.GetComponent<MangaWithPricePrefab>().AddInformation(manga);
    }

    private void DeleteContent(Transform content)
    {
        foreach(Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }

    public void AddOrRemove()
    {
        if( isAdded )
        {
            isAdded = false;
        }
        else
        {
            isAdded = true;
        }

        if (isAdded)
        {
            AddToWishlist();
            Debug.Log("Add");
        }
        else
        {
            DeleteFromWishlist();
            Debug.Log("Remove");
        }
    }

    private void AddToWishlist()
    {
        firebase.AddToWishlist(mangaWishlist);
        wishlist_button.GetComponent<WishlistButtonAnimation>().WishListButtonActive();
    }

    private void DeleteFromWishlist()
    {
        firebase.DeleteMangaFromWishlist(mangaWishlist);
        wishlist_button.GetComponent<WishlistButtonAnimation>().WishListButtonDeactive();
    }




}
