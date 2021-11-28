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

    [SerializeField] GameObject prefabWithPercentage;
    [SerializeField] GameObject prefabManga;

    [SerializeField] FirebasePageController firebase;
    [SerializeField] HomeInit userData;

    UserClass user = new UserClass();

    private void Start()
    {
        user = userData.GetUser();
    }

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
            prefab.GetComponent<MangaWithPercentageController>().AddData(element.url, element.titulo, element.autor, element.percentage);
        }
        else
        {
            prefab.GetComponent<MangaWithNoPercentageControlle>().AddData(element.url, element.titulo, element.autor);
        }
    }


    public void GoBiblioteca()
    {
        ButtonSelected(button_biblioteca);
        ButtonDeselected(button_colecciones);
        bibliotecaPanel.SetActive(true);
        coleccionesPanel.SetActive(false);
    }

    public void GoCollection()
    {
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
