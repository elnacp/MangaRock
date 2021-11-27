using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionPrefabController : MonoBehaviour
{
    
    [SerializeField] RawImage image;
    [SerializeField] Text nombre;
    [SerializeField] Text autor;

    public void AddData(string url, string title, string author)
    {
        this.nombre.text = title;
        this.autor.text = author;
        StartCoroutine(GetImage(url));
    }

    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }
    

}
