using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopVentasController : MonoBehaviour
{

    [SerializeField] GameObject prefabManga;
    [SerializeField] GameObject separador;

    [SerializeField] Transform contentPago;
    [SerializeField] Transform contentFree;

    [SerializeField] FirebasePageController db;

    private List<TopElement> listgratis;
    private List<TopElement> listpago;
    private List<MangaClass> listMangasPago;  
    private List<MangaClass> listMangasGratis; 

    [SerializeField] PageController pageController;

    private bool ask = false;

    private void Start()
    {
        

        listgratis = new List<TopElement>();
        listpago = new List<TopElement>();

        listMangasGratis = new List<MangaClass>();
        listMangasPago = new List<MangaClass>();

    }

    public void GoTopList()
    {
        pageController.GoTopList(listpago.ToArray(), listMangasPago, listgratis.ToArray(), listMangasGratis);
    }

    private void Update()
    {
        if(!ask)
        {
            db.AskTopList();     
            ask = true;
        }
    }

    public void TopListData(List<TopElement> pago, List<TopElement> gratis)
    {
        //Order list
        OrderList(pago);
        OrderList(gratis);

        db.AskMangasInfoTop(pago);
        db.AskMangasInfoTop(gratis);
        
    }

    private void OrderList(List<TopElement> list)
    {
        for(int i = 1; i < 11; i++)
        {
            foreach(TopElement element in list)
            {
                if(element.top == i)
                {
                    if(element.categoria == "pago")
                    {
                        listpago.Add(element);
                    }
                    else
                    {
                        listgratis.Add(element);
                    }
                }
            }
        } 
    }


    public void AddInformationContent(List<MangaClass> pagoMangas, List<MangaClass> freeMangas)
    {
        foreach(MangaClass e in pagoMangas)
        {
            listMangasPago.Add(e);
        }
        foreach(MangaClass e in freeMangas)
        {
            listMangasGratis.Add(e);
        }

        AddInfoPanel(listMangasPago, listpago.ToArray(), contentPago);
        AddInfoPanel(listMangasGratis, listgratis.ToArray(), contentFree);
    }

    private void AddInfoPanel(List<MangaClass> list, TopElement[] orderList, Transform content)
    {       
        for (int i = 0; i < 3; i++)
        {
            foreach(MangaClass element in list)
            {
                if(orderList[i].idManga == element.id)
                {
                    GameObject prefab = Instantiate(prefabManga, content);
                    AddInformation(prefab, element, i+1);
                    if (i != 2)
                    {
                        Instantiate(separador, content);
                    }
                }
            }
        }
    }


    private void AddInformation(GameObject prefab, MangaClass element, int index)
    {
        prefab.GetComponent<MangasTopListController>().UpdateMangaInfo
        (
            element,
            index.ToString()
        );
    }





}


