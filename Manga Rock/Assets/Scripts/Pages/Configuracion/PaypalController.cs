using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaypalController : MonoBehaviour
{
    [SerializeField] Text email;

    PaypalClass data;

    public void AddInformation(PaypalClass paypal)
    {
        email.text = "Email: "+paypal.email;
        data = paypal;
    }

    public void MostrarPaypal()
    {
        FindObjectOfType<ConfiguracionController>().GoShowPaypal(data);
    }
}
