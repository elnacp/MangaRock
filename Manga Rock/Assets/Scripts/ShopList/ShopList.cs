using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

//shoplist class firebase
[FirestoreData]
public class ShopList 
{
    [FirestoreProperty]
    public string titulo { get; set; }
    [FirestoreProperty]
    public string autor { get; set; }
    [FirestoreProperty]
    public float precio { get; set; }
    [FirestoreProperty]
    public int cantidad { get; set; }
    [FirestoreProperty]
    public string url { get; set; }
    [FirestoreProperty]
    public string username { get; set; }

}
