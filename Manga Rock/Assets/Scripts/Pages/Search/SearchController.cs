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

    [SerializeField] Transform contentMangas;
    [SerializeField] Transform contentColecciones;
    [SerializeField] Transform contentAutores;
    [SerializeField] Transform contentPerfiles;

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
    

    private void AddMangaList(GameObject obj, Transform content)
    {
        for(int i = 0; i < 5; i++)
        {
            GameObject manga = Instantiate(obj, content);
            manga.GetComponent<MangaWithNoPercentageControlle>().AddData("", "Title", "Author");
        }
    }

    private void DeleteChildList(Transform content)
    {
        foreach(Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }



}
