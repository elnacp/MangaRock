using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class LoginController : MonoBehaviour
{

    [SerializeField] InputField email;
    [SerializeField] InputField password;

    [SerializeField] SlideLogin loginPanel;
    [SerializeField] SlidePanel registerPanel;
    [SerializeField] SlidePanel recoverPassordPanel;

    [SerializeField] Text message;
    

    [SerializeField] FirebaseController controller;

    [SerializeField] Button back;

    // Start is called before the first frame update
    void Start()
    {
        back.gameObject.SetActive(false);
    }

    public void LogIn()
    {
        string _email = email.text;
        string _password = password.text;

        bool exist = controller.UserLogIn(_email,_password);
        if( exist )
        {
            //Change scene
            Debug.Log("Change scene");
        }
        else
        {
            //Show error
            Debug.Log("Sorry error occure");

            EditMessage(0);
            message.text = "Error: parece que te has equivocado en el correo electrónico o en la contraseña. Prueba de nuevo";
        }      
    }

    private void EditMessage(int num)
    {
        switch(num)
        {
            case 0:
                message.text = "Error: parece que te has equivocado en el correo electrónico o en la contraseña. Prueba de nuevo";
                message.color = Color.red;
                break;
            case 1:
                message.text = "El usuario se ha creado con exito";
                message.color = Color.black;
                break;
            case 2:
                message.text = "Se ha enviado un correo a tu cuenta para recuperar la contraseña";
                message.color = Color.black;
                break;
        }
    }

    public void OpenRegister()
    {
        StartCoroutine(GoToRegister());
    }

    public void CloseForm()
    {
        StartCoroutine(GoBackToLogin());
    }

    public void OpenRecoverPassword()
    {
        StartCoroutine(GoToRecoverPassword());
    }

    IEnumerator GoToRecoverPassword()
    {
        loginPanel.ShowHideMenu();
        yield return new WaitForSeconds(0.5f);
        recoverPassordPanel.PanelSlide();
        back.gameObject.SetActive(true);
    }

    //hide login menu and open register menu
    IEnumerator GoToRegister()
    {
        loginPanel.ShowHideMenu();
        yield return new WaitForSeconds(0.5f);
        registerPanel.PanelSlide();
        back.gameObject.SetActive(true);
    }

    IEnumerator GoBackToLogin()
    {
        if(registerPanel.PanelState() == true)
        {
            //hide register panel active and return home
            registerPanel.PanelSlide();
           
        }
        else
        {
            //hide menu recover password
            recoverPassordPanel.PanelSlide();
        }

        yield return new WaitForSeconds(0.5f);
        loginPanel.ShowHideMenu();
        back.gameObject.SetActive(false);
    }
    
}
