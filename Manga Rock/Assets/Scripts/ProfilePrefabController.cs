using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfilePrefabController : MonoBehaviour
{
    [SerializeField] RawImage image;
    [SerializeField] Text name;

    public void AddData(string nombre, string url)
    {
        this.name.text = nombre;
        StartCoroutine(GetImage(url));
    }

    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }
}
