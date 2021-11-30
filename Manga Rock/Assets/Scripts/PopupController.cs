using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    [SerializeField] Canvas aplication;
    [SerializeField] Canvas popups;

    [SerializeField] GameObject añadirColeccion;
    [SerializeField] GameObject eliminarColeccion;
    [SerializeField] GameObject editarColeccion;
    [SerializeField] GameObject AddMangas;
    [SerializeField] GameObject CancelarSuscripcion;
    [SerializeField] GameObject eliminarMangaListaDeseos;
    [SerializeField] GameObject eliminarUsuario;

    [SerializeField] FirebasePageController firebase;

    


    private void Start()
    {
        popups.enabled = false;

    }

    private void HidePopups()
    {
        añadirColeccion.SetActive(false);
        eliminarColeccion.SetActive(false);
        editarColeccion.SetActive(false);
        AddMangas.SetActive(false);
        CancelarSuscripcion.SetActive(false);
        eliminarMangaListaDeseos.SetActive(false);
        eliminarUsuario.SetActive(false);
    }

    public void ActivatePopup(string page)
    {
        popups.enabled = true;

        HidePopups();

        switch(page)
        {
            case "deleteUser": eliminarUsuario.SetActive(true);
                break;
            
        }
    }

    public void HidePopup()
    {
        popups.enabled = false;
    }

    public void  PopupDeleteUser()
    {
        ActivatePopup("deleteUser");
    }

    public void DeleteUser()
    {
        firebase.DeleteUser();
    }

}
