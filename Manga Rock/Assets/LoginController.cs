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

    [SerializeField] GameObject loading;
    private bool loadingisOn = false;
    private float speed = 800f;
    [SerializeField] Text message;
    

    // Start is called before the first frame update
    void Start()
    {
        back.gameObject.SetActive(false);
        message.text = "";
        loadingStop();
    }

    private void Update()
    {
        if(loadingisOn)
        {
            message.text = "";
            loadingOn();
        }     
    }

    public void ErrorLogin()
    {
        loadingStop();
        loadingisOn = false;
        message.text = "";
        message.text = "Error: Ha habido un error al iniciar sesión, comprueba el correo electrónico o la contraseña e intentalo de nuevo";
        message.color = Color.red;
    }

    public void ExitonLogin()
    {
        //Change scen
        loadingisOn = false;
        Debug.Log("Exit on login");
    }

    public void loadingOn()
    {
        loading.SetActive(true);
        loading.GetComponent<RectTransform>().Rotate(0f, 0f, speed * Time.deltaTime);
    }

    public void loadingStop()
    {
        loading.SetActive(false);
    }

    public void LogIn()
    {
        string _email = email.text;
        string _password = password.text;

        loadingisOn = true;
        controller.UserLogIn(_email,_password);
             
    }


    public void OpenRegister()
    {
        StartCoroutine(GoToRegister());
    }

    public void BackButton()
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
