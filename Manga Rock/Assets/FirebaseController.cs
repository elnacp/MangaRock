using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using UnityEngine.UI;

public class FirebaseController : MonoBehaviour
{

    FirebaseFirestore db;
    Dictionary<string, object> user;
    [SerializeField] LoginController uicontroller;

    private bool error = false;
    private bool exitonlogin = false;
   
    // Start is called before the first frame update
    void Start()
    {
        db = FirebaseFirestore.DefaultInstance;   
    }

    private void Update()
    {
        if(error)
        {
            uicontroller.ErrorLogin();
            error = false;
        }
        if(exitonlogin)
        {
            uicontroller.ExitonLogin();
            exitonlogin = false;
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
                    /*user = documentSnapshot.ToDictionary();
                    foreach (KeyValuePair<string, object> pair in user)
                    {
                        Debug.Log(("{0}:{1}", pair.Key, pair.Value));                        
                    }*/

                    exitonlogin = true;
                   
                }
            }
            else
            {
                Debug.Log("Error");
            }
        });

    }

    


}
