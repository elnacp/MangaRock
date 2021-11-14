using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

public class FirebasePageController : MonoBehaviour
{
    FirebaseFirestore db;
    List<int> mangasIds;
    List<MangaClass> mangaNovedades;

    private bool novedadesFinish = false;
    private bool searchFinish = false;
    private bool stop = false;

    [SerializeField] NovedadesController novedadesController;


    private void Start()
    {
        db = FirebaseFirestore.DefaultInstance;
        mangasIds = new List<int>();
        mangaNovedades = new List<MangaClass>();
    }

    private void Update()
    {
        if(novedadesFinish)
        {
            MangasForNovedades();
            novedadesFinish = false;
        }
        
        if(searchFinish)
        {
            if(mangaNovedades.Count == 10)
            {
                novedadesController.UpdateNovedades(mangaNovedades);
            }
            searchFinish = false;
        }
        
    }

    private void PrintNovedades()
    {
        foreach(MangaClass element in mangaNovedades)
        {
            Debug.Log(element.titulo);
        }
    }

    public void GetNovedades()
    {
        db.Collection("Novedades").GetSnapshotAsync().ContinueWith(task =>
        {
            QuerySnapshot allMangas = task.Result;
            List<int> ids = new List<int>();
            foreach (DocumentSnapshot documentSnapshot in allMangas.Documents)
            {
                Dictionary<string, object> document = documentSnapshot.ToDictionary();
                foreach (KeyValuePair<string, object> pair in document)
                {
                    ids.Add(int.Parse(pair.Value.ToString()));
                }
            }
            foreach(int id in ids)
            {
                mangasIds.Add(id);
            }
            novedadesFinish = true;
        });        
    }

    /*public void GetMangaInfo(int id)
    {
        db.Collection("Manga").WhereEqualTo("id", id).GetSnapshotAsync().ContinueWith(task =>
        {
            if(task.IsCompleted)
            {
                foreach (DocumentSnapshot documentSnapshot in task.Result.Documents)
                {
                    //Sava Manga Data
                }
            }
        });
    }*/

    public void GetMangaNovedades(int id)
    {
        db.Collection("Manga").WhereEqualTo("id", id).GetSnapshotAsync().ContinueWith(task =>
        {

            List<MangaClass> new_manga = new List<MangaClass>();
            foreach (DocumentSnapshot documentSnapshot in task.Result.Documents)
            {
                Manga info = documentSnapshot.ConvertTo<Manga>();
                MangaClass element = new MangaClass();
                element.autor = info.autor;
                element.genero = info.genero;
                element.id = info.id;
                element.idioma = info.idioma;
                element.paginas = info.paginas;
                element.precio = info.precio;
                element.resumen = info.resumen;
                element.tamaño = info.tamaño;
                element.titulo = info.titulo;
                element.url = info.url;
                element.valoracion = info.valoracion;

                new_manga.Add(element);
            }

            foreach(MangaClass i in new_manga)
            {
                mangaNovedades.Add(i);
            }
            searchFinish = true;
            //Debug.Log(new_manga.getAutor());

        });
    }

    public void MangasForNovedades()
    {
        foreach(int id in mangasIds)
        {
            GetMangaNovedades(id);
        }
    }

    
}
