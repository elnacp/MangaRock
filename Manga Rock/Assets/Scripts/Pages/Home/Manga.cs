using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

[FirestoreData]
public class Manga 
{
    [FirestoreProperty]
    public string autor { get; set; }
    [FirestoreProperty]
    public string genero { get; set; }
    [FirestoreProperty]
    public int id { get; set; }
    [FirestoreProperty]
    public string idioma { get; set; }
    [FirestoreProperty]
    public int paginas { get; set; }
    [FirestoreProperty]
    public float precio { get; set; }
    [FirestoreProperty]
    public string resumen { get; set; }
    [FirestoreProperty]
    public float tamaño { get; set; }
    [FirestoreProperty]
    public string titulo { get; set; }
    [FirestoreProperty]
    public string url { get; set; }
    [FirestoreProperty]
    public float valoracion { get; set; }
    [FirestoreProperty]
    public int idColeccion { get; set; }

}
