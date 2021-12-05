using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

[FirestoreData]
public class Notificacion 
{
    [FirestoreProperty]
    public string url { get; set; }
    [FirestoreProperty]
    public string username { get; set; }
    [FirestoreProperty]
    public string tipo { get; set; }
    [FirestoreProperty]
    public string text_notis { get; set; }
    [FirestoreProperty]
    public int likes { get; set; }
    [FirestoreProperty]
    public int dislikes { get; set; }
    [FirestoreProperty]
    public int comentarios { get; set; }
}
