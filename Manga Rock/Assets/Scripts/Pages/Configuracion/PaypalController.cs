using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaypalController : MonoBehaviour
{
    [SerializeField] Text email;

    PaypalClass paypal;

    public void AddInformation(PaypalClass paypal)
    {
        email.text = "Email: "+paypal.email;
        this.paypal = paypal;
    }
}
