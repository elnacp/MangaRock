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

    //Add the information
    public void AddData(string nombre, string url, int followers, string tipo)
    {
        this.name.text = nombre;
        this.nombre = nombre;
        StartCoroutine(GetImage(url));
        this.followers = followers;
        this.tipo = tipo;
        this.url = url;
    }

    //get image from url
    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }

    //open the profile of the user
    public void OpenProfile()
    {
        if(tipo == "autor")
        {
            FindObjectOfType<PageController>().GoAutor(nombre, url, followers);
        }
        else
        {
            FindObjectOfType<PageController>().GoProfileOther(nombre, url, followers);
        }
    }
}
