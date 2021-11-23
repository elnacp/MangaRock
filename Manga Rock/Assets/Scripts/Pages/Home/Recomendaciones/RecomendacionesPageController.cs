using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecomendacionesPageController : MonoBehaviour
{
    [SerializeField] GameObject prefabManga;
    [SerializeField] Transform contentRecomendaciones;


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

    private void AddInformationElement(GameObject element, MangaClass info, int index)
    {
        element.GetComponent<MangaWithPriceController>().AddInformation(
            info.url,
            index.ToString(),
            info.titulo,
            info.autor,
            info.genero,
            info.precio.ToString(),
            info.valoracion.ToString());
    }

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
