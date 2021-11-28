using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

[FirestoreData]
public class Biblioteca 
{
    [FirestoreProperty]
    public string username { get; set; }
    [FirestoreProperty]
    public string titulo { get; set; }
    [FirestoreProperty]
    public string autor { get; set; }
    [FirestoreProperty]
    public string idioma { get; set; }
    [FirestoreProperty]
    public int paginas { get; set; }
    [FirestoreProperty]
    public string url { get; set; }
    [FirestoreProperty]
    public float percentage { get; set; }

}
