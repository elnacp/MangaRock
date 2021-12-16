using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionPrefabController : MonoBehaviour
{
    
    [SerializeField] RawImage image;
    [SerializeField] Text nombre;
    [SerializeField] Text autor;

    //Add information in the collection prefab
    public void AddData(string url, string title, string author)
    {
        this.nombre.text = title;
        this.autor.text = author;
        StartCoroutine(GetImage(url));
    }

    //Get the image with the url
    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }
    

}
