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

    [SerializeField] GameObject saveTarjetaPanel;
    [SerializeField] GameObject savePaypalPanel;

    [SerializeField] Image savepaypal;
    [SerializeField] Image savetarjeta;
    [SerializeField] Sprite checkOn;
    [SerializeField] Sprite checkOff;

    private List<ShopListClass> shopList = new List<ShopListClass>();

    private float precioTotalList = 0;
    private TarjetaClass tarjeta;
    private PaypalClass paypal;

    private bool saveTarjetaState = false;
    private bool savePaypalState = false;

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

        shopList = list;

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
        //firebase.GetTarjeta(userData.username);
        //firebase.GetPaypal(userData.username);


        tarjetaPanel.SetActive(true);
        paypalPanel.SetActive(false);
    }

    public void ChangePrecioFinal(float precio, bool increase)
    { 
        if(increase)
        {
            precioTotalList += precio;
            precioFinal.text = precioTotalList + "€";
        }
        else
        {
            precioTotalList -= precio;
            precioFinal.text = precioTotalList + "€";
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

            saveTarjetaPanel.SetActive(false);
        }
        else
        {
            saveTarjetaPanel.SetActive(true);
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
       
        if (paypal != null)
        {
            email.placeholder.GetComponent<Text>().text = paypal.email;
            email.interactable = false;

            savePaypalPanel.SetActive(false);
        }
        else
        {
            savePaypalPanel.SetActive(true);
        }

    }

    public void SaveTarjeta()
    {
        saveTarjetaState = !saveTarjetaState;
        if(saveTarjetaState)
        {
            savetarjeta.sprite = checkOn;
        }
        else
        {
            savetarjeta.sprite = checkOff;
        }
    }

    public void SavePaypal()
    {
        savePaypalState = !savePaypalState;
        if (savePaypalState)
        {
            savepaypal.sprite = checkOn;
        }
        else
        {
            savepaypal.sprite = checkOff;
        }
    }

    public void Comprar()
    {
        if(shopList.Count != 0)
        {
            int cantidad = 0;
            foreach(ShopListClass item in shopList)
            {
                cantidad += item.cantidad;
            }

            if(cantidad != 0)
            {

                AddMetodoPago();

                foreach(ShopListClass item in shopList)
                {
                    if(item.cantidad != 0)
                    {
                        for (int i = 0; i < item.cantidad; i++)
                        {
                            Debug.Log("add manga" + i);
                        }
                    }
                }
                foreach (ShopListClass item in shopList)
                {
                    if (item.cantidad != 0)
                    {
                        for (int i = 0; i < item.cantidad; i++)
                        {
                            //Debug.Log("eliminar manga" + i);
                            string username = FindObjectOfType<HomeInit>().GetUser().username;
                            FindObjectOfType<FirebasePageController>().ClearShopList(username);
                        }
                    }
                }
            }
        }
    }
    
    private void AddMetodoPago()
    {
        string username = FindObjectOfType<HomeInit>().GetUser().username;

        if (paypalPanel.activeSelf)
        {
            if(savePaypalState)
            {
                if(email.text != "")
                {
                    Dictionary<string, object> new_paypal = new Dictionary<string, object>
                    {
                        {"email", email.text},
                        {"username", username }
                    };

                    FindObjectOfType<FirebasePageController>().AddPaypal(new_paypal);
                }
                
            }
        }

        if (tarjetaPanel.activeSelf)
        {
            if (saveTarjetaState)
            {
                if(number.text != "" && fechaCaducidad.text != "" && cvv.text != "")
                {
                    Dictionary<string, object> new_tarjeta = new Dictionary<string, object>
                    {
                        {"cvv", cvv.text},
                        {"fechaCaducidad", fechaCaducidad.text},
                        {"number", number.text},
                        {"username", username }
                    };

                    FindObjectOfType<FirebasePageController>().AddTarjeta(new_tarjeta);
                }
                
            }
        }
    }





}
