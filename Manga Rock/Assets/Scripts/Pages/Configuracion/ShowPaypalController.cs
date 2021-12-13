using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPaypalController : MonoBehaviour
{
    [SerializeField] InputField email;
    [SerializeField] Text message;

    PaypalClass data = new PaypalClass();

    //Add all the information of the paypal account
    public void AddInformation(PaypalClass paypal)
    {
        data = paypal;
        message.text = "";
        email.placeholder.GetComponent<Text>().text = paypal.email;
    }

    //update the email of the paypal in firebase
    public void UpdateEmail()
    {
        if(email.text == "")
        {
            MessageErrorEdit();
        }
        else
        {
            PaypalClass new_Paypal = new PaypalClass();
            new_Paypal.username = data.username;
            new_Paypal.email = email.text;
            FindObjectOfType<FirebasePageController>().UpdatePaypal(new_Paypal);
        }
    }

    //Show error message
    public void MessageErrorEdit()
    {
        message.text = "Error: no se ha guardado el email, porque no ha sido modificado.";
        message.color = Color.red;
    }

    //Show message correct added
    public void MessageUpdatePaypal()
    {
        message.text = "Se ha guardado tus cambios de la cuenta paypal";
        message.color = Color.black;
    }
    
    //Ask firebase to remove the paypal account
    public void DeletePaypal()
    {
        FindObjectOfType<FirebasePageController>().DeletePaypal(data);
    }

}
