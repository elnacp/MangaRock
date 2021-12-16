using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditarContraseñaController : MonoBehaviour
{
    [SerializeField] Text message;
    [SerializeField] InputField password;
    [SerializeField] InputField repete_password;
    [SerializeField] FirebasePageController firebase;
    [SerializeField] HomeInit userData;

    private UserClass user = new UserClass();

    private void Start()
    {
        user = userData.GetUser();
    }

    //User click to update the password
    public void UpdatePassword()
    {
        message.text = "";
        if(password.text != repete_password.text)
        {
            message.text = "Error: Las dos contraseñas no coinciden. Vuelve a intentarlo.";
            message.color = Color.red;
        }
        else
        {
            if(password.text != "" && repete_password.text != "")
            {
                firebase.UpdatePassword(password.text);
                message.text = "Se ha actualizado la contraseña";
                message.color = Color.black;
            }
            else
            {
                message.text = "Error: parece que hay algun campo que esta vacio.";
                message.color = Color.red;
            }
        }
    }

    //User cancel the update
    public void CancelUpdate()
    {
        password.text = "";
        repete_password.text = "";
    }


}
