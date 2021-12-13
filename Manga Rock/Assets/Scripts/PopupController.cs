using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    [SerializeField] GameObject popups;

    [SerializeField] GameObject añadirColeccion;
    [SerializeField] GameObject eliminarColeccion;
    [SerializeField] GameObject editarColeccion;
    [SerializeField] GameObject AddMangas;
    [SerializeField] GameObject CancelarSuscripcion;
    [SerializeField] GameObject eliminarMangaListaDeseos;
    [SerializeField] GameObject eliminarUsuario;


    [SerializeField] FirebasePageController firebase;

    private string nameCollection = "";
    private string usernameUser = "";
    private WishlistClass mangaWihslist = new WishlistClass();

    private void Start()
    {
        popups.SetActive(false);
    }

    //Hide all the popups in the panel
    private void HideAllPopups()
    {
        añadirColeccion.SetActive(false);
        eliminarColeccion.SetActive(false);
        editarColeccion.SetActive(false);
        AddMangas.SetActive(false);
        CancelarSuscripcion.SetActive(false);
        eliminarMangaListaDeseos.SetActive(false);
        eliminarUsuario.SetActive(false);
    }

    //Activate the popup page
    public void ActivatePopup(string page)
    {
        //popups.enabled = true;

        HideAllPopups();

        switch(page)
        {
            case "deleteUser": eliminarUsuario.SetActive(true);
                break;

        }
    }

    //Hide the pop up panel
    public void HidePopup()
    {
        popups.SetActive(false);
    }

    //Open the popup to delete user
    public void  PopupDeleteUser()
    {
        ActivatePopup("deleteUser");
    }

    //Asj firebase to delete user
    public void DeleteUser()
    {
        firebase.DeleteUser();
    }

    //Open popup edit collection 
    public void GoEditarCollection(List<ColeccionBibliotecaClass> list, string name)
    {
        popups.SetActive(true);
        HideAllPopups();
        editarColeccion.SetActive(true);
        editarColeccion.GetComponent<EditarCollection>().AddMangas(list, name);
    }

    //Open popup add collection 
    public void GoAñadirCollection(List<ColeccionBibliotecaClass> list, string name)
    {
        popups.SetActive(true);
        HideAllPopups();
        AddMangas.SetActive(true);
        AddMangas.GetComponent<AñadirMangasCollectionController>().AddTitle(name);
        AddMangas.GetComponent<AñadirMangasCollectionController>().AddList(list);


        nameCollection = name;
        usernameUser = FindObjectOfType<HomeInit>().GetUser().username;
        firebase.GetAllMangasUser(usernameUser, name);
    }

    //Open popup delete collection
    public void GoEliminarCollection(string name)
    {
        popups.SetActive(true);
        HideAllPopups();
        eliminarColeccion.SetActive(true);

        nameCollection = name;
        usernameUser = FindObjectOfType<HomeInit>().GetUser().username;
    }

    //Accept button in delete collection
    public void DeleteCollection()
    {
        firebase.DeleteCollection(nameCollection, usernameUser);
    }

    //Open popup add new collection
    public void AñadirCollection()
    {
        popups.SetActive(true);
        HideAllPopups();
        añadirColeccion.SetActive(true);
    }

    //Open popup cancel suscription
    public void GoCancelSub()
    {
        popups.SetActive(true);
        HideAllPopups();
        CancelarSuscripcion.SetActive(true);
    }

    //Accept button in popup cancel suscription
    public void AcceptCancelSub()
    {

        HidePopup();
        string username = FindObjectOfType<HomeInit>().GetUser().username;
        FindObjectOfType<FirebasePageController>().UpdateSub(username, "no", "no");
        FindObjectOfType<SuscriptionController>().UpdateView("no", "no");
    }

    //Cancel button in popup cancel suscription
    public void CancelCancelSub()
    {
        HidePopup();
    }

    //Open popup delete manga from wishlist
    public void DeleteMangaWishlistPopup(WishlistClass manga)
    {
        popups.SetActive(true);
        HideAllPopups();
        eliminarMangaListaDeseos.SetActive(true);
        mangaWihslist = manga;
    }

    //Accept button in popup delete manga from wishlist
    public void AcceptDeleteManga()
    {
        HidePopup();
        FindObjectOfType<FirebasePageController>().DeleteMangaWishlist(mangaWihslist);
    }

    //Cancel button in popup delete manga from wishlist
    public void CancelPopup()
    {
        HidePopup();
    }


}
