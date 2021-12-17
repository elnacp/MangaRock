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
    List<ColeccionesClass> collectionSearch = new List<ColeccionesClass>();

    List<MangaClass> mangasSameAutor = new List<MangaClass>();
    List<MangaClass> mangasSameColection = new List<MangaClass>();
    List<MangaClass> mangasSameCategory = new List<MangaClass>();
    List<UserClass> listUsers = new List<UserClass>();
    List<ComentarioClass> listComentarios;
    List<WishlistClass> wishlist = new List<WishlistClass>();
    List<BibliotecaClass> bibliotecalist = new List<BibliotecaClass>();
    List<BibliotecaClass> bibliotecaPerfil = new List<BibliotecaClass>();
    List<ComentarioClass> comentariosManga = new List<ComentarioClass>();
    List<SuscritoClass> suscritoList = new List<SuscritoClass>();
    List<TarjetaClass> listTarjeta = new List<TarjetaClass>();
    List<PaypalClass> listPaypal = new List<PaypalClass>();
    List<ColeccionBibliotecaClass> listCollectionName = new List<ColeccionBibliotecaClass>();
    List<ColeccionBibliotecaClass> listMangasBiblioteca = new List<ColeccionBibliotecaClass>();
    List<ColeccionBibliotecaClass> listColeccionesBiblioteca = new List<ColeccionBibliotecaClass>();
    List<ShopListClass> listShopList = new List<ShopListClass>();
    List<TarjetaClass> tarjetasShopListList = new List<TarjetaClass>();
    List<PaypalClass> paypalsShopListList = new List<PaypalClass>();
    List<NotificacionClass> listNotificaciones = new List<NotificacionClass>();
    List<MangaClass> mangasAutor = new List<MangaClass>();
    List<BibliotecaClass> mangasProfile = new List<BibliotecaClass>();
    List<ComentarioClass> comentariosProfileList = new List<ComentarioClass>();
    List<ColeccionesClass> collectionAutor = new List<ColeccionesClass>();

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
    private bool colectionisSearch = false;
    private bool genreFavSearchDone = false;
    private bool bibliotecaSearch = false;
    private bool coleccionesBibliotecaSearch = false;
    private bool bibliotecaPerfilState = false;
    private bool comentariosMangaState = false;
    private bool suscritoSearch = false;
    private bool deleteUserDone = false;
    private bool finishPaypal = false;
    private bool finishTarjeta = false;
    private bool tarjetaRemoved = false;
    private bool paypalRemoved = false;
    private bool getMangasUserDone = false;
    private bool finishShopList = false;
    private bool tarjetaShopListFinish = false;
    private bool paypalShopListFinish = false;
    private bool notificacionesFinish = false;
    private bool collectionAutorFinish = false;
    private bool comentariosProfileListFinish = false;


    private bool isLogged = false;
    private bool ask = false;
    private string titleWishlistToDelete = "";
    private string genreFav = "";


    [SerializeField] NovedadesController novedadesController;
    [SerializeField] TopVentasController topVentas;
    [SerializeField] RecomendacionesController recomendacionesControlller;
    [SerializeField] SearchController searchController;
    [SerializeField] GenreController genreController;
    [SerializeField] DetallesMangaPageController detallesManga;
    [SerializeField] HomeInit homeinit;
    [SerializeField] ProfileController profileController;
    [SerializeField] WishlistController wishController;
    [SerializeField] LibraryController libraryController;
    [SerializeField] SuscriptionController suscriptionController;
    [SerializeField] MetododePago metodoPagoController;
    [SerializeField] ConfiguracionController configuracionController;

    private bool exitAddTarjeta = false;
    private bool notExitAddTarjeta = false;
    private bool exitAddPaypal = false;
    private bool notExitAddPaypal = false;
    private bool updateTarjetaDone = false;
    private bool updatePaypalDone = false;
    private bool coleccionNameDone = false;
    private bool collectionRemoved = false;
    private bool existeMangaShopList = false;
    private bool finishAddMangaShopList = false;
    private bool finishUnSub = false;
    private bool mangaAutorFinish = false;
    private bool mangaProfileFinish = false;


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

        if(collectionAutorFinish)
        {
            FindObjectOfType<AutorController>().AddCollection(collectionAutor);
            collectionAutorFinish = false;
        }

        if(notificacionesFinish)
        {
            FindObjectOfType<NotificacionesController>().AddNotificaciones(listNotificaciones);
            notificacionesFinish = false;
        }

        if(finishAddMangaShopList)
        {
            FindObjectOfType<DetallesMangaPageController>().CanBuy(existeMangaShopList);
            finishAddMangaShopList = false;
        }

        if(tarjetaShopListFinish)
        {
            FindObjectOfType<ShopListController>().AddTarjeta(tarjetasShopListList);
            tarjetaShopListFinish = false;
        }

        if(paypalShopListFinish)
        {
            FindObjectOfType<ShopListController>().AddPaypal(paypalsShopListList);
            paypalShopListFinish = false;
        }

        if(getMangasUserDone)
        {
            FindObjectOfType<AñadirMangasCollectionController>().AddMangas(listMangasBiblioteca);
            getMangasUserDone = false;
        }

        if (collectionRemoved)
        {
            FindObjectOfType<PopupController>().HidePopup();
            FindObjectOfType<PageController>().ChangePage("library");
            collectionRemoved = false;
        }

        if(mangaProfileFinish)
        {
            FindObjectOfType<ProfileOtherUserController>().AddMangas(mangasProfile);
            mangaProfileFinish = false;
        }

        if(comentariosMangaState)
        {
            detallesManga.SaveComments(comentariosManga);
            comentariosMangaState = false;
        }

        if(genreFavSearchDone)
        {
            recomendacionesControlller.GetRecomendacion(genreFav);
            genreFavSearchDone = false;
        }

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

        if(comentariosProfileListFinish)
        {
            FindObjectOfType<ProfileOtherUserController>().AddComentarios(comentariosProfileList);
            comentariosProfileListFinish = false;
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

        if(colectionisSearch)
        {
            searchController.UpdateColectionList(collectionSearch);
            colectionisSearch = false;
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

        if (bibliotecaSearch)
        {
            libraryController.AddInformationBiblioteca(bibliotecalist);
            bibliotecaSearch = false;
        }

        if(coleccionesBibliotecaSearch)
        {
            libraryController.AddInformationCollection(listColeccionesBiblioteca);
            coleccionesBibliotecaSearch = false;
        }

        if(bibliotecaPerfilState)
        {
            profileController.AddMangas(bibliotecaPerfil);
            bibliotecaPerfilState = false;
        }

        if(suscritoSearch)
        {
            suscriptionController.AddData(suscritoList);
            suscritoSearch = false;
        }

        if(finishPaypal)
        {
            metodoPagoController.AddPaypal(listPaypal);
            finishPaypal = false;
        }
        if (finishTarjeta)
        {
            metodoPagoController.AddTarjetas(listTarjeta);
            finishTarjeta = false;
        }

        if(exitAddTarjeta)
        {
            FindObjectOfType<AddTarjetaController>().AddMessageDone();
            exitAddTarjeta = false;
        }

        if(notExitAddTarjeta)
        {
            FindObjectOfType<AddTarjetaController>().AddMessageError();
            notExitAddTarjeta = false;
        }

        if (exitAddPaypal)
        {
            FindObjectOfType<AddPaypalController>().AddMessageDone();
            exitAddPaypal = false;
        }

        if (notExitAddPaypal)
        {
            FindObjectOfType<AddPaypalController>().AddMessageError();
            notExitAddPaypal = false;
        }

        if (tarjetaRemoved)
        {
            configuracionController.GoMetodoPago();
            tarjetaRemoved = false;
        }

        if(updateTarjetaDone)
        {
            FindObjectOfType<ShowTarjetaController>().MessageAddTarjeta();
            updateTarjetaDone = false;
        }

        if(updatePaypalDone)
        {
            FindObjectOfType<ShowPaypalController>().MessageUpdatePaypal();
            updatePaypalDone = false;
        }

        if(paypalRemoved)
        {
            configuracionController.GoMetodoPago();
            paypalRemoved = false;
        }

        if(coleccionNameDone)
        {
            FindObjectOfType<CollectionPageController>().AddInformation(listCollectionName);
            coleccionNameDone = false;
        }

        if(finishShopList)
        {
            FindObjectOfType<ShopListController>().AddMangaList(listShopList);
            finishShopList = false;
        }

        if(mangaAutorFinish)
        {
            FindObjectOfType<AutorController>().AddMangas(mangasAutor);
            mangaAutorFinish = false;
        }

        

    }

    //Add credit card
    public void AddTarjeta(Dictionary<string, object> tarjeta)
    {
        db.Collection("Tarjetas").AddAsync(tarjeta).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("tarjeta is added");
                exitAddTarjeta = true;
            }
            else
            {
                Debug.Log("tarjeta is not added");
                notExitAddTarjeta = true;
            }
        });
    }

    //Add paypal
    public void AddPaypal(Dictionary<string, object> paypal)
    {
        db.Collection("Paypal").AddAsync(paypal).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("tarjeta is added");
                exitAddPaypal = true;
            }
            else
            {
                Debug.Log("tarjeta is not added");
                notExitAddPaypal = true;
            }
        });
    }

    //ask for credit card
    public void AskTarjeta(string username)
    {
        listTarjeta.Clear();

        db.Collection("Tarjetas").WhereEqualTo("username", username).GetSnapshotAsync().ContinueWith(task =>
        {
            QuerySnapshot query = task.Result;
            List<TarjetaClass> list = new List<TarjetaClass>();
            foreach (DocumentSnapshot documentSnapshot in query.Documents)
            {
                TarjetaFirebase info = documentSnapshot.ConvertTo<TarjetaFirebase>();
                TarjetaClass element = new TarjetaClass();
                element.username = info.username;
                element.number = info.number;
                element.fechaCaducidad = info.fechaCaducidad;
                element.cvv = info.cvv;

                list.Add(element);

            }

            foreach (TarjetaClass element in list)
            {
                listTarjeta.Add(element);
            }

            finishTarjeta = true;

        });
    }

    //ask for paypal
    public void AskPaypal(string username)
    {

        listPaypal.Clear();

        db.Collection("Paypal").WhereEqualTo("username", username).GetSnapshotAsync().ContinueWith(task =>
        {
            QuerySnapshot query = task.Result;
            List<PaypalClass> list = new List<PaypalClass>();
            foreach (DocumentSnapshot documentSnapshot in query.Documents)
            {
                Paypal info = documentSnapshot.ConvertTo<Paypal>();
                PaypalClass element = new PaypalClass();
                element.username = info.username;
                element.email = info.email;

                list.Add(element);

            }

            foreach (PaypalClass element in list)
            {
                listPaypal.Add(element);
            }

            finishPaypal = true;

        });
    }

    //get shoplist
    public void GetShopList(string username)
    {
        listShopList.Clear();

        db.Collection("ShopList").WhereEqualTo("username", username).GetSnapshotAsync().ContinueWith(task =>
        {
            List<ShopListClass> list = new List<ShopListClass>();
            foreach (DocumentSnapshot documentSnapshot in task.Result.Documents)
            {
                ShopList info = documentSnapshot.ConvertTo<ShopList>();
                ShopListClass element = new ShopListClass();
                element.username = info.username;
                element.autor = info.autor;
                element.cantidad = info.cantidad;
                element.precio = info.precio;
                element.titulo = info.titulo;
                element.url = info.url;

                list.Add(element);
            }

            foreach (ShopListClass element in list)
            {
                listShopList.Add(element);
            }

            finishShopList = true;
        });
    }

    //update profile
    public void UpdateProfile(string username, string email)
    {
        db.Collection("User").WhereEqualTo("loggeado", "yes").GetSnapshotAsync().ContinueWith((task) =>
        {
            QuerySnapshot querySnapShot = task.Result;
            foreach (DocumentSnapshot document in querySnapShot.Documents)
            {
                document.Reference.UpdateAsync("username", username).ContinueWith(task =>
                {
                    Debug.Log("Update");
                });

                document.Reference.UpdateAsync("email", email).ContinueWith(task =>
                {
                    Debug.Log("Update");
                });
            }

        });
    }

    //update cantidad product in shoplist
    public void UpdateCantidad(int cantidad)
    {
        string username = FindObjectOfType<HomeInit>().GetUser().username;

        db.Collection("ShopList").WhereEqualTo("username", username).GetSnapshotAsync().ContinueWith((task) =>
        {
            QuerySnapshot querySnapShot = task.Result;
            foreach (DocumentSnapshot document in querySnapShot.Documents)
            {
                document.Reference.UpdateAsync("cantidad", cantidad).ContinueWith(task =>
                {
                    Debug.Log("Update cantidad");
                });
  
            }

        });
    }

    //get credit card
    public void GetTarjeta(string username)
    {

        tarjetasShopListList.Clear();

        db.Collection("Tarjetas").WhereEqualTo("username", username).GetSnapshotAsync().ContinueWith(task =>
        {
            QuerySnapshot query = task.Result;
            List<TarjetaClass> list = new List<TarjetaClass>();
            foreach (DocumentSnapshot documentSnapshot in query.Documents)
            {
                TarjetaFirebase info = documentSnapshot.ConvertTo<TarjetaFirebase>();
                TarjetaClass element = new TarjetaClass();
                element.username = info.username;
                element.number = info.number;
                element.fechaCaducidad = info.fechaCaducidad;
                element.cvv = info.cvv;

                list.Add(element);

            }

            foreach (TarjetaClass element in list)
            {
                tarjetasShopListList.Add(element);
            }

            tarjetaShopListFinish = true;

        });
    }

    //get paypal
    public void GetPaypal(string username)
    {

        tarjetasShopListList.Clear();

        db.Collection("Paypal").WhereEqualTo("username", username).GetSnapshotAsync().ContinueWith(task =>
        {
            QuerySnapshot query = task.Result;
            List<PaypalClass> list = new List<PaypalClass>();
            foreach (DocumentSnapshot documentSnapshot in query.Documents)
            {
                Paypal info = documentSnapshot.ConvertTo<Paypal>();
                PaypalClass element = new PaypalClass();
                element.username = info.username;
                element.email = info.email;

                list.Add(element);

            }

            foreach (PaypalClass element in list)
            {
                paypalsShopListList.Add(element);
            }

            paypalShopListFinish = true;

        });
    }

    //clear shoplist
    public void ClearShopList(string username)
    {
        db.Collection("ShopList").WhereEqualTo("username", username).GetSnapshotAsync().ContinueWith((task) =>
        {
            QuerySnapshot querySnapShot = task.Result;
            foreach (DocumentSnapshot document in querySnapShot.Documents)
            {
                document.Reference.DeleteAsync();
            }
        });
    }

    //update password
    public void UpdatePassword(string password)
    {
        db.Collection("User").WhereEqualTo("loggeado", "yes").GetSnapshotAsync().ContinueWith((task) =>
        {
            QuerySnapshot querySnapShot = task.Result;
            foreach (DocumentSnapshot document in querySnapShot.Documents)
            {
                document.Reference.UpdateAsync("contraseña", password).ContinueWith(task =>
                {
                    Debug.Log("Update");
                });

            }

        });
    }

    //update tarjeta
    public void UpdateTarjeta(TarjetaClass tarjeta)
    {
        Debug.Log("update tarjeta");

        db.Collection("Tarjetas").WhereEqualTo("username", tarjeta.username).GetSnapshotAsync().ContinueWith((task) =>
        {
            QuerySnapshot querySnapShot = task.Result;
            foreach (DocumentSnapshot document in querySnapShot.Documents)
            {
                document.Reference.UpdateAsync("number", tarjeta.number).ContinueWith(task =>
                {
                    Debug.Log("Update");
                });

                document.Reference.UpdateAsync("cvv", tarjeta.cvv).ContinueWith(task =>
                {
                    Debug.Log("Update");
                });

                document.Reference.UpdateAsync("fechaCaducidad", tarjeta.fechaCaducidad).ContinueWith(task =>
                {
                    Debug.Log("Update");
                });

                updateTarjetaDone = true;

            }

        });
    }

    //update paypal
    public void UpdatePaypal(PaypalClass paypal)
    {
        db.Collection("Paypal").WhereEqualTo("username", paypal.username).GetSnapshotAsync().ContinueWith((task) =>
        {
            QuerySnapshot querySnapShot = task.Result;
            foreach (DocumentSnapshot document in querySnapShot.Documents)
            {
                document.Reference.UpdateAsync("email", paypal.email).ContinueWith(task =>
                {
                    Debug.Log("Update");
                });

                updatePaypalDone = true;
              
            }

        });
    }

    //delete user
    public void DeleteUser()
    {
        db.Collection("User").WhereEqualTo("loggeado", "yes").GetSnapshotAsync().ContinueWith((task) =>
        {
            QuerySnapshot querySnapShot = task.Result;
            foreach (DocumentSnapshot document in querySnapShot.Documents)
            {
                document.Reference.DeleteAsync();
                deleteUserDone = true;
            }
            logoutUser = true;
        });
    }

    //Delete tarjeta
    public void DeleteTarjeta(TarjetaClass tarjeta)
    {
        db.Collection("Tarjetas").WhereEqualTo("username", tarjeta.username).GetSnapshotAsync().ContinueWith((task) =>
        {
            QuerySnapshot querySnapShot = task.Result;
            foreach (DocumentSnapshot document in querySnapShot.Documents)
            {
                document.Reference.DeleteAsync();
                tarjetaRemoved = true;
            }
        });
    }

    //ask if is in shoplist or not
    public void IsInShopList(string titulo, string username)
    {
        db.Collection("ShopList").WhereEqualTo("username", username).GetSnapshotAsync().ContinueWith((task) =>
        {
            existeMangaShopList = false;
            foreach (DocumentSnapshot documentSnapshot in task.Result.Documents)
            {
                ShopList info = documentSnapshot.ConvertTo<ShopList>();
                if (info.titulo == titulo)
                {
                    existeMangaShopList = true;
                }

            }
            finishAddMangaShopList = true;
        });
    }

    //Delete Paypal
    public void DeletePaypal(PaypalClass paypal)
    {
        db.Collection("Paypal").WhereEqualTo("username", paypal.username).GetSnapshotAsync().ContinueWith((task) =>
        {
            QuerySnapshot querySnapShot = task.Result;
            foreach (DocumentSnapshot document in querySnapShot.Documents)
            {
                document.Reference.DeleteAsync();
                paypalRemoved = true;
            }
        });
    }

    //delete manga from collection
    public void DeleteMangaFromCollection(ColeccionBibliotecaClass element, string username, string nombrecoleccion)
    {
        db.Collection("Colecciones Biblioteca").WhereEqualTo("nombreColeccion", nombrecoleccion).GetSnapshotAsync().ContinueWith(task =>
        {
            List<ColeccionBibliotecaClass> list = new List<ColeccionBibliotecaClass>();
            foreach (DocumentSnapshot documentSnapshot in task.Result.Documents)
            {
                ColeccionBiblioteca info = documentSnapshot.ConvertTo<ColeccionBiblioteca>();
                if (info.username == username)
                {
                    if(info.titulo == element.titulo)
                    {
                        documentSnapshot.Reference.DeleteAsync();
                    }
                }
            }

        });
    }

    //delete manga from collection
    public void DeleteCollectionMangas(string nombreColeccion, string username)
    {
        db.Collection("Colecciones Biblioteca").WhereEqualTo("nombreColeccion", nombreColeccion).GetSnapshotAsync().ContinueWith(task =>
        {
            List<ColeccionBibliotecaClass> list = new List<ColeccionBibliotecaClass>();
            foreach (DocumentSnapshot documentSnapshot in task.Result.Documents)
            {
                ColeccionBiblioteca info = documentSnapshot.ConvertTo<ColeccionBiblioteca>();
                if (info.username == username)
                {
                    documentSnapshot.Reference.DeleteAsync();
                }
            }

        });
    }
    
    //delete collection
    public void DeleteCollection(string name, string username)
    {
        db.Collection("Colecciones Biblioteca").WhereEqualTo("nombreColeccion", name).GetSnapshotAsync().ContinueWith(task =>
        {
            List<ColeccionBibliotecaClass> list = new List<ColeccionBibliotecaClass>();
            foreach (DocumentSnapshot documentSnapshot in task.Result.Documents)
            {
                ColeccionBiblioteca info = documentSnapshot.ConvertTo<ColeccionBiblioteca>();
                if(info.username == username)
                {
                    documentSnapshot.Reference.DeleteAsync();
                    collectionRemoved = true;
                }
            }

        });
    }

    //get suscription
    public void GetSuscripcion(string username)
    {
        suscritoList.Clear();

        db.Collection("Suscripcion").WhereEqualTo("username", username).GetSnapshotAsync().ContinueWith(task =>
        {
            QuerySnapshot query = task.Result;
            List<SuscritoClass> list = new List<SuscritoClass>();
            foreach (DocumentSnapshot documentSnapshot in query.Documents)
            {
                Suscrito info = documentSnapshot.ConvertTo<Suscrito>();
                SuscritoClass element = new SuscritoClass();
                element.username = info.username;
                element.suscrito = info.suscrito;
                element.plan = info.plan;

                list.Add(element);

            }

            foreach (SuscritoClass element in list)
            {
                suscritoList.Add(element);
            }

            suscritoSearch = true;

        });
    }

    //get comments from manga
    public void GetCommentsOfManga(int id)
    {
        comentariosManga.Clear();


        db.Collection("Comentario").WhereEqualTo("IdManga", id).GetSnapshotAsync().ContinueWith(task =>
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
                comentariosManga.Add(element);
            }

            comentariosMangaState = true;

        });
    }

    //get mangas from author
    public void GetMangasAutor(string nombre)
    {
        mangasAutor.Clear();

        db.Collection("Manga").WhereEqualTo("autor", nombre).GetSnapshotAsync().ContinueWith(task =>
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
                mangasAutor.Add(i);
            }
            mangaAutorFinish = true;
            //Debug.Log(new_manga.getAutor());

        });
    }

    //get mangas from a profile user
    public void GetMangasProfile(string nombre)
    {
        mangasProfile.Clear();

        db.Collection("Biblioteca").WhereEqualTo("username", nombre).GetSnapshotAsync().ContinueWith(task =>
        {

            List<BibliotecaClass> new_manga = new List<BibliotecaClass>();
            foreach (DocumentSnapshot documentSnapshot in task.Result.Documents)
            {
                Manga info = documentSnapshot.ConvertTo<Manga>();
                BibliotecaClass element = new BibliotecaClass();
                element.autor = info.autor;
                element.idioma = info.idioma;
                element.paginas = info.paginas;
                element.titulo = info.titulo;
                element.url = info.url;

                new_manga.Add(element);
            }

            foreach (BibliotecaClass i in new_manga)
            {
                mangasProfile.Add(i);
            }
            mangaProfileFinish = true;
            //Debug.Log(new_manga.getAutor());

        });
    }

    //user mangas
    public void UserMangas(string username)
    {
        if (bibliotecaPerfil.Count != 0)
        {
            bibliotecaPerfil.Clear();
        }

        db.Collection("Biblioteca").WhereEqualTo("username", username).GetSnapshotAsync().ContinueWith(task =>
        {
            List<BibliotecaClass> list = new List<BibliotecaClass>();
            foreach (DocumentSnapshot documentSnapshot in task.Result.Documents)
            {
                Biblioteca info = documentSnapshot.ConvertTo<Biblioteca>();
                BibliotecaClass element = new BibliotecaClass();
                element.autor = info.autor;
                element.idioma = info.idioma;
                element.paginas = info.paginas;
                element.titulo = info.titulo;
                element.url = info.url;
                element.percentage = info.percentage;
                element.username = info.username;

                list.Add(element);
            }

            foreach (BibliotecaClass i in list)
            {
                bibliotecaPerfil.Add(i);
            }

            bibliotecaPerfilState = true;
        });
    }

    //get biblioteca
    public void GetBiblioteca(string username)
    {
        if (bibliotecalist.Count != 0)
        {
            bibliotecalist.Clear();
        }

        db.Collection("Biblioteca").WhereEqualTo("username", username).GetSnapshotAsync().ContinueWith(task =>
        {
            List<BibliotecaClass> list = new List<BibliotecaClass>();
            foreach (DocumentSnapshot documentSnapshot in task.Result.Documents)
            {
                Biblioteca info = documentSnapshot.ConvertTo<Biblioteca>();
                BibliotecaClass element = new BibliotecaClass();
                element.autor = info.autor;
                element.idioma = info.idioma;
                element.paginas = info.paginas;
                element.titulo = info.titulo;
                element.url = info.url;
                element.percentage = info.percentage;
                element.username = info.username;

                list.Add(element);
            }

            foreach (BibliotecaClass i in list)
            {
                bibliotecalist.Add(i);
            }

            bibliotecaSearch = true;
        });
    }

    //get notifications from user
    public void GetNotificaciones()
    {
        if(listNotificaciones.Count != 0)
        {
            listNotificaciones.Clear();
        }
        db.Collection("Notificaciones").GetSnapshotAsync().ContinueWith(task =>
        {
            List<NotificacionClass> list = new List<NotificacionClass>();
            foreach (DocumentSnapshot documentSnapshot in task.Result.Documents)
            {
                Notificacion info = documentSnapshot.ConvertTo<Notificacion>();
                NotificacionClass element = new NotificacionClass();
                element.comentarios = info.comentarios;
                element.dislikes = info.dislikes;
                element.likes = info.likes;
                element.text_notis = info.text_notis;
                element.tipo = info.tipo;
                element.url = info.url;
                element.username = info.username;

                list.Add(element);
            }

            foreach (NotificacionClass i in list)
            {
                listNotificaciones.Add(i);
            }

            notificacionesFinish = true;
        });
    }

    //get collectiones
    public void GetCollections(string username)
    {

        if (listColeccionesBiblioteca.Count != 0)
        {
            listColeccionesBiblioteca.Clear();
        }

        db.Collection("Colecciones Biblioteca").GetSnapshotAsync().ContinueWith(task =>
        {
            List<ColeccionBibliotecaClass> list = new List<ColeccionBibliotecaClass>();
            foreach (DocumentSnapshot documentSnapshot in task.Result.Documents)
            {
                ColeccionBiblioteca info = documentSnapshot.ConvertTo<ColeccionBiblioteca>();
                ColeccionBibliotecaClass element = new ColeccionBibliotecaClass();
                element.nombreColeccion = info.nombreColeccion;
                element.autor = info.autor;
                element.idioma = info.idioma;
                element.paginas = info.paginas;
                element.titulo = info.titulo;
                element.url = info.url;
                element.percentage = info.percentage;
                element.username = info.username;

                list.Add(element);
            }

            foreach (ColeccionBibliotecaClass i in list)
            {
                listColeccionesBiblioteca.Add(i);
            }

            coleccionesBibliotecaSearch = true;
        });
    }

    //delete manga from collection
    public void DeleteMangaCollection(ColeccionBibliotecaClass manga)
    {
        db.Collection("Colecciones Biblioteca").WhereEqualTo("titulo", manga.titulo).GetSnapshotAsync().ContinueWith(task =>
        {
            List<ColeccionBibliotecaClass> list = new List<ColeccionBibliotecaClass>();
            foreach (DocumentSnapshot documentSnapshot in task.Result.Documents)
            {
                documentSnapshot.Reference.DeleteAsync();
            }
        });
    }

    //update suscription
    public void UpdateSub(string username, string plan, string suscrito)
    {
        db.Collection("Suscripcion").WhereEqualTo("username", username).GetSnapshotAsync().ContinueWith(task =>
        {
            foreach (DocumentSnapshot document in task.Result.Documents)
            {
                document.Reference.UpdateAsync("suscrito", suscrito).ContinueWith(task =>
                {
                    Debug.Log("Update sub");
                });
                document.Reference.UpdateAsync("plan", plan).ContinueWith(task =>
                {
                    Debug.Log("Update sub");
                });
            }
            
        });
    }

    //add suscription
    public void AddSub(Dictionary<string, object> sub)
    {
        db.Collection("Suscripcion").AddAsync(sub).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("add to sub");
            }
            else
            {
                Debug.Log("not added to sub");
            }
            

        });
    }

    //add manga to shoplist
    public void AddToShopList(Dictionary<string, object> manga)
    {
        db.Collection("ShopList").AddAsync(manga).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("add to shoplist");
            }
            else
            {
                Debug.Log("not added to shoplist");
            }
        });
    }
    
    //add manga to collection
    public void AñadirMangaCollection(Dictionary<string, object> manga)
    {
        db.Collection("Colecciones Biblioteca").AddAsync(manga).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("manga is added");
            }
            else
            {
                Debug.Log("manga is not added");
            }
        });
    }

    //save paypal account
    public void SavePaypal(Dictionary<string, object> paypal)
    {
        db.Collection("Paypal").AddAsync(paypal).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("paypal is added");
            }
            else
            {
                Debug.Log("paypal is not added");
            }
        });
    }

    //save credit card
    public void SaveTarjeta(Dictionary<string, object> tarjeta)
    {
        db.Collection("Tarjetas").AddAsync(tarjeta).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("tarjeta is added");
            }
            else
            {
                Debug.Log("tarjeta is not added");
            }
        });
    }

    //get all mangas from user
    public void GetAllMangasUser(string username, string nombreColeccion)
    {
        if(listMangasBiblioteca.Count != 0)
        {
            listMangasBiblioteca.Clear();
        }

        db.Collection("Biblioteca").WhereEqualTo("username", username).GetSnapshotAsync().ContinueWith(task =>
        {
            List<ColeccionBibliotecaClass> list = new List<ColeccionBibliotecaClass>();
            foreach (DocumentSnapshot documentSnapshot in task.Result.Documents)
            {
                Biblioteca info = documentSnapshot.ConvertTo<Biblioteca>();
                ColeccionBibliotecaClass element = new ColeccionBibliotecaClass();
                element.autor = info.autor;
                element.idioma = info.idioma;
                element.paginas = info.paginas;
                element.titulo = info.titulo;
                element.url = info.url;
                element.percentage = info.percentage;
                element.username = info.username;
                element.nombreColeccion = nombreColeccion;

                list.Add(element);
            }

            foreach (ColeccionBibliotecaClass i in list)
            {
                listMangasBiblioteca.Add(i);
            }

            getMangasUserDone = true;
        });
    }

    //ask for a collection with name
    public void AskCollection(string name)
    {
        listCollectionName.Clear();

        db.Collection("Colecciones Biblioteca").WhereEqualTo("nombreColeccion", name).GetSnapshotAsync().ContinueWith(task =>
        {
            List<ColeccionBibliotecaClass> list = new List<ColeccionBibliotecaClass>();
            foreach (DocumentSnapshot documentSnapshot in task.Result.Documents)
            {
                ColeccionBiblioteca info = documentSnapshot.ConvertTo<ColeccionBiblioteca>();
                ColeccionBibliotecaClass element = new ColeccionBibliotecaClass();
                element.nombreColeccion = info.nombreColeccion;
                element.autor = info.autor;
                element.idioma = info.idioma;
                element.paginas = info.paginas;
                element.titulo = info.titulo;
                element.url = info.url;
                element.percentage = info.percentage;
                element.username = info.username;

                list.Add(element);
            }

            foreach (ColeccionBibliotecaClass i in list)
            {
                listCollectionName.Add(i);
            }

            coleccionNameDone = true;
        });
    }

    //show wishlist
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

    //delete mangawishlist
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

    //add to wishlist
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

    //delete manga from wishlist
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

    //wishlist
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

    //ask user is logged
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

    //coments from user
    public void ComentariosUser(string username)
    {
        listComentarios.Clear();

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

    }

    //comentarios from profile
    public void ComentariosProfile(string username)
    {

        comentariosProfileList.Clear();

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
                comentariosProfileList.Add(element);
            }

            comentariosProfileListFinish = true;


        });

    }

    //logout user
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

    //get genre favourite from user
    public void GetGenreFavUser()
    {
        genreFav = "";
        db.Collection("User").WhereEqualTo("loggeado", "yes").GetSnapshotAsync().ContinueWith((task) =>
        {

            foreach (DocumentSnapshot documentSnapshot in task.Result.Documents)
            {
                Users info = documentSnapshot.ConvertTo<Users>();
                genreFav = info.generoFavorito;
            }

            genreFavSearchDone = true;


        });
    }

    //get novedades
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

    //get mangas novedades
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

    //get mangas for novedades
    public void MangasForNovedades()
    {
        foreach(int id in mangasIds)
        {
            GetMangaNovedades(id);
        }
    }

    //ask for top list
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

    //get mangas from top list
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

    //ask for mangas info
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

    //recomendations for the user
    public void RecomendationsForUser(string genero)
    {

        recomendaciones.Clear();

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
    
    //get favourite genre
    public void GenreFav()
    {
        db.Collection("Users").WhereEqualTo("email", "elnacp@gmail.com").GetSnapshotAsync().ContinueWith(task =>
        {

            

        });
    }

    //Ask mangas from categories
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

    //search information (mangas/collections/authors/profiles)
    public void SearchInfo(string search)
    {
        AskForMangas(search);
        AskForCollections(search);
        AskForAuthors(search);
        AskForUsersSearch(search);
    }

    //ask for mangas
    private void AskForMangas(string title)
    {

        if(mangasSearch.Count != 0)
        {
            mangasSearch.Clear();
        }

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

    //ask for collections
    private void AskForCollections(string nombre)
    {
        collectionSearch.Clear();

        db.Collection("Colecciones").WhereEqualTo("nombre", nombre).GetSnapshotAsync().ContinueWith(task =>
        {
            List<ColeccionesClass> list = new List<ColeccionesClass>();
            foreach (DocumentSnapshot documentSnapshot in task.Result.Documents)
            {
                Colecciones info = documentSnapshot.ConvertTo<Colecciones>();
                ColeccionesClass element = new ColeccionesClass();
                element.autor = info.autor;
                element.id = info.id;
                element.nombre = info.nombre;
                element.url = info.url;

                list.Add(element);
            }

            foreach(ColeccionesClass colection in list)
            {
                collectionSearch.Add(colection);
            }
            colectionisSearch = true;
        });
    }

    //get collections from author
    public void GetCollectionAutor(string nombre)
    {
        collectionAutor.Clear();

        db.Collection("Colecciones").WhereEqualTo("autor", nombre).GetSnapshotAsync().ContinueWith(task =>
        {
            List<ColeccionesClass> list = new List<ColeccionesClass>();
            foreach (DocumentSnapshot documentSnapshot in task.Result.Documents)
            {
                Colecciones info = documentSnapshot.ConvertTo<Colecciones>();
                ColeccionesClass element = new ColeccionesClass();
                element.autor = info.autor;
                element.id = info.id;
                element.nombre = info.nombre;
                element.url = info.url;

                list.Add(element);
            }

            foreach (ColeccionesClass colection in list)
            {
                collectionAutor.Add(colection);
            }
            collectionAutorFinish = true;
        });
    }

    //ask for author in search
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

    //Ask for user in search
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

    //mangas same author
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

    //mangas from same collection
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

    //mangas same category
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
