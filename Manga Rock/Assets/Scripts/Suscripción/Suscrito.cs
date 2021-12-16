using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

//Suscrito class firebase
[FirestoreData]
public class Suscrito 
{
    [FirestoreProperty]
    public string username { get; set; }
    [FirestoreProperty]
    public string suscrito { get; set; }
    [FirestoreProperty]
    public string plan { get; set; }
}
