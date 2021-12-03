using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class AñadirColeccionController : MonoBehaviour
{
    [SerializeField] InputField nombre;

    public void AñadirColeccion()
    {
        if(nombre.text != "")
        {
            string username = FindObjectOfType<HomeInit>().GetUser().username;
            Dictionary<string, object> manga = new Dictionary<string, object>
                {
                    {"autor", ""},
                    {"idioma", ""},
                    {"nombreColeccion", nombre.text},
                    {"paginas", ""},
                    {"percentage", ""},
                    {"titulo", ""},
                    {"url", ""},
                    {"username", username }
                };
            FindObjectOfType<FirebasePageController>().AñadirMangaCollection(manga);

            FindObjectOfType<PopupController>().HidePopup();
            FindObjectOfType<PageController>().ChangePage("library");
        }
    }

}
