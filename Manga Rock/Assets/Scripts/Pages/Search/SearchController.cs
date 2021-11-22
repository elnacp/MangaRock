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

        Debug.Log(textToSeach.text);

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
                autor.GetComponent<ProfilePrefabController>().AddData(element.nombre, element.url);
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
            manga.GetComponent<MangaWithNoPercentageControlle>().AddData(element.url, element.titulo, element.autor);
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
