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
    private bool userAdded = false;
    private bool exitOnMail = false;

    private string username;
    private string email;
    private string password;
    private string verify_password;

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

        if(userAdded)
        {
            ReturnToLogin();
            userAdded = false;
        }

    }

    

    public void UserLogIn(string email, string password)
    {
        this.verify_password = password;
        
        db.Collection("User").WhereEqualTo("email", email).GetSnapshotAsync().ContinueWith((task) =>
        {
            if(task.IsCompleted)
            {
                if(task.Result.Count == 0)
                {
                    error = true;
                }

                bool lookData = false;
                foreach (DocumentSnapshot documentSnapshot in task.Result.Documents)
                {
                    foreach (KeyValuePair<string, object> pair in documentSnapshot.ToDictionary())
                    {
                        /*if(pair.Value.ToString() == password)
                        {
                            exitonlogin = true;
                        }*/
                        if(pair.Key == "contraseña")
                        {
                            lookData = true;
                        }
                        if (pair.Value.ToString() == password && lookData)
                        {
                            exitonlogin = true;
                            lookData = false;
                        }
                    }

                    //exitonlogin = true;
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

    public void Loggear(string email)
    {
        db.Collection("User").WhereEqualTo("email", email).GetSnapshotAsync().ContinueWith((task) =>
        {
            QuerySnapshot querySnapShot = task.Result;
            foreach(DocumentSnapshot document in querySnapShot.Documents)
            {
                document.Reference.UpdateAsync("loggeado", "yes").ContinueWith(task =>
                {
                    Debug.Log("Update");
                });
            }    
        });
    }

    public void EmailValidation()
    {
        db.Collection("User").WhereEqualTo("email", email).GetSnapshotAsync().ContinueWith((task) =>
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
        db.Collection("User").WhereEqualTo("username", username).GetSnapshotAsync().ContinueWith((task) =>
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
        user = new Dictionary<string, object>
        {
            {"contraseña", password},
            {"descripcion", ""},
            {"email", email},
            {"followers", 0 },
            {"following", null },
            {"generoFavorito", "Aventura"},
            {"idMangas", null },
            {"imagen", "https://cdn.computerhoy.com/sites/navi.axelspringer.es/public/styles/1200/public/media/image/2018/08/fotos-perfil-whatsapp_16.jpg?itok=fl2H3Opv" },
            {"loggeado", "no"},
            {"username", username}
        };

        db.Collection("User").AddAsync(user).ContinueWith(task =>
        {
            if(task.IsCompleted)
            {
                Debug.Log("user is added");
                userAdded = true;
            }
            else
            {
                Debug.Log("user is not added");
            }
        });


    }

    public void ReturnToLogin()
    {
        logincontroller.BackButton();
        logincontroller.ReturnFromRegister();
        registercontroller.ExitRegister();
    }






}
