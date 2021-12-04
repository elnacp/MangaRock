using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopListController : MonoBehaviour
{
    [SerializeField] Transform contentList;
    [SerializeField] GameObject prefabManga;
    [SerializeField] Text precioFinal;

    private float precioTotalList = 0;

    public void AddMangaList(List<ShopListClass> list)
    {

        float precio = 0;

        foreach(ShopListClass item in list)
        {
            GameObject prefab = Instantiate(prefabManga, contentList);
            prefab.GetComponent<MangaListCompra>().AddInformation(item);

            precio += item.precio * item.cantidad;
        }

        precioTotalList = precio;

        precioFinal.text = precio + "€";
    }

    public void ChangePrecioFinal(float precio, bool increase)
    { 
        if(increase)
        {
            precioTotalList += precio;
            precioFinal.text = precioTotalList.ToString();
        }
        else
        {
            precioTotalList -= precio;
            precioFinal.text = precioTotalList.ToString();
        }
    }

}
