using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HomeInit : MonoBehaviour
{

    UserClass userLogged = new UserClass();
    [SerializeField] RawImage image;
    [SerializeField] Text username;
    [SerializeField] Text email;

    [SerializeField] ProfileController profilePage;

    public void SaveUsername(string username)
    {
        userLogged.username = username;
    }

    public void SaveEmail(string email)
    {
        userLogged.email = email;
    }

    public void SaveUserLogged(List<UserClass> data)
    {
        if(data.Count != 0)
        {
            UserClass[] user = data.ToArray();
            userLogged = user[0];

            username.text = this.userLogged.username;
            email.text = this.userLogged.email;
            StartCoroutine(GetImage(this.userLogged.imagen));
        }
    }

    public UserClass GetUser()
    {
        return userLogged;
    }

    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }

    public void ReturnLogIn()
    {
        SceneManager.LoadScene("LogIn");
    }

    public string GetMail()
    {
        return userLogged.email;
    }



}
