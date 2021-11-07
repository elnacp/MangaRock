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

    public void UserLogIn(string name)
    {

        db.Collection("Users").WhereEqualTo("email", name).GetSnapshotAsync().ContinueWith((task) =>
        {
            if(task.IsCompleted)
            {
                if(task.Result.Count == 0)
                {
                    Debug.Log("No existe");
                }

                foreach (DocumentSnapshot documentSnapshot in task.Result.Documents)
                {                 
                    user = documentSnapshot.ToDictionary();
                    foreach (KeyValuePair<string, object> pair in user)
                    {
                        Debug.Log(("{0}:{1}", pair.Key, pair.Value));
                    }
                }
            }
            else
            {
                Debug.Log("Error");
            }
        });
    }


}
