using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

public class FirebasePageController : MonoBehaviour
{
    FirebaseFirestore db;
    List<int> mangasIds;
    List<MangaClass> mangaNovedades;
    List<MangaClass> topGratis;
    List<MangaClass> topPago;
    List<MangaClass> recomendaciones;

    List<TopElement> listPago;
    List<TopElement> listGratis;


   
    private bool topListFinish = false;
    private bool novedadesFinish = false;
    private bool searchFinish = false;
    private bool searchTop = false;
    private bool stop = false;
    private bool recomendacionesFinish = false;

  
    [SerializeField] NovedadesController novedadesController;
    [SerializeField] TopVentasController topVentas;
    [SerializeField] RecomendacionesController recomendacionesControlller;


    private void Start()
    {
        db = FirebaseFirestore.DefaultInstance;
        mangasIds = new List<int>();
        mangaNovedades = new List<MangaClass>();
        listPago = new List<TopElement>();
        listGratis = new List<TopElement>();
        topGratis = new List<MangaClass>();
        topPago = new List<MangaClass>();
        recomendaciones = new List<MangaClass>();
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
        
        if(topListFinish)
        {
            Debug.Log(listGratis.Count);
            Debug.Log(listPago.Count);
            //OrderListElements();
            //topVentas.TopListData(listPago, listGratis);
            if(listGratis.Count == 10 && listPago.Count == 10)
            {
                topVentas.TopListData(listPago, listGratis);
            }
            
            topListFinish = false;
        }

        if(searchTop)
        {
            if(topGratis.Count == 10 && topPago.Count == 10)
            {
                topVentas.AddInformationContent(topPago, topGratis);
            }
            searchTop = false;
        }

        if(recomendacionesFinish)
        {
            recomendacionesControlller.AddInformation(recomendaciones);
            recomendacionesFinish = false;
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

    public void AskTopList()
    {

        db.Collection("Top List").OrderBy("categoria").GetSnapshotAsync().ContinueWith(task =>
        {
            QuerySnapshot allMangas = task.Result;
            List<TopElement> listTops = new List<TopElement>();
            foreach (DocumentSnapshot documentSnapshot in allMangas.Documents)
            {
                TopList info = documentSnapshot.ConvertTo<TopList>();
                TopElement element = new TopElement();
                element.categoria = info.categoria;
                element.top = info.top;
                element.idManga = info.idManga;


                listTops.Add(element);
            }

            foreach(TopElement element in listTops)
            {
                if(element.categoria == "pago")
                {
                    listPago.Add(element);
                }
                else
                {
                    listGratis.Add(element);
                }
            }

            topListFinish = true;
        });
    }

    public void GetMangaTop(int id, string categoria)
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

            foreach (MangaClass i in new_manga)
            {
                if(categoria == "pago")
                {
                    topPago.Add(i);
                }
                else
                {
                    topGratis.Add(i);
                }
            }
            searchTop = true;

        });
    }

    public void AskMangasInfoTop(List<TopElement> list)
    {
        foreach(TopElement element in list)
        {
            if(element.categoria == "pago")
            {
                GetMangaTop(element.idManga, "pago");
            }
            else
            {
                GetMangaTop(element.idManga, "gratis");
            }
        }
    }


    public void RecomendationsForUser(string genero)
    {
        db.Collection("Manga").WhereEqualTo("genero", genero).GetSnapshotAsync().ContinueWith(task =>
        {
            List<MangaClass> listMangas = new List<MangaClass>();
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

                listMangas.Add(element);
            }

            foreach(MangaClass manga in listMangas )
            {
                recomendaciones.Add(manga);
            }
            recomendacionesFinish = true;
            //Debug.Log(new_manga.getAutor());
        });
    }

    public void GenreFav()
    {
        db.Collection("Users").WhereEqualTo("email", "elnacp@gmail.com").GetSnapshotAsync().ContinueWith(task =>
        {

            

        });
    }

}
