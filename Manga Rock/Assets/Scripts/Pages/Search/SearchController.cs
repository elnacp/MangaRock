using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchController : MonoBehaviour
{

    [SerializeField] GameObject lastSearch;
    [SerializeField] GameObject searchList;

    [SerializeField] InputField textToSeach;

    [SerializeField] GameObject mangaPrefab;
    [SerializeField] GameObject profilePrefab;
    [SerializeField] Text contentNotFound;
    [SerializeField] GameObject collectionPrefab;

    [SerializeField] Transform contentMangas;
    [SerializeField] Transform contentColecciones;
    [SerializeField] Transform contentAutores;
    [SerializeField] Transform contentPerfiles;

    [SerializeField] FirebasePageController db;
    

    void Start()
    {
        DeleteChildList(contentMangas);
        DeleteChildList(contentColecciones);
        DeleteChildList(contentAutores);
        DeleteChildList(contentPerfiles);

        searchList.SetActive(false);
        lastSearch.SetActive(true);

    }

    private void Update()
    {
        if(textToSeach.text == "")
        {
            HideSearchList();
        }

    }

    public void Search()
    {
        HideLastSearch();

        if(textToSeach.text != "")
        {
            db.SearchInfo(textToSeach.text);
        }
        
    }


    public void UpdateAutor(List<AutorClass> autores)
    {
        DeleteChildList(contentAutores);
        if(autores.Count == 0)
        {
            Instantiate(contentNotFound, contentAutores);
        }
        else
        {
            foreach (AutorClass element in autores)
            {
                GameObject autor = Instantiate(profilePrefab, contentAutores);
                autor.GetComponent<ProfilePrefabController>().AddData(element.nombre, element.url, element.followers, "autor");
            }
        }
    }

    public void UpdateUsers(List<UserClass> users)
    {
        DeleteChildList(contentPerfiles);
        if(users.Count == 0)
        {
            Instantiate(contentNotFound, contentPerfiles);
        }
        else
        {
            foreach(UserClass element in users)
            {
                GameObject prefab = Instantiate(profilePrefab, contentPerfiles);
                prefab.GetComponent<ProfilePrefabController>().AddData(element.username, element.imagen, element.followers, "profileOther");
            }
        }
    }

    public void UpdateColectionList(List<ColeccionesClass> collection)
    {
        DeleteChildList(contentColecciones);
        if(collection.Count == 0)
        {
            Instantiate(contentNotFound, contentColecciones);
        }
        else
        {
            foreach(ColeccionesClass element in collection)
            {
                GameObject prefab = Instantiate(collectionPrefab, contentColecciones);
                prefab.GetComponent<CollectionPrefabController>().AddData(element.url, element.nombre, element.autor);
            }
        }
    }

    public void UpdateMangaList(List<MangaClass> mangas)
    {
        DeleteChildList(contentMangas);
        if(mangas.Count == 0)
        {
            Instantiate(contentNotFound, contentMangas);
        }
        else
        {
            foreach(MangaClass element in mangas)
            {
                AddMangaList(mangaPrefab, contentMangas, mangas);
            }
        }
    }

    private void AddMangaList(GameObject obj, Transform content, List<MangaClass> mangas)
    {
        foreach(MangaClass element in mangas)
        { 
            GameObject manga = Instantiate(obj, content);
            manga.GetComponent<MangaWithNoPercentageControlle>().AddData(element.url, element.titulo, element.autor, 0);
        }
    }

    private void DeleteChildList(Transform content)
    {
        foreach(Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }

    private void HideLastSearch()
    {
        searchList.SetActive(true);
        lastSearch.SetActive(false);
    }

    private void HideSearchList()
    {
        searchList.SetActive(false);
        lastSearch.SetActive(true);
    }

}
