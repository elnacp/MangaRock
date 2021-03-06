using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class NovedadesController : MonoBehaviour
{

    private Manga manga;
    [SerializeField] FirebasePageController db;
    

    private List<MangaClass> listMangas;

    [SerializeField] Text title;
    [SerializeField] Text autor;
    [SerializeField] Text valoration;
    [SerializeField] RawImage image;
    [SerializeField] NovedadesDotsAnimation dotsController;

    [SerializeField] PageController pageController;


    private float timePassed = 0.0f;

    private int index = 0;

    //[SerializeField] SliderController slider;

    // Start is called before the first frame update
    void Start()
    {
        //GetNovedades();
        listMangas = new List<MangaClass>();
    }

    // Update is called once per frame
    void Update()
    {

        timePassed += Time.deltaTime;
        if(timePassed > 3.0f)
        {
            if(listMangas.Count != 0)
            {
                MostrarManga();
            }
            timePassed = 0f;
        }

    }

    //Get the novedades information
    public void GetNovedades()
    {
        db.GetNovedades();
    }

    //Go to manga detail page
    public void GoDetail()
    {
        int i = index;

        int e = 1;
        foreach(MangaClass manga in listMangas)
        {
            if( e == i)
            {
                pageController.GoDetallesManga(manga);
            }
            e++;
        }

    }

    //Update the information in the panel
    public void UpdateNovedades(List<MangaClass> list)
    {
        if(list.Count != 0)
        {
            foreach (MangaClass element in list)
            {
                listMangas.Add(element);
            }

            dotsController.AddDots(listMangas.Count);
        }
    }

    //Show the manga
    private void MostrarManga()
    {
        MangaClass[] mangas = listMangas.ToArray();
        title.text = mangas[index].titulo;
        autor.text = mangas[index].autor;
        valoration.text = mangas[index].valoracion.ToString();
        StartCoroutine(GetImage(mangas[index].url));

       
       dotsController.MoveDot(index);
        

        index++;
        if(index > mangas.Length-1)
        {
            index = 0;
        }



    }

    //Get the image from url
    IEnumerator GetImage(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        image.texture = www.texture;
    }
    

    
     
    
}
