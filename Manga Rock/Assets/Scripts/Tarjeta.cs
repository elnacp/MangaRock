using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

[FirestoreData]
public class Tarjeta 
{
    [FirestoreProperty]
    public string username { get; set; }
    [FirestoreProperty]
    public string number { get; set; }
    [FirestoreProperty]
    public string fechaCaducidad { get; set; }
    [FirestoreProperty]
    public string cvv { get; set; }
}
