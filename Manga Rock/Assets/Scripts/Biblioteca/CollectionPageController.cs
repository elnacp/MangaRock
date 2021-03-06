using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionPageController : MonoBehaviour
{
    [SerializeField] Transform content;
    [SerializeField] GameObject prefabList;
    [SerializeField] GameObject prefabManga;

    [SerializeField] Text nombreColeccion;

    [SerializeField] PopupController popupController;

    private List<ColeccionBibliotecaClass> listCollection = new List<ColeccionBibliotecaClass>();

    //Change the name of the collection
    public void ChangeName(string nombre)
    {
        nombreColeccion.text = nombre;
    }

    //Add the list of mangas from the collection
    public void AddInformation(List<ColeccionBibliotecaClass> list)
    {
        ClearContent();

        Debug.Log(list.Count);
        listCollection = list;

        List<ColeccionBibliotecaClass> new_list = new List<ColeccionBibliotecaClass>();

        string username = FindObjectOfType<HomeInit>().GetUser().username;

        foreach(ColeccionBibliotecaClass element in list)
        {
            if(element.username == username)
            {
                new_list.Add(element);
            }
        }

        int i = 0;
        int num = 0;
        if(list.Count > 0)
        {
            num = 1;
        }
        foreach(ColeccionBibliotecaClass element in list)
        {
            i++;
            if(i == 3)
            {

                num = num + 1;
                i = 0;
            }
        }

        List<GameObject> contents = new List<GameObject>();
        for(int e = 0; e < num; e++)
        {
            contents.Add(Instantiate(prefabList, content));
        }


        GameObject[] containers = contents.ToArray();
        int f = 0;
        int indexContent = 0;
        foreach(ColeccionBibliotecaClass element in list)
        {
            if(f < 3)
            {
                GameObject prefab = Instantiate(prefabManga, containers[indexContent].transform);
                prefab.GetComponent<MangaWithNoPercentageControlle>().AddData(element.url, element.titulo, element.autor, element.paginas);
                f++;
            }
            if(f == 3)
            {
                indexContent++;
                f = 0;
            }
        }


        


    }

    //Clear the content of the view
    public void ClearContent()
    {
        foreach(Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }

    //Click the button and open the pop-up to edit mangas
    public void EditCollection()
    {
        popupController.GoEditarCollection(listCollection, nombreColeccion.text);

    }

    //Click the button and open the pop-up to delete collection
    public void DeleteCollection()
    {
        popupController.GoEliminarCollection(nombreColeccion.text);
    }

    //Click the button and open the pop-up to add manga 
    public void A?adirManga()
    {
        popupController.GoA?adirCollection(listCollection, nombreColeccion.text);
    }
}
