using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditarPerfillController : MonoBehaviour
{
    [SerializeField] InputField username;
    [SerializeField] InputField email;
    [SerializeField] FirebasePageController firebase;
    [SerializeField] HomeInit userData;
    [SerializeField] Text message;


    private UserClass user = new UserClass();

    private void Start()
    {
        user = userData.GetUser();
        username.placeholder.GetComponent<Text>().text = user.username;
        email.placeholder.GetComponent<Text>().text = user.email;
    }

    public void EditarUsernameOrEmail()
    {
        message.text = "";
        if(username.text != "" && email.text != "")
        {
            firebase.UpdateProfile(username.text, email.text);
            userData.SaveEmail(email.text);
            userData.SaveUsername(username.text);
            message.text = "Se han actualizado los datos correctamente";
            message.color = Color.black;
        }
        else
        {
            message.text = "Error: parece que hay algun campo que esta vacio.";
            message.color = Color.red;
        }
        
    }



    public void CancelUpdate()
    {
        username.placeholder.GetComponent<Text>().text = user.username;
        email.placeholder.GetComponent<Text>().text = user.email;
    }



}
