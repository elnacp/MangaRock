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

    //Ask to firebase the collection of that specific category
    public void GoCategory(string category)
    {
        ClearContent();

        title.text = "G?nero '"+category+"'";
        firebase.AskForCategoryMangas(category);
        
    }

    //Add the mangas
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

    //Clear the contents
    private void ClearContent()
    {
        GameObject[] mangas = GameObject.FindGameObjectsWithTag("manga");
        foreach(GameObject manga in mangas)
        {
            Destroy(manga);
        }
    }

    

}
