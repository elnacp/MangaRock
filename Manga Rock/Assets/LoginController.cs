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
