using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

// paypal firebase
[FirestoreData]
public class Paypal 
{
    [FirestoreProperty]
    public string username { get; set; }
    [FirestoreProperty]
    public string email { get; set; }
}
