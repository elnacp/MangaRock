using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using UnityEngine.UI;


public class FirebaseConnection : MonoBehaviour
{

    DatabaseReference reference;
    [SerializeField] InputField username_txt;
    [SerializeField] InputField email_txt;


    // Start is called before the first frame update
    void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void saveData()
    {
        User user = new User();
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
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
