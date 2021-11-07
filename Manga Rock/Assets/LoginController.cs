using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LoginController : MonoBehaviour
{

    [SerializeField] Text email;
    [SerializeField] Text password;

    [SerializeField] FirebaseController controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LogIn()
    {
        controller.UserLogIn(email.text);
    }

    
}
