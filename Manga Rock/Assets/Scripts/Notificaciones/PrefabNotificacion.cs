using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabNotificacion : MonoBehaviour
{
    [SerializeField] RawImage image;
    [SerializeField] Text title;
    [SerializeField] GameObject comment;
    [SerializeField] Text text;
    
    //Add information in the notification
    public void AddInformation(NotificacionClass notificacion)
    {
        StartCoroutine(GetImage(notificacion.url));

        string new_commnet = notificacion.username;

        switch(notificacion.tipo)
        {
            case "comentario": 
                new_commnet += " - Ha respondido a tu comentario";
                comment.SetActive(true);
                text.text = notificacion.text_notis;
                break;
            case "like":
                new_commnet += " - Le ha dado like a tu comentario";
                comment.SetActive(false);
                break;
            case "dislike":
                new_commnet += " - Le ha dado dislike a tu comentario";
                comment.SetActive(false);
                break;
        }

        title.text = new_commnet;



    }

    //Get the image from the link
    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }



}
