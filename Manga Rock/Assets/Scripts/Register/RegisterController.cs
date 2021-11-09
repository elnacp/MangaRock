using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] InputField username;
    [SerializeField] InputField email;
    [SerializeField] InputField password;
    [SerializeField] InputField other_password;

    [SerializeField] FirebaseController firebase_controller;

    [SerializeField] Text message;
    [SerializeField] GameObject loading;

    void Start()
    {
        message.text = "";
        loading.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Register()
    {

        loading.SetActive(true);

        string _username = username.text;
        string _email = email.text;
        string _password = password.text;
        string _otherpass = other_password.text;

        if(_username != "")
        {
            if(_email != "")
            {
                if(_password != "")
                {
                    if(_otherpass != "")
                    {
                        if(_password == _otherpass)
                        {
                            firebase_controller.UserRegister(_username, _email, _password);
                        }
                        else
                        {
                            ShowErrorDifferentPassword();
                        }
                    }
                    else
                    {
                        ShowErrorForm();
                    }
                }
                else
                {
                    ShowErrorForm();
                }
            }
            else
            {
                ShowErrorForm();
            }
        }
        else
        {
            ShowErrorForm();
        }

    }

    private void ShowErrorForm()
    {
        loading.SetActive(false);
        message.text = "Error: Hay algún campo del formulario vacío.";
    }

    private void ShowErrorDifferentPassword()
    {
        loading.SetActive(false);
        message.text = "Error: Error las dos contraseñas no coinciden.";
    }

    public void ErrorMailExist()
    {
        loading.SetActive(false);
        message.text = "Error: El email que estas usando ya existe en otra cuenta.";
    }

    public void ErrorUsernameExist()
    {
        loading.SetActive(false);
        message.text = "Error: El usuario que estas usando ya existe, prueba hacer uso de otro.";
    }

    public void ExitRegister()
    {
        loading.SetActive(false);
        message.text = "";
    }

    public void ResetInputField()
    {
        username.text = "";
        email.text = "";
        password.text = "";
        other_password.text = "";
    }

}
