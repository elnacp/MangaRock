using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AñadirMangasCollectionController : MonoBehaviour
{
    [SerializeField] GameObject prefabManga;
    [SerializeField] GameObject line;
    [SerializeField] Transform content;
    [SerializeField] Text title;

    private List<ColeccionBibliotecaClass> listMangasInCollection = new List<ColeccionBibliotecaClass>();
    private List<ColeccionBibliotecaClass> mangasAñadir = new List<ColeccionBibliotecaClass>();

    public void AddMangas(List<ColeccionBibliotecaClass> list)
    {

        ClearContent();

        mangasAñadir.Clear();


        int amount = list.Count;
        int i = 1;
        foreach (ColeccionBibliotecaClass element in list)
        {
            GameObject prefab = Instantiate(prefabManga, content);
            bool state = false;
            
            foreach(ColeccionBibliotecaClass element2 in listMangasInCollection)
            {
                if(element.titulo == element2.titulo)
                {
                    state = true;
                }
            }

            prefab.GetComponent<MangaAddToCollectionList>().AddManga(element, state);
            if (i != amount)
            {
                Instantiate(line, content);
            }
            i++;


        }

    }

    public void AddList(List<ColeccionBibliotecaClass> list)
    {
        listMangasInCollection.Clear();
        listMangasInCollection = list;
    }

    public void AddTitle(string name)
    {
        title.text = name;
    }

    private void ClearContent()
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }

    public void AddMangaList(ColeccionBibliotecaClass manga)
    {
        mangasAñadir.Add(manga);
    }

    public void DeleteMangaList(ColeccionBibliotecaClass manga)
    {
        Debug.Log("delete");
        mangasAñadir.Remove(manga);
    }


    public void Acceptar()
    {
        /*
        foreach(ColeccionBibliotecaClass element in listMangasInCollection)
        {
        }

        foreach(ColeccionBibliotecaClass element in mangasAñadir)
        {
            
        }

        FindObjectOfType<PopupController>().HidePopup();
        FindObjectOfType<CollectionPageController>().AddInformation(mangasAñadir);*/

        bool exist = false;
        foreach(ColeccionBibliotecaClass element in listMangasInCollection)
        {
            exist = false;
            foreach(ColeccionBibliotecaClass element2 in mangasAñadir)
            {
                if(element.titulo == element2.titulo)
                {
                    exist = true;
                }
            }
            if(!exist)
            {
                FindObjectOfType<FirebasePageController>().DeleteMangaCollection(element);
            }
        }

        bool exist2 = false;
        foreach(ColeccionBibliotecaClass element in mangasAñadir)
        {
            exist2 = false;
            foreach(ColeccionBibliotecaClass element2 in listMangasInCollection)
            {
                if(element.titulo == element2.titulo)
                {
                    exist2 = true;
                }
            }
            if(!exist2)
            {

                Dictionary<string, object> manga = new Dictionary<string, object>
                {
                    {"autor", element.autor},
                    {"idioma", element.idioma},
                    {"nombreColeccion", element.nombreColeccion},
                    {"paginas", element.paginas},
                    {"percentage", element.percentage},
                    {"titulo", element.titulo},
                    {"url", element.url},
                    {"username", element.username }
                };
                FindObjectOfType<FirebasePageController>().AñadirMangaCollection(manga);
            }
        }

        FindObjectOfType<PopupController>().HidePopup();
        FindObjectOfType<CollectionPageController>().AddInformation(mangasAñadir);
    }


    public void Cancelar()
    {
        FindObjectOfType<PopupController>().HidePopup();
        FindObjectOfType<CollectionPageController>().AddInformation(listMangasInCollection);
    }

}
