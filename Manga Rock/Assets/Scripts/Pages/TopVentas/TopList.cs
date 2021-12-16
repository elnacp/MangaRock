using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

//Top List class firebase
[FirestoreData]
public class TopList 
{
    [FirestoreProperty]
    public string categoria { get; set; }
    [FirestoreProperty]
    public int idManga { get; set; }
    [FirestoreProperty]
    public int top { get; set; }

}
