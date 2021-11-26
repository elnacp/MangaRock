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
        num_mangas.text = data.idMangas.Count.ToString();
        //Comentarios



        num_followers.text = data.followers.ToString();
        num_following.text = data.following.Count.ToString();
    }


    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }
}
