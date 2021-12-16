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
    [SerializeField] Transform contentManga;
    [SerializeField] Transform contentCollection;

    [SerializeField] Button seguir;
    [SerializeField] Image image_button;
    [SerializeField] Text text_button;

    private bool state = true;

    //Add all the information in the UI
    public void AddInformation(string nombre, string url, int followers)
    {
        username.text = nombre;
        this.followers.text = followers.ToString();
        StartCoroutine(GetImage(url));
        ClickButton();
    }

    //Change the state of the follow button
    public void ClickButton()
    {
        state = !state;
        if(state)
        {
            image_button.color = Color.black;
            text_button.color = Color.white;
            text_button.text = "Siguiendo";
        }
        else
        {
            image_button.color = Color.white;
            text_button.color = Color.black;
            text_button.text = "Seguir";
        }
    }

    //Add author mangas
    public void AddMangas(List<MangaClass> mangas)
    {
        ClearContent(contentManga);
        if(mangas.Count != 0)
        {
            foreach (MangaClass item in mangas)
            {
                GameObject prefab = Instantiate(prefabManga, contentManga);
                prefab.GetComponent<MangaWithNoPercentageControlle>().AddData(item.url, item.titulo, item.autor, 0);
            }
        }
        
    }

    //Add collections from author
    public void AddCollection(List<ColeccionesClass> colecciones)
    {
        Debug.Log(colecciones.Count);
        ClearContent(contentCollection);
        if(colecciones.Count != 0)
        {
            foreach(ColeccionesClass item in colecciones)
            {
                GameObject prefab = Instantiate(prefabManga, contentCollection);
                prefab.GetComponent<MangaWithNoPercentageControlle>().AddData(item.url, item.nombre, item.autor, 0);
            }
        }
    }

    //Make the url image a image
    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }

    //Clear the content
    private void ClearContent(Transform content)
    {
        foreach(Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }
}
