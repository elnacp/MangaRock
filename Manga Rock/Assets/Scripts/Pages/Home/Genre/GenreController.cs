using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenreController : MonoBehaviour
{

    [SerializeField] Text title;
    [SerializeField] Transform content;
    [SerializeField] GameObject manga_list;
    [SerializeField] FirebasePageController firebase;

    void Start()
    {
        ClearContent();
    }

    public void GoCategory(string category)
    {
        ClearContent();

        title.text = "Género '"+category+"'";
        firebase.AskForCategoryMangas(category);
        
    }

    public void AddInformation(List<MangaClass> list)
    {
        int index = 1;
        foreach(MangaClass manga in list)
        {
            GameObject prefab = Instantiate(manga_list, content);
            prefab.GetComponent<MangaWithPriceController>().AddInformation(
                manga,
                index.ToString()
                );

            index++;
        }

    }

    private void ClearContent()
    {
        GameObject[] mangas = GameObject.FindGameObjectsWithTag("manga");
        foreach(GameObject manga in mangas)
        {
            Destroy(manga);
        }
    }

    

}
