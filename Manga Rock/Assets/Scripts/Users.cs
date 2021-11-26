using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

[FirestoreData]
public class Users
{

    [FirestoreProperty]
    public string contraseña { get; set; }
    [FirestoreProperty]
    public string descripcion { get; set; }
    [FirestoreProperty]
    public string email { get; set; }
    [FirestoreProperty]
    public int followers { get; set; }
    [FirestoreProperty]
    public int id { get; set; }
    [FirestoreProperty]
    public List<int>following { get; set; }
    [FirestoreProperty]
    public List<int>idMangas { get; set; }
    [FirestoreProperty]
    public string generoFavorito { get; set; }
    [FirestoreProperty]
    public string imagen { get; set; }
    [FirestoreProperty]
    public string loggeado { get; set; }
    [FirestoreProperty]
    public string username { get; set; }


}
