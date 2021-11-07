using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

public class FirebaseController : MonoBehaviour
{

    FirebaseFirestore db;
    Dictionary<string, object> user;

    // Start is called before the first frame update
    void Start()
    {
        db = FirebaseFirestore.DefaultInstance;
    }

    public bool UserLogIn(string email, string password)
    {

        bool exit = false;

        db.Collection("Users").WhereEqualTo("email", email).GetSnapshotAsync().ContinueWith((task) =>
        {
            if(task.IsCompleted)
            {
                if(task.Result.Count == 0)
                {
                    exit = false;
                }

                foreach (DocumentSnapshot documentSnapshot in task.Result.Documents)
                {                 
                    user = documentSnapshot.ToDictionary();
                    foreach (KeyValuePair<string, object> pair in user)
                    {
                        Debug.Log(("{0}:{1}", pair.Key, pair.Value));
                        exit = true;
                    }
                }
            }
            else
            {
                Debug.Log("Error");
            }
        });

        return exit;
    }


}
