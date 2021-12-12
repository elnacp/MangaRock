using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class LoginController : MonoBehaviour
{

    [SerializeField] InputField email;
    [SerializeField] InputField password;

    [SerializeField] SlideLogin loginPanel;
    [SerializeField] SlidePanel registerPanel;
    [SerializeField] SlidePanel recoverPassordPanel;

    [SerializeField] FirebaseController firebase_controller;

    [SerializeField] RegisterController registerController;

    [SerializeField] Button back;

    [SerializeField] GameObject loading;
    private bool loadingisOn = false;
    [SerializeField] Text message;
    

    // Start is called before the first frame update
    void Start()
    {
        back.gameObject.SetActive(false);
        message.text = "";
        loading.SetActive(false);
        
    }

    private void Update()
    {
           
    }

    //Show error message
    public void ErrorLogin()
    {
        loading.SetActive(false);
        message.text = "";
        message.text = "Error: Ha habido un error al iniciar sesión, comprueba el correo electrónico o la contraseña e intentalo de nuevo";
        message.color = Color.red;
    }

    //When firebase return okay on login change scene
    public void ExitOnLogin()
    {
        //Change scene
        SceneManager.LoadScene("Home");
        firebase_controller.Loggear(email.text);
    }

    //Button login click
    public void LogIn()
    {
        string _email = email.text;
        string _password = password.text;

        loading.SetActive(true);
        message.text = "";
        firebase_controller.UserLogIn(_email,_password);
             
    }

    //Abre registro
    public void OpenRegister()
    {
        ResetLogin();
        StartCoroutine(GoToRegister());
    }

    //Back button
    public void BackButton()
    {
        StartCoroutine(GoBackToLogin());
        registerController.ResetInputField();
    }

    //Vuelve del registro
    public void ReturnFromRegister()
    {
        message.text = "Se ha creado tu cuenta con exito! Prueba a loggearte";
        message.color = Color.black;
        registerController.ResetInputField();
    }

    //Vuelve de recuperar contraseña
    public void ReturnFromRecoverPassword()
    {
        message.text = "Se ha enviado un correo para recuperar tu contraseña.";
        message.color = Color.black;
        BackButton();
    }

    //Abre Recuperar contraseña
    public void OpenRecoverPassword()
    {
        ResetLogin();
        StartCoroutine(GoToRecoverPassword());
    }

    //hide login menu an open recover password
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

    //Hide panels when back
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

    //Reset login panel
    public void ResetLogin()
    {
        email.text = "";
        password.text = "";
        message.text = "";
        loading.SetActive(false);
    }
    
}
