using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionPageController : MonoBehaviour
{
    [SerializeField] Transform content;
    [SerializeField] GameObject prefabList;
    [SerializeField] GameObject prefabManga;

    public void AddInformation(List<ColeccionBibliotecaClass> list)
    {
        ClearContent();

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
        int num = 1;
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
                prefab.GetComponent<MangaWithNoPercentageControlle>().AddData(element.url, element.titulo, element.autor);
                f++;
            }
            if(f == 3)
            {
                indexContent++;
                f = 0;
            }
        }


        


    }

    public void ClearContent()
    {
        foreach(Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }
}
