using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using UnityEngine.UI;


public class FirebaseConnection : MonoBehaviour
{

    //DatabaseReference reference;
    [SerializeField] InputField username_txt;
    [SerializeField] InputField email_txt;
    [SerializeField] InputField nameToGet;


    FirebaseFirestore db;
    Dictionary<string, object> user;


    // Start is called before the first frame update
    void Start()
    {
        //reference = FirebaseDatabase.DefaultInstance.RootReference;

        db = FirebaseFirestore.DefaultInstance;
    }

    public void saveData()
    {
        user = new Dictionary<string, object>
        {
            {"Username", username_txt.text},
            {"Email", email_txt.text}
        };

        db.Collection("Users").Document(username_txt.text).SetAsync(user).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("successfully added data to firebase");
            }
            else
            {
                Debug.Log("´not successfull");
            }
        });

        /*User user = new User();
        user.username = username_txt.text;
        user.email = email_txt.text;

        string json = JsonUtility.ToJson(user);

        reference.Child("User").Child(user.username).SetRawJsonValueAsync(json).ContinueWith(task => 
        { 
            if(task.IsCompleted)
            {
                Debug.Log("successfully added data to firebase");
            }
            else
            {
                Debug.Log("´not successfull");
            }
        });*/
    }

    public void readData()
    {
        db.Collection("Users").Document(nameToGet.text).GetSnapshotAsync().ContinueWith(task =>
        {
            if(task.IsCompleted)
            {
                DocumentSnapshot snapshot = task.Result;
                if(snapshot.Exists)
                {
                    user = snapshot.ToDictionary();
                    foreach(KeyValuePair<string, object>pair in user)
                    {
                        Debug.Log(("{0}:{1}", pair.Key, pair.Value));
                    }
                }

            }
        });
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
