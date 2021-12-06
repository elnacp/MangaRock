using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibraryController : MonoBehaviour
{
    [SerializeField] GameObject bibliotecaPanel;
    [SerializeField] GameObject coleccionesPanel;

    [SerializeField] GameObject button_biblioteca;
    [SerializeField] GameObject button_colecciones;

    [SerializeField] Transform leyendo;
    [SerializeField] Transform porLeer;
    [SerializeField] Transform finalizado;
    [SerializeField] Transform contentColecciones;
    [SerializeField] GameObject prefabList;
    [SerializeField] GameObject buttonAddCollection;
    

    [SerializeField] GameObject prefabWithPercentage;
    [SerializeField] GameObject prefabManga;
    [SerializeField] GameObject prefabTitle;

    [SerializeField] HomeInit userData;


    public void AddInformationBiblioteca(List<BibliotecaClass> list)
    {
        ClearContent(leyendo);
        ClearContent(porLeer);
        ClearContent(finalizado);

        foreach(BibliotecaClass element in list)
        {
            if(element.percentage == 0)
            {
                GameObject obj = Instantiate(prefabManga, porLeer);
                AddPrefabtoContent(obj, false, element);
            }
            else
            {
                if(element.percentage == 100)
                {
                    GameObject obj = Instantiate(prefabManga, finalizado);
                    AddPrefabtoContent(obj, false, element);
                }
                else
                {
                    GameObject obj = Instantiate(prefabWithPercentage, leyendo);
                    AddPrefabtoContent(obj, true, element);
                }
            }
        }
    }

    public void AddPrefabtoContent(GameObject prefab, bool percentage, BibliotecaClass element) 
    {
        if(percentage)
        {
            prefab.GetComponent<MangaWithPercentageController>().AddData(element.url, element.titulo, element.autor, element.percentage, element.paginas);
        }
        else
        {
            prefab.GetComponent<MangaWithNoPercentageControlle>().AddData(element.url, element.titulo, element.autor, element.paginas);
        }
    }


    public void AddInformationCollection(List<ColeccionBibliotecaClass> list)
    {

        Debug.Log(list);
        foreach(Transform child in contentColecciones)
        {
            if(child.name != "Añadir Coleccion")
            {
                Destroy(child.gameObject);
            }
        }

        List<string> listNombres = new List<string>();
        List<Transform> listContent = new List<Transform>();

        foreach(ColeccionBibliotecaClass element in list)
        {
            if (listNombres.Count == 0)
            {

                listNombres.Add(element.nombreColeccion);
            }
            else
            {
                bool encontrado = false;
                foreach(string nombre in listNombres)
                {

                    if(nombre == element.nombreColeccion)
                    {
                        encontrado = true;
                    }
                }
                if(!encontrado)
                {
                    listNombres.Add(element.nombreColeccion);
                }
            }
            
        }
        
        foreach(string nombre in listNombres)
        {
            GameObject title = Instantiate(prefabTitle, contentColecciones);
            title.transform.GetChild(0).GetComponent<Text>().text = nombre;
            GameObject content = Instantiate(prefabList, contentColecciones);

            foreach(ColeccionBibliotecaClass element in list)
            {
                if(nombre == element.nombreColeccion)
                {
                    GameObject prefab = Instantiate(prefabManga, content.transform.GetChild(0).GetChild(0).transform);
                    prefab.GetComponent<MangaWithNoPercentageControlle>().AddData(element.url, element.titulo, element.titulo, element.paginas);
                }
            }

        }

    }

    

    public void GoBiblioteca()
    {
        ButtonSelected(button_biblioteca);
        ButtonDeselected(button_colecciones);
        bibliotecaPanel.SetActive(true);
        coleccionesPanel.SetActive(false);
        buttonAddCollection.SetActive(false);
    }

    public void GoCollection()
    {
        buttonAddCollection.SetActive(true);
        ButtonSelected(button_colecciones);
        ButtonDeselected(button_biblioteca);
        bibliotecaPanel.SetActive(false);
        coleccionesPanel.SetActive(true);

        
    }

    public void ButtonSelected(GameObject button)
    {
        button.GetComponent<Image>().color = Color.black;
        button.transform.GetChild(0).GetComponent<Text>().color = Color.white;
    }

    public void ButtonDeselected(GameObject button)
    {
        button.GetComponent<Image>().color = Color.white;
        button.transform.GetChild(0).GetComponent<Text>().color = Color.black;
    }

    private void ClearContent(Transform content)
    {
        foreach(Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }
}
