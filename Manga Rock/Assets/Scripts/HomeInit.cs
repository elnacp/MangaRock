using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HomeInit : MonoBehaviour
{

    UserClass userLogged;
    [SerializeField] RawImage image;
    [SerializeField] Text username;
    [SerializeField] Text email;

    [SerializeField] ProfileController profilePage;

    private void Start()
    {
        
    }


    public void SaveUserLogged(List<UserClass> data)
    {
        UserClass[] user = data.ToArray();
        this.userLogged = user[0];

        username.text = this.userLogged.username;
        email.text = this.userLogged.email;
        StartCoroutine(GetImage(this.userLogged.imagen));
        profilePage.Setuser(user[0]);
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
