using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageController : MonoBehaviour
{

    [SerializeField] GameObject home;
    [SerializeField] GameObject library;
    [SerializeField] GameObject search;
    [SerializeField] GameObject notifications;
    [SerializeField] GameObject profile;
    [SerializeField] GameObject genre;
    [SerializeField] GameObject topVentas;
    [SerializeField] GameObject recomendacionesPage;
    [SerializeField] GameObject detallesManga;
    [SerializeField] GameObject wishlist;
    [SerializeField] GameObject suscription;
    [SerializeField] GameObject configuracion;
    [SerializeField] GameObject collectionpage;
    [SerializeField] GameObject listaCompra;
    [SerializeField] GameObject profileOtherUser;
    [SerializeField] GameObject autor;
    [SerializeField] GameObject lectorManga;

    [SerializeField] RectTransform parent;

    [SerializeField] MenuSlider menuController;
    [SerializeField] GameObject navigationBar;
    [SerializeField] GameObject actionBarMenu;
    [SerializeField] GameObject actionBarLector;
    [SerializeField] GameObject actionBarBackBlack;
    [SerializeField] GameObject bottomBarLector;


    [SerializeField] FirebasePageController firebase;
    [SerializeField] HomeInit userData;

    private string actualPage;

    private void Start()
    {
        actionBarMenu.SetActive(true);
        actionBarLector.SetActive(false);
        bottomBarLector.SetActive(false);
        navigationBar.SetActive(true);
        actionBarBackBlack.SetActive(false);
    }

    public void ChangePage(string name)
    {
        HidePages();

        switch(name)
        {
            case "home": home.SetActive(true);
                home.GetComponent<HomeController>().AddInformation();
                break;
            case "library": library.SetActive(true);
                library.GetComponent<LibraryController>().GoBiblioteca();
                firebase.GetBiblioteca(userData.GetUser().username);
                break;
            case "search": search.SetActive(true);
                break;
            case "notifications": notifications.SetActive(true);
                firebase.GetNotificaciones();
                break;
            case "profile": profile.SetActive(true);
                profile.GetComponent<ProfileController>().Setuser(userData.GetUser());
                break;
            case "collection": library.SetActive(true);
                firebase.GetCollections(userData.GetUser().username);
                break;
            case "collectionBiblioteca": library.SetActive(true);
                firebase.GetCollections(userData.GetUser().username);
                break;

        }

        actualPage = name;
    }


    public void GoListaCompra()
    {
        HideBarsAndShowBack();
        listaCompra.SetActive(true);

        listaCompra.GetComponent<ShopListController>().Init();

    }

    public void GoGenrePage(string category)
    {
        HideBarsAndShowBack();
        genre.SetActive(true);
        genre.GetComponent<GenreController>().GoCategory(category);
    }

    public void GoCollectionBiblioteca()
    {

        actualPage = "collectionBiblioteca";
        firebase.GetCollections(userData.GetUser().username);

    }

    public void GoTopList(TopElement[] orderListPago, List<MangaClass> listMangasPago, TopElement[] orderListFree, List<MangaClass> listMangasFree)
    {
        HideBarsAndShowBack();
        topVentas.SetActive(true);
        topVentas.GetComponent<TopListPageController>().PrintList(orderListPago, listMangasPago,orderListFree, listMangasFree);
    }

    public void GoRecomendaciones(List<MangaClass> recomendaciones)
    {
        HideBarsAndShowBack();
        recomendacionesPage.SetActive(true);
        recomendacionesPage.GetComponent<RecomendacionesPageController>().PrintList(recomendaciones);
    }

    public void GoDetallesManga(MangaClass manga)
    {
        HideBarsAndShowBack();
        detallesManga.SetActive(true);
        detallesManga.GetComponent<DetallesMangaPageController>().AddInformation(manga);
    }

    public void GoAutor(string nombre, string url, int followers)
    {
        HideBarsAndShowBack();
        autor.SetActive(true);
        autor.GetComponent<AutorController>().AddInformation(nombre, url, followers);

        firebase.GetMangasAutor(nombre);
        firebase.GetCollectionAutor(nombre);
    }

    public void GoProfileOther(string nombre, string url, int followers)
    {
        HideBarsAndShowBack();
        profileOtherUser.SetActive(true);
        profileOtherUser.GetComponent<ProfileOtherUserController>().AddInformation(nombre, url, followers);

        firebase.GetMangasProfile(nombre);
        firebase.ComentariosProfile(nombre);
    }
    
    public void GoCollectionPage(string nameCollection)
    {
        HideBarsAndShowBack();
        collectionpage.SetActive(true);
        collectionpage.GetComponent<CollectionPageController>().ChangeName(nameCollection);
        firebase.AskCollection(nameCollection);
        actualPage = "collection";
    }

    public void GoWishList()
    {
        HideBarsAndShowBack();
        wishlist.SetActive(true);
        menuController.Menu();   //hide menu
        firebase.ShowWishList(userData.GetUser().username);
    }
    
    public void GoSuscription()
    {
        HideBarsAndShowBack();
        suscription.SetActive(true);
        menuController.Menu();  //hide menu
        firebase.GetSuscripcion(userData.GetUser().username);
    }

    public void GoLectorMangas(int pages)
    {
        HideBarsAndAddLector();
        lectorManga.SetActive(true);
        lectorManga.GetComponent<LectorMangaControlelr>().AddPages(pages);
        
    }

    public void GoConfiguracion()
    {
        menuController.Menu();
        HideBarsAndShowBack();
        configuracion.SetActive(true);
        configuracion.GetComponent<ConfiguracionController>().GoConfiguracionPanel();
    }

    public void BackButton()
    {
        ShowBarAndHideSubPages();
    }

    private void ShowBarAndHideSubPages()
    {
        ChangePage(actualPage);
        navigationBar.SetActive(true);
        actionBarMenu.SetActive(true);
        actionBarBackBlack.SetActive(false);
        actionBarLector.SetActive(false);
        bottomBarLector.SetActive(false);

        parent.offsetMin = new Vector2(parent.offsetMin.x, 65);

    }

    private void HideBarsAndShowBack()
    {
        HidePages();
        actionBarMenu.SetActive(false);
        navigationBar.SetActive(false);
        actionBarBackBlack.SetActive(true);
        actionBarLector.SetActive(false);
        bottomBarLector.SetActive(false);


        parent.offsetMin = new Vector2(parent.offsetMin.x, 0);
        
    }

    private void HideBarsAndAddLector()
    {
        HidePages();
        actionBarMenu.SetActive(false);
        navigationBar.SetActive(false);
        actionBarBackBlack.SetActive(false);
        actionBarLector.SetActive(true);
        bottomBarLector.SetActive(true);


    }

    public void HidePages()
    {
        home.SetActive(false);
        library.SetActive(false);
        search.SetActive(false);
        notifications.SetActive(false);
        profile.SetActive(false);
        genre.SetActive(false);
        topVentas.SetActive(false);
        recomendacionesPage.SetActive(false);
        detallesManga.SetActive(false);
        wishlist.SetActive(false);
        suscription.SetActive(false);
        configuracion.SetActive(false);
        collectionpage.SetActive(false);
        listaCompra.SetActive(false);
        autor.SetActive(false);
        profileOtherUser.SetActive(false);
        lectorManga.SetActive(false);
    }


}
