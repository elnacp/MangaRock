using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProfileOtherUserController : MonoBehaviour
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
    [SerializeField] GameObject prefabComentario;

    private bool state = true;
    private string urlImage = "";

    public void AddInformation(string nombre, string url, int followers)
    {
        username.text = nombre;
        this.followers.text = followers.ToString();
        StartCoroutine(GetImage(url));
        ClickButton();
        urlImage = url;
    }

    public void ClickButton()
    {
        state = !state;
        if (state)
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

    public void AddMangas(List<BibliotecaClass> mangas)
    {
        ClearContent(contentManga);
        if (mangas.Count != 0)
        {
            foreach (BibliotecaClass item in mangas)
            {
                GameObject prefab = Instantiate(prefabManga, contentManga);
                prefab.GetComponent<MangaWithNoPercentageControlle>().AddData(item.url, item.titulo, item.autor, 0);
            }
        }

    }

    public void AddComentarios(List<ComentarioClass> comentarios)
    {
        foreach(Transform child in contentCollection)
        {
            if(child.tag == "comment")
            {
                Destroy(child.gameObject);
            }
        }

        if (comentarios.Count != 0)
        {
            foreach (ComentarioClass item in comentarios)
            {
                GameObject prefab = Instantiate(prefabComentario, contentCollection);
                prefab.GetComponent<ComentarioController>().AddInformation(item, urlImage);
            }
        }
    }

    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }

    private void ClearContent(Transform content)
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }
}
