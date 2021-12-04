using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopListController : MonoBehaviour
{
    [SerializeField] Transform contentList;
    [SerializeField] GameObject prefabManga;
    [SerializeField] Text precioFinal;

    [SerializeField] GameObject tarjetaPanel;
    [SerializeField] GameObject paypalPanel;

    [SerializeField] InputField number;
    [SerializeField] InputField fechaCaducidad;
    [SerializeField] InputField cvv;
    [SerializeField] InputField email;

    [SerializeField] GameObject FrontTarjeta;
    [SerializeField] GameObject buttonDetras;
    [SerializeField] GameObject BackTarjeta;
    [SerializeField] GameObject buttonDelante;



    private float precioTotalList = 0;
    private TarjetaClass tarjeta;
    private PaypalClass paypal;


    public void AddMangaList(List<ShopListClass> list)
    {

        float precio = 0;

        foreach(ShopListClass item in list)
        {
            GameObject prefab = Instantiate(prefabManga, contentList);
            prefab.GetComponent<MangaListCompra>().AddInformation(item);

            precio += item.precio * item.cantidad;
        }

        precioTotalList = precio;

        precioFinal.text = precio + "€";

    }

    public void ShowTarjeta()
    {
        tarjetaPanel.SetActive(true);
        paypalPanel.SetActive(false);
        ShowFront();
    }

    public void ShowPaypal()
    {
        tarjetaPanel.SetActive(false);
        paypalPanel.SetActive(true);
        AddPaypalDatos();

    }

    public void Init()
    {
        FirebasePageController firebase = FindObjectOfType<FirebasePageController>();
        UserClass userData = FindObjectOfType<HomeInit>().GetUser();
        firebase.GetShopList(userData.username);
        firebase.GetTarjeta(userData.username);

        tarjetaPanel.SetActive(true);
        paypalPanel.SetActive(false);
    }

    public void ChangePrecioFinal(float precio, bool increase)
    { 
        if(increase)
        {
            precioTotalList += precio;
            precioFinal.text = precioTotalList.ToString();
        }
        else
        {
            precioTotalList -= precio;
            precioFinal.text = precioTotalList.ToString();
        }
    }

    

    public void AddTarjeta(List<TarjetaClass> listTarjetas)
    {
        if(listTarjetas.Count != 0)
        {
            TarjetaClass[] new_list = listTarjetas.ToArray();
            tarjeta = new_list[0];

            ShowFront();
        }
    }

    private void AddTarjetaDatosFront()
    {

        if(tarjeta != null)
        {
            number.placeholder.GetComponent<Text>().text = tarjeta.number;
            fechaCaducidad.placeholder.GetComponent<Text>().text = tarjeta.fechaCaducidad;
            number.interactable = false;
            fechaCaducidad.interactable = false;
        }

    }

    private void AddTarjetaDatosBack()
    {

        if (tarjeta != null)
        {
            cvv.placeholder.GetComponent<Text>().text = tarjeta.cvv;
            cvv.interactable = false;
        }

    }



    public void ShowBack()
    {
        FrontTarjeta.SetActive(false);
        buttonDetras.SetActive(false);

        BackTarjeta.SetActive(true);
        buttonDelante.SetActive(true);
        AddTarjetaDatosBack();
    }
    public void ShowFront()
    {
        FrontTarjeta.SetActive(true);
        buttonDetras.SetActive(true);

        BackTarjeta.SetActive(false);
        buttonDelante.SetActive(false);
        AddTarjetaDatosFront();
    }

    public void AddPaypal(List<PaypalClass> listPaypal)
    {
        if (listPaypal.Count != 0)
        {
            PaypalClass[] new_list = listPaypal.ToArray();
            paypal= new_list[0];

            AddPaypalDatos();
        }
    }

    private void AddPaypalDatos()
    {
        if (paypalPanel.activeSelf)
        {
            if (paypal != null)
            {
                email.placeholder.GetComponent<Text>().text = paypal.email;
                email.interactable = false;
            }
        }
    }

        

    

}
