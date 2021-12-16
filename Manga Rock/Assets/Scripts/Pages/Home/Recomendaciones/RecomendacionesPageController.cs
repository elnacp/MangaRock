using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecomendacionesPageController : MonoBehaviour
{
    [SerializeField] GameObject prefabManga;
    [SerializeField] Transform contentRecomendaciones;

    //Print the list
    public void PrintList(List<MangaClass> list)
    {
        int index = 1;
        foreach(MangaClass info in list)
        {
            GameObject prefab = Instantiate(prefabManga, contentRecomendaciones);
            AddInformationElement(prefab, info, index);
            index++;
        }
    }

    //Add the information to the prefab
    private void AddInformationElement(GameObject element, MangaClass info, int index)
    {
            element.GetComponent<MangaWithPriceController>().AddInformation(
            info, index.ToString());
    }

    //Clear recomendations content
    public void CleanRecomendacionesList()
    {
        foreach (Transform child in contentRecomendaciones)
        {
            if (child.gameObject.tag == "manga")
            {
                Destroy(child.gameObject);
            }
        }
    }

}
