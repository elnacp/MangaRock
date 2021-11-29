using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComentarioController : MonoBehaviour
{
    [SerializeField] RawImage image;
    [SerializeField] Text likes;
    [SerializeField] Text dislikes;
    [SerializeField] Text username;
    [SerializeField] Text textComment;


    public void AddInformation(ComentarioClass data, string urlImage)
    {
        if(urlImage != null)
        {
            StartCoroutine(GetImage(urlImage));
        }
        likes.text = data.likes.ToString();
        dislikes.text = data.dislikes.ToString();
        username.text = data.username;
        textComment.text = data.text;
    }

    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }

}
