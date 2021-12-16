using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class AñadirColeccionController : MonoBehaviour
{
    [SerializeField] InputField nombre;

    //Add collection
    public void AñadirColeccion()
    {
        if(nombre.text != "")
        {
            string username = FindObjectOfType<HomeInit>().GetUser().username;
            Dictionary<string, object> manga = new Dictionary<string, object>
                {
                    {"autor", "Hero"},
                    {"idioma", "Español"},
                    {"nombreColeccion", nombre.text},
                    {"paginas", 90},
                    {"percentage", 100},
                    {"titulo", "horimiya 3"},
                    {"url", "https://www.normaeditorial.com/upload/media/albumes/0001/06/thumb_5648_albumes_big.jpeg"},
                    {"username", username }
                };
            FindObjectOfType<FirebasePageController>().AñadirMangaCollection(manga);

            FindObjectOfType<PopupController>().HidePopup();
            FindObjectOfType<PageController>().ChangePage("library");
        }
    }

}
