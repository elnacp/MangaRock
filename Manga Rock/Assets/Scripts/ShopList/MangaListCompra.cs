using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MangaListCompra : MonoBehaviour
{
    [SerializeField] RawImage image;
    [SerializeField] Text title;
    [SerializeField] Text autor;
    [SerializeField] Text cantidad;
    [SerializeField] Text precioFinal;

    [SerializeField] Button decrease;
    [SerializeField] Button add;


    private float total = 0;

    private ShopListClass item;

    public void AddInformation(ShopListClass manga)
    {
        StartCoroutine(GetImage(manga.url));
        title.text = manga.titulo;
        autor.text = manga.autor;
        cantidad.text = manga.cantidad.ToString();

        float precio = manga.precio * manga.cantidad;
        total = precio;

        precioFinal.text = precio + "€";

        item = manga;
    }

    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }

    public void AddCantidad()
    {
        item.cantidad++;
        cantidad.text = item.cantidad.ToString();

        total += item.precio;

        precioFinal.text = total + "€";

        if(item.cantidad > 0)
        {
            decrease.interactable = true;
        }
        if(item.cantidad == 5)
        {
            add.interactable = false;
        }

        FindObjectOfType<ShopListController>().ChangePrecioFinal(item.precio, true);
    }

    public void DecreseCantidad()
    {
        item.cantidad--;
        cantidad.text = item.cantidad.ToString();

        total -= item.precio;

        precioFinal.text = total + "€";

        if(item.cantidad == 0)
        {
            decrease.interactable = false;
        }
        if (item.cantidad > 0)
        {
            add.interactable = true;
        }

        FindObjectOfType<ShopListController>().ChangePrecioFinal(item.precio, false);

    }

    private void UpdateCantidad()
    {
        //FindObjectOfType<FirebasePageController>().UpdateCantidad();
    }
}
