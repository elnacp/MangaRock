using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using UnityEngine.UI;

public class FirebaseController : MonoBehaviour
{

    FirebaseFirestore db;
    Dictionary<string, object> user;
    [SerializeField] LoginController logincontroller;
    [SerializeField] RegisterController registercontroller;

    private bool error = false;
    private bool exitonlogin = false;

    private bool errorEmail = false;
    private bool errorUsername = false;

    private bool exitNoEmail = false;
    private bool usernameNoexist = false;

    private string username;
    private string email;
    private string password;

    // Start is called before the first frame update
    void Start()
    {
        db = FirebaseFirestore.DefaultInstance;   
    }

    private void Update()
    {
        if(error)
        {
            logincontroller.ErrorLogin();
            error = false;
        }

        if(exitonlogin)
        {
            logincontroller.ExitOnLogin();
            exitonlogin = false;
        }

        if(exitNoEmail)
        {
            UsernameValidation();
            exitNoEmail = false;
        }
  
        if(usernameNoexist)
        {
            RegisterUser();
            usernameNoexist = false;
        }

        if(errorEmail)
        {
            registercontroller.ErrorMailExist();
            errorEmail = false;
        }
        if (errorUsername)
        {
            registercontroller.ErrorUsernameExist();
            errorUsername = false;
        }

    }

    public void UserLogIn(string email, string password)
    {
        
        db.Collection("Users").WhereEqualTo("email", email).WhereEqualTo("contraseña", password).GetSnapshotAsync().ContinueWith((task) =>
        {
            if(task.IsCompleted)
            {
                if(task.Result.Count == 0)
                {
                    error = true;
                }

                foreach (DocumentSnapshot documentSnapshot in task.Result.Documents)
                {
                    exitonlogin = true;               
                }
            }
            else
            {
                Debug.Log("Error");
            }
        });

    }

    public void UserRegister(string username, string email, string password)
    {

        this.username = username;
        this.email = email;
        this.password = password;

        EmailValidation();

    }

    public void EmailValidation()
    {
        db.Collection("Users").WhereEqualTo("email", email).GetSnapshotAsync().ContinueWith((task) =>
        {
            if (task.IsCompleted)
            {
                if (task.Result.Count == 0)
                {
                    exitNoEmail = true;
                }
                else
                {
                    //Error message
                    errorEmail = true;

                }
            }
            else
            {
                Debug.Log("Error");
            }
        });
    }

    public void UsernameValidation()
    {
        db.Collection("Users").WhereEqualTo("username", username).GetSnapshotAsync().ContinueWith((task) =>
        {
            if (task.IsCompleted)
            {
                if (task.Result.Count == 0)
                {
                    usernameNoexist = true;
                }
                else
                {
                    //Error message
                    Debug.Log("Username exist");
                    errorUsername = true;
                }
            }
            else
            {
                Debug.Log("Error");
            }
        });
    }

    public void RegisterUser()
    {
        Debug.Log("Register User");
        logincontroller.BackButton();
        logincontroller.ReturnFromRegister();
        registercontroller.ExitRegister();
    }






}
