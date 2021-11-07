using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class LoginController : MonoBehaviour
{

    [SerializeField] InputField email;
    [SerializeField] InputField password;

    [SerializeField] FirebaseController controller;

    // Start is called before the first frame update
    void Start()
    {
        
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

    
}
