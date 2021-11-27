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
    List<MangaClass> listCategoria = new List<MangaClass>();

    List<TopElement> listPago;
    List<TopElement> listGratis;

    List<MangaClass> mangasSearch = new List<MangaClass>();
    List<AutorClass> autorSearch = new List<AutorClass>();
    List<UserClass> usersSearch = new List<UserClass>();

    List<MangaClass> mangasSameAutor = new List<MangaClass>();
    List<MangaClass> mangasSameColection = new List<MangaClass>();
    List<MangaClass> mangasSameCategory = new List<MangaClass>();
    List<UserClass> listUsers = new List<UserClass>();
    List<ComentarioClass> listComentarios;
    List<WishlistClass> wishlist = new List<WishlistClass>();

    private bool topListFinish = false;
    private bool novedadesFinish = false;
    private bool searchFinish = false;
    private bool searchTop = false;
    private bool stop = false;
    private bool recomendacionesFinish = false;
    private bool mangaisSearch = false;
    private bool autorisSearch = false;
    private bool categoriaSearch = false;
    private bool mangasSameAutorState = false;
    private bool mangasSameColectionState = false;
    private bool mangasSameCategoryState = false;
    private bool userinfodone = false;
    private bool logoutUser = false;
    private bool comentariosProfile = false;
    private bool wishlistSearchDone = false;
    private bool deleteWishListElement = false;
    private bool wishlistMangaexist = false;
    private bool stateWishlistManga = false;
    private bool userisSearch = false;


    private bool isLogged = false;
    private bool ask = false;
    private string titleWishlistToDelete = "";


    [SerializeField] NovedadesController novedadesController;
    [SerializeField] TopVentasController topVentas;
    [SerializeField] RecomendacionesController recomendacionesControlller;
    [SerializeField] SearchController searchController;
    [SerializeField] GenreController genreController;
    [SerializeField] DetallesMangaPageController detallesManga;
    [SerializeField] HomeInit homeinit;
    [SerializeField] ProfileController profileController;
    [SerializeField] WishlistController wishController;


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
        listComentarios = new List<ComentarioClass>();

        UserLogged();
        
    }

    private void Update()
    {

        if(stateWishlistManga)
        {
            detallesManga.StateWishButton(wishlistMangaexist);
            stateWishlistManga = false;
        }

        if(deleteWishListElement)
        {
            wishController.UpdateWishlist(titleWishlistToDelete);
            deleteWishListElement = true;
        }

        if(wishlistSearchDone)
        {
            wishController.AddMangas(wishlist);
            wishlistSearchDone = false;
        }

        if(comentariosProfile)
        {
            profileController.AddComentarios(listComentarios);
            comentariosProfile = false;
        }

        if(logoutUser)
        {
            homeinit.ReturnLogIn();
            logoutUser = false;
        }

        if(userinfodone)
        {
            homeinit.SaveUserLogged(listUsers);
            userinfodone = false;
        }


        if (novedadesFinish)
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

        if(mangaisSearch)
        {
            searchController.UpdateMangaList(mangasSearch);
            mangaisSearch = false;
        }

        if(autorisSearch)
        {
            searchController.UpdateAutor(autorSearch);
            autorisSearch = false;
        }

        if(userisSearch)
        {
            searchController.UpdateUsers(usersSearch);
            userisSearch = false;
        }

        if(categoriaSearch)
        {
            genreController.AddInformation(listCategoria);
            categoriaSearch = false;
        }

        if(mangasSameAutorState)
        {
            detallesManga.ListMangasSameAutor(mangasSameAutor);
            mangasSameAutorState = false;
        }

        if(mangasSameColectionState)
        {
            detallesManga.ListMangasSameColection(mangasSameColection);
            mangasSameColectionState = false;
        }

        if(mangasSameCategoryState)
        {
            detallesManga.ListMangasSameCategory(mangasSameCategory);
            mangasSameCategoryState = false;
        }
    }

    public void ShowWishList(string username)
    {
        wishlist.Clear();


        db.Collection("Wishlist").WhereEqualTo("username", username).GetSnapshotAsync().ContinueWith(task =>
        {
            List<WishlistClass> new_manga = new List<WishlistClass>();
            foreach (DocumentSnapshot documentSnapshot in task.Result.Documents)
            {
                Wishlist info = documentSnapshot.ConvertTo<Wishlist>();
                WishlistClass element = new WishlistClass();
                element.username = info.username;
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
                element.idColeccion = info.idColeccion;


                new_manga.Add(element);
            }

            foreach (WishlistClass i in new_manga)
            {
                wishlist.Add(i);
            }
            wishlistSearchDone = true;
            
        });
    }

    public void DeleteMangaWishlist(WishlistClass manga)
    {
        db.Collection("Wishlist").WhereEqualTo("titulo", manga.titulo).GetSnapshotAsync().ContinueWith(task =>
        {
            foreach (DocumentSnapshot documentSnapshot in task.Result.Documents)
            {
                Wishlist info = documentSnapshot.ConvertTo<Wishlist>();
                if(info.username == manga.username)
                {
                    documentSnapshot.Reference.DeleteAsync();
                    Debug.Log("Delete");
                    titleWishlistToDelete = manga.titulo;
                }
            }

            deleteWishListElement = true;
        });
    }

    public void AddToWishlist(WishlistClass manga)
    {
        //db.Collection("Wishlist").AddAsync(manga);
        Dictionary<string, object> new_manga = new Dictionary<string, object>
        {
            {"autor", manga.autor},
            {"genero", manga.genero},
            {"id", manga.id},
            {"idColeccion", manga.idColeccion},
            {"idioma", manga.idioma},
            {"paginas", manga.paginas},
            {"precio", manga.precio},
            {"resumen", manga.resumen},
            {"tamaño", manga.tamaño},
            {"titulo", manga.titulo},
            {"url", manga.url},
            {"username", manga.username},
            {"valoracion", manga.valoracion}
        };
        db.Collection("Wishlist").AddAsync(new_manga).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("manga is added");
            }
            else
            {
                Debug.Log("user is not added");
            }
        });

    }
    public void DeleteMangaFromWishlist(WishlistClass manga)
    {
        db.Collection("Wishlist").WhereEqualTo("titulo", manga.titulo).GetSnapshotAsync().ContinueWith(task =>
        {
            foreach (DocumentSnapshot documentSnapshot in task.Result.Documents)
            {
                Wishlist info = documentSnapshot.ConvertTo<Wishlist>();
                if (info.username == manga.username)
                {
                    documentSnapshot.Reference.DeleteAsync();
                    Debug.Log("Delete");
                }
            }
        });
    }

    public void InfoWishlist(WishlistClass manga)
    {
        wishlistMangaexist = false;
        db.Collection("Wishlist").WhereEqualTo("titulo", manga.titulo).GetSnapshotAsync().ContinueWith(task =>
        {
            if (task.Result.Count != 0)
            {
                foreach (DocumentSnapshot documentSnapshot in task.Result.Documents)
                {
                    Wishlist info = documentSnapshot.ConvertTo<Wishlist>();
                    if (info.username == manga.username)
                    {
                        //Ya esta en la lista
                        wishlistMangaexist = true;
                    }
                }
            }
            stateWishlistManga = true;
        });

    }

    private void UserLogged()
    {
        db.Collection("User").WhereEqualTo("loggeado", "yes").GetSnapshotAsync().ContinueWith((task) =>
        {

            QuerySnapshot query = task.Result;
            List<UserClass> users = new List<UserClass>();
            foreach (DocumentSnapshot documentSnapshot in query.Documents)
            {
                Users info = documentSnapshot.ConvertTo<Users>();
                UserClass element = new UserClass();
                element.contraseña = info.contraseña;
                element.loggeado = info.loggeado;
                element.descripcion = info.descripcion;
                element.email = info.email;
                element.followers = info.followers;
                element.id = info.id;
                element.following = info.following;
                element.idMangas = info.idMangas;
                element.generoFavorito = info.generoFavorito;
                element.imagen = info.imagen;
                element.loggeado = info.loggeado;
                element.username = info.username;

                users.Add(element);

            }
            foreach (UserClass element in users)
            {
                listUsers.Add(element);
            }
            userinfodone = true;

        });


    }

    public void ComentariosUser(string username)
    {

        db.Collection("Comentario").WhereEqualTo("username", username).GetSnapshotAsync().ContinueWith(task =>
        {
            QuerySnapshot query = task.Result;
            List<ComentarioClass> comentarios = new List<ComentarioClass>();
            foreach (DocumentSnapshot documentSnapshot in query.Documents)
            {
                ComentarioFirebase info = documentSnapshot.ConvertTo<ComentarioFirebase>();
                ComentarioClass element = new ComentarioClass();
                element.text = info.Comentario;
                element.username = info.username;
                element.idManga = info.idManga;
                element.likes = info.likes;
                element.valoracion = info.valoracion;
                element.dislikes = info.dislikes;
                element.id = info.IdComentario;

                comentarios.Add(element);

            }

            foreach (ComentarioClass element in comentarios)
            {
                listComentarios.Add(element);
            }

            comentariosProfile = true;


        });

        /*Debug.Log(username);
        db.Collection("Comentario").GetSnapshotAsync().ContinueWith((task) =>
        {


            /*QuerySnapshot query = task.Result;
            List<ComentarioClass> comentarios = new List<ComentarioClass>();
            foreach (DocumentSnapshot documentSnapshot in query.Documents)
            {
                ComentarioFirebase info = documentSnapshot.ConvertTo<ComentarioFirebase>();
                ComentarioClass element = new ComentarioClass();
                element.comentario = info.comentario;
                element.dislikes = info.Dislikes;
                element.id = info.IdComentario;
                element.idManga = info.IdManga;
                element.likes = info.Likes;
                element.valoracion = info.Valoracion;
                element.fecha = info.fecha;
                element.username = info.username;
                
                comentarios.Add(element);

            }

            Debug.Log("Hello");
            foreach (ComentarioClass element in comentarios)
            {
                listComentarios.Add(element);
            }
            comentariosProfile = true;
        });*/
    }

    public void UserLogOut()
    {

        db.Collection("User").WhereEqualTo("email", homeinit.GetMail()).GetSnapshotAsync().ContinueWith((task) =>
        {
            QuerySnapshot querySnapShot = task.Result;
            foreach (DocumentSnapshot document in querySnapShot.Documents)
            {
                document.Reference.UpdateAsync("loggeado", "no").ContinueWith(task =>
                {
                    logoutUser = true;
                });
            }
        });
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
                element.idColeccion = info.idColeccion;


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
                element.idColeccion = info.idColeccion;


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
                element.idColeccion = info.idColeccion;


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

    public void AskForCategoryMangas(string category)
    {
        if (listCategoria.Count != 0)
        {
            listCategoria.Clear();
        }


        db.Collection("Manga").WhereEqualTo("genero", category).GetSnapshotAsync().ContinueWith(task =>
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
                element.idColeccion = info.idColeccion;


                listMangas.Add(element);
            }

            foreach (MangaClass manga in listMangas)
            {
                listCategoria.Add(manga);
            }
            categoriaSearch = true;
        });
    }

    public void SearchInfo(string search)
    {
        AskForMangas(search);
        //AskForCollections();
        AskForAuthors(search);
        AskForUsersSearch(search);
    }

    private void AskForMangas(string title)
    {

        if(mangasSearch.Count != 0)
        {
            mangasSearch.Clear();
        }
        Debug.Log(mangasSearch.Count);

        db.Collection("Manga").WhereEqualTo("titulo", title).GetSnapshotAsync().ContinueWith(task =>
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
                element.idColeccion = info.idColeccion;


                listMangas.Add(element);
            }

            foreach (MangaClass manga in listMangas)
            {
                mangasSearch.Add(manga);
            }

            mangaisSearch = true;
            //Debug.Log(new_manga.getAutor());
        });
    }

    private void AskForAuthors(string name)
    {

        if (autorSearch.Count != 0)
        {
            autorSearch.Clear();
        }

        db.Collection("Autor").WhereEqualTo("nombre", name).GetSnapshotAsync().ContinueWith(task =>
        {
            List<AutorClass> listAutores = new List<AutorClass>();
            foreach (DocumentSnapshot documentSnapshot in task.Result.Documents)
            {
                Autor info = documentSnapshot.ConvertTo<Autor>();
                AutorClass element = new AutorClass();
                element.nombre = info.nombre;
                element.followers = info.followers;
                element.url = info.url;

                listAutores.Add(element);
            }

            foreach (AutorClass autores in listAutores)
            {
                autorSearch.Add(autores);
            }

            autorisSearch = true;
            //Debug.Log(new_manga.getAutor());
        });
    }

    private void AskForUsersSearch(string username)
    {

        if (usersSearch.Count != 0)
        {
            usersSearch.Clear();
        }
        db.Collection("User").WhereEqualTo("username", username).GetSnapshotAsync().ContinueWith(task =>
        {
            List<UserClass> list = new List<UserClass>();
            foreach (DocumentSnapshot documentSnapshot in task.Result.Documents)
            {
                Users info = documentSnapshot.ConvertTo<Users>();
                UserClass element = new UserClass();
                element.contraseña = info.contraseña;
                element.descripcion = info.descripcion;
                element.email = info.email;
                element.followers = info.followers;
                element.idMangas = info.idMangas;
                element.generoFavorito = info.generoFavorito;
                element.imagen = info.imagen;
                element.loggeado = info.loggeado;
                element.username = info.username;

                list.Add(element);
            }

            foreach (UserClass element in list)
            {
                usersSearch.Add(element);
            }

            userisSearch = true;
        });
    }


    public void MangasSameAutor(string autor)
    {
        //Clear List
        if (mangasSameAutor.Count != 0)
        {
            mangasSameAutor.Clear();
        }
        

        db.Collection("Manga").WhereEqualTo("autor", autor).GetSnapshotAsync().ContinueWith(task =>
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
                element.idColeccion = info.idColeccion;

                listMangas.Add(element);
            }

            foreach (MangaClass manga in listMangas)
            {
                mangasSameAutor.Add(manga);
            }

            mangasSameAutorState = true;
        });
    }

    public void MangasSameColection(int idColeccion)
    {
        //Clear List
        if (mangasSameColection.Count != 0)
        {
            mangasSameColection.Clear();
        }

        db.Collection("Manga").WhereEqualTo("idColeccion", idColeccion).GetSnapshotAsync().ContinueWith(task =>
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
                element.idColeccion = info.idColeccion;

                listMangas.Add(element);
            }

            foreach (MangaClass manga in listMangas)
            {
                mangasSameColection.Add(manga);
            }

            mangasSameColectionState = true;
        });
    }

    public void MangasSameCategory(string genero)
    {
        //Clear List
        if (mangasSameCategory.Count != 0)
        {
            mangasSameCategory.Clear();
        }

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
                element.idColeccion = info.idColeccion;

                listMangas.Add(element);
            }

            foreach (MangaClass manga in listMangas)
            {
                mangasSameCategory.Add(manga);
            }

            mangasSameCategoryState = true;
        });
    }
}
