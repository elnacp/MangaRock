using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecomendacionesController : MonoBehaviour
{
    [SerializeField] GameObject mangaprefab;
    [SerializeField] Transform content;
    [SerializeField] PageController pageController;

    private string genreFav = "Aventura";

    [SerializeField] FirebasePageController db;

    private bool ask = false;
    private List<MangaClass> recomendaciones = new List<MangaClass>();


    private void Start()
    {
        
    }
    //Get recomendations 
    public void GetRecomendaciones()
    {
        db.GetGenreFavUser();
    }

    //Get recomendations with one genre
    public void GetRecomendacion(string genero)
    {
        db.RecomendationsForUser(genero);
    }

    //Add the infromatio
    public void AddInformation(List<MangaClass> list)
    {

        foreach(Transform child in content)
        {
            Destroy(child.gameObject);
        }

        foreach(MangaClass manga in list)
        {
            GameObject prefab = Instantiate(mangaprefab, content);
            prefab.GetComponent<MangaRecomendaciones>().AddInfo(manga);
            recomendaciones.Add(manga);
        }
    }

    //Go to the panel of recomendations
    public void GoRecomendaciones()
    {
        pageController.GoRecomendaciones(recomendaciones);
    }


}
