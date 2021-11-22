using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

[FirestoreData]
public class Autor 
{
    [FirestoreProperty]
    public string nombre { get; set; }

    [FirestoreProperty]
    public int followers { get; set; }

    [FirestoreProperty]
    public string url { get; set; }
}
