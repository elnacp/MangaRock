using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    [SerializeField] GameObject popups;

    [SerializeField] GameObject a�adirColeccion;
    [SerializeField] GameObject eliminarColeccion;
    [SerializeField] GameObject editarColeccion;
    [SerializeField] GameObject AddMangas;
    [SerializeField] GameObject CancelarSuscripcion;
    [SerializeField] GameObject eliminarMangaListaDeseos;
    [SerializeField] GameObject eliminarUsuario;


    [SerializeField] FirebasePageController firebase;

    private string nameCollection = "";
    private string usernameUser = "";


    private void Start()
    {
        popups.SetActive(false);
    }

    private void HideAllPopups()
    {
        a�adirColeccion.SetActive(false);
        eliminarColeccion.SetActive(false);
        editarColeccion.SetActive(false);
        AddMangas.SetActive(false);
        CancelarSuscripcion.SetActive(false);
        eliminarMangaListaDeseos.SetActive(false);
        eliminarUsuario.SetActive(false);
    }

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

    public void HidePopup()
    {
        popups.SetActive(false);
    }

    public void  PopupDeleteUser()
    {
        ActivatePopup("deleteUser");
    }

    public void DeleteUser()
    {
        firebase.DeleteUser();
    }

    public void GoEditarCollection(List<ColeccionBibliotecaClass> list, string name)
    {
        popups.SetActive(true);
        HideAllPopups();
        editarColeccion.SetActive(true);
        editarColeccion.GetComponent<EditarCollection>().AddMangas(list, name);
    }

    public void GoA�adirCollection(List<ColeccionBibliotecaClass> list, string name)
    {
        popups.SetActive(true);
        HideAllPopups();
        AddMangas.SetActive(true);
        AddMangas.GetComponent<A�adirMangasCollectionController>().AddTitle(name);
        AddMangas.GetComponent<A�adirMangasCollectionController>().AddList(list);


        nameCollection = name;
        usernameUser = FindObjectOfType<HomeInit>().GetUser().username;
        firebase.GetAllMangasUser(usernameUser, name);
    }

    public void GoEliminarCollection(string name)
    {
        popups.SetActive(true);
        HideAllPopups();
        eliminarColeccion.SetActive(true);

        nameCollection = name;
        usernameUser = FindObjectOfType<HomeInit>().GetUser().username;
    }

    public void DeleteCollection()
    {
        firebase.DeleteCollection(nameCollection, usernameUser);
    }

    public void A�adirCollection()
    {
        popups.SetActive(true);
        HideAllPopups();
        a�adirColeccion.SetActive(true);
    }




}
