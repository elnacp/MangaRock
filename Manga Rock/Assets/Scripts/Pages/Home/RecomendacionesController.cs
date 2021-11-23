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

    public void Update()
    {
        if(!ask)
        {
            db.RecomendationsForUser(genreFav);
            ask = true;
        }
    }

    public void AddInformation(List<MangaClass> list)
    {
        foreach(MangaClass manga in list)
        {
            GameObject prefab = Instantiate(mangaprefab, content);
            prefab.GetComponent<MangaRecomendaciones>().AddInfo(manga);
            recomendaciones.Add(manga);
        }
    }

    public void GoRecomendaciones()
    {
        pageController.GoRecomendaciones(recomendaciones);
    }


}
