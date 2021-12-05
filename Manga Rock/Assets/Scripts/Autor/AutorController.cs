using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutorController : MonoBehaviour
{

    [SerializeField] Text username;
    [SerializeField] RawImage image;
    [SerializeField] Text followers;
    [SerializeField] GameObject prefabManga;
    [SerializeField] GameObject contentManga;
    [SerializeField] GameObject contentCollection;


    public void AddInformation(string nombre, string url, int followers)
    {
        username.text = nombre;
        this.followers.text = followers.ToString();
        StartCoroutine(GetImage(url));
    }

    public void AddMangas(List<MangaClass> mangas)
    {

    }

    public void AddCollection()
    {

    }

    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }
}
