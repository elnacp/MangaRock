using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopListPageController : MonoBehaviour
{
    [SerializeField] GameObject prefabManga;
    [SerializeField] Transform contentPago;
    [SerializeField] Transform contentGratuito;
    
    //Print the list
    public void PrintList(TopElement[] orderListPago, List<MangaClass> listMangasPago, TopElement[] orderListFree, List<MangaClass> listMangasFree)
    {

        ClearContent();


        for (int i = 0; i < orderListPago.Length; i++)
        {
            foreach(MangaClass manga in listMangasPago)
            {
                if (orderListPago[i].idManga == manga.id)
                {
                    GameObject prefab = Instantiate(prefabManga, contentPago);
                    AddInformationElement(prefab, manga, i+1);                   
                }
            }
        }

        for (int i = 0; i < orderListFree.Length; i++)
        {
            foreach (MangaClass manga in listMangasFree)
            {
                if (orderListFree[i].idManga == manga.id)
                {
                    GameObject prefab = Instantiate(prefabManga, contentGratuito);
                    AddInformationElement(prefab, manga, i+1);
                }
            }
        }

    }

    //Add information to the list
    private void AddInformationElement(GameObject element, MangaClass info, int index)
    {
        element.GetComponent<MangaWithPriceController>().AddInformation(
            info, index.ToString());
    }

    //Clear the content 
    private void ClearContent()
    {
        foreach (Transform child in contentPago)
        {
            if (child.gameObject.tag == "manga")
            {
                Destroy(child.gameObject);
            }
        }

        foreach (Transform child in contentGratuito)
        {
            if (child.gameObject.tag == "manga")
            {
                Destroy(child.gameObject);
            }
        }

    }

}
