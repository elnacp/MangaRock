using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

[FirestoreData]
public class Colecciones 
{
    [FirestoreProperty]
    public string autor { get; set; }
    [FirestoreProperty]
    public int id { get; set; }
    [FirestoreProperty]
    public string nombre { get; set; }
    [FirestoreProperty]
    public string url { get; set; }
}
