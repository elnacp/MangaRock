using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProfilePrefabController : MonoBehaviour
{
    [SerializeField] RawImage image;
    [SerializeField] Text name;


    private string nombre;
    private int followers;
    private string tipo;
    private string url;


    public void AddData(string nombre, string url, int followers, string tipo)
    {
        this.name.text = nombre;
        this.nombre = nombre;
        StartCoroutine(GetImage(url));
        this.followers = followers;
        this.tipo = tipo;
        this.url = url;
    }

    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }

    public void OpenProfile()
    {
        if(tipo == "autor")
        {
            FindObjectOfType<PageController>().GoAutor(nombre, url, followers);
        }
        else
        {
            //FindObjectOfType<PageController>().GoAutor(nombre);
        }
    }
}
