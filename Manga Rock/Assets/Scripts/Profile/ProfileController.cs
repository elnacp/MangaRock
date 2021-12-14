using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileController : MonoBehaviour
{
    [SerializeField] RawImage image;
    [SerializeField] Text username;
    [SerializeField] Text description;
    [SerializeField] Text num_mangas;
    [SerializeField] Text num_comentarios;
    [SerializeField] Text num_followers;
    [SerializeField] Text num_following;

    [SerializeField] Transform contentMangas;
    [SerializeField] Transform contentComments;
    [SerializeField] GameObject prefabMangas;
    [SerializeField] GameObject prefabComents;

    [SerializeField] FirebasePageController db;

    UserClass user;

    private void Start()
    {
       
    }

    public void Setuser(UserClass data)
    {
        user = data;
        StartCoroutine(GetImage(data.imagen));
        username.text = data.username;
        description.text = data.descripcion;
        //num_mangas.text = data.idMangas.Count.ToString();
        //Comentarios

        db.ComentariosUser(data.username);
        db.UserMangas(data.username);

        num_followers.text = data.followers.ToString();
        num_following.text = 3.ToString();

        ClearContentComments();
        ClearMangas();

    }


    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }

    public void AddComentarios(List<ComentarioClass> comentarios)
    {

        num_comentarios.text = comentarios.Count.ToString();
        //Debug.Log(comentarios.Count);
        int i = 0;
        foreach(ComentarioClass comment in comentarios)
        {
            if( i < 10)
            {
                GameObject element = Instantiate(prefabComents, contentComments);
                element.GetComponent<ComentarioController>().AddInformation(comment, user.imagen);
            }
            i++;
            
        }
        
    }
    public void AddMangas(List<BibliotecaClass> mangas)
    {
        foreach(BibliotecaClass element in mangas)
        {
            if(element.percentage != 0 && element.percentage != 100)
            {
                GameObject prefab = Instantiate(prefabMangas, contentMangas);
                prefab.GetComponent<MangaWithPercentageController>().AddData(element.url, element.titulo, element.autor, element.percentage, element.paginas);
            }
        }

        num_mangas.text = mangas.Count.ToString();
    }

    public void ClearContentComments()
    {
        foreach(Transform child in contentComments)
        {
            if(child.tag == "comment")
            {
                Destroy(child.gameObject);
            }
        }
    }

    private void ClearMangas()
    {
        foreach (Transform child in contentMangas)
        {
            Destroy(child.gameObject);
        }
    }
}
