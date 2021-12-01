using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddPaypalController : MonoBehaviour
{
    [SerializeField] InputField email;

    [SerializeField] Text message;

    [SerializeField] FirebasePageController firebase;


    private void Start()
    {
        message.text = "";
    }

    public void AddPaypal()
    {
        if(email.text == "")
        {
            message.text = "Error: Parece que no has insertado los datos correctamente.";
            message.color = Color.red;
        }
        else
        {
            string username = FindObjectOfType<HomeInit>().GetUser().username;

            Dictionary<string, object> new_paypal = new Dictionary<string, object>
            {
                {"username", username },
                {"email", email.text },
            };


            firebase.AddPaypal(new_paypal);

        }
    }

    public void AddMessageError()
    {
        message.text = "Error: parece que no se ha podido guardar la tarjeta.";
        message.color = Color.red;
    }

    public void AddMessageDone()
    {
        message.text = "Se ha guardado la tarjeta con exito";
        message.color = Color.black;
    }
}
