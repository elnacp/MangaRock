using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MetododePago : MonoBehaviour
{
    [SerializeField] Transform contentTarjetas;
    [SerializeField] Transform contentPaypal;
    [SerializeField] GameObject prefabTarjeta;
    [SerializeField] GameObject prefabPaypal;

    [SerializeField] Button a�adirTarjeta;
    [SerializeField] Button a�adirCuenta;

    //Add all the card in the list
    public void AddTarjetas(List<TarjetaClass> tarjetaslist)
    {
        ClearContent(contentTarjetas);
        Debug.Log(tarjetaslist.Count);
        if(tarjetaslist.Count != 0)
        {
            foreach (TarjetaClass tarjeta in tarjetaslist)
            {
                GameObject prefab = Instantiate(prefabTarjeta, contentTarjetas);
                prefab.GetComponent<TarjetaController>().AddInformation(tarjeta);

            }
            a�adirTarjeta.interactable = false;
        }
        else
        {
            a�adirTarjeta.interactable = true;
        }
    }

    //Add all the paypal accounts in the list
    public void AddPaypal(List<PaypalClass> paypallist)
    {
        ClearContent(contentPaypal);
        if( paypallist.Count != 0)
        {
            foreach (PaypalClass paypal in paypallist)
            {
                GameObject prefab = Instantiate(prefabPaypal, contentPaypal);
                prefab.GetComponent<PaypalController>().AddInformation(paypal);
            }
            a�adirCuenta.interactable = false;
        }
        else
        {
            a�adirCuenta.interactable = true;
        }
        
    }

    //Clear both contents
    private void ClearContent(Transform content)
    {
        foreach(Transform child in content)
        {
            Destroy(child.gameObject);
        }

       
    }
}
