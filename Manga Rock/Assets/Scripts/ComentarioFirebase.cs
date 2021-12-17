using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

//Comentario class firebase
[FirestoreData]
public class ComentarioFirebase
{
    [FirestoreProperty]
    public string Comentario { get; set; }
    [FirestoreProperty]
    public string username { get; set; }
    [FirestoreProperty]
    public int idManga { get; set; }
    [FirestoreProperty]
    public int likes { get; set; }
    [FirestoreProperty]
    public int valoracion { get; set; }
    [FirestoreProperty]
    public int dislikes { get; set; }
    [FirestoreProperty]
    public int IdComentario { get; set; }



}
