using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetododePago : MonoBehaviour
{
    [SerializeField] Transform contentTarjetas;
    [SerializeField] Transform contentPaypal;
    [SerializeField] GameObject prefabTarjeta;
    [SerializeField] GameObject prefabPaypal;

    public void AddTarjetas(List<TarjetaClass> tarjetaslist)
    {

        ClearContent(contentTarjetas);
        foreach(TarjetaClass tarjeta in tarjetaslist)
        {
            GameObject prefab = Instantiate(prefabTarjeta, contentTarjetas);
            prefab.GetComponent<TarjetaController>().AddInformation(tarjeta);
            
        }
    }

    public void AddPaypal(List<PaypalClass> paypallist)
    {
        Debug.Log("Paypal" +paypallist.Count);
        ClearContent(contentPaypal);
        foreach (PaypalClass paypal in paypallist)
        {
            GameObject prefab = Instantiate(prefabPaypal, contentPaypal);
            prefab.GetComponent<PaypalController>().AddInformation(paypal);
        }
    }

    private void ClearContent(Transform content)
    {
        foreach(Transform child in content)
        {
            Destroy(child.gameObject);
        }

       
    }
}
