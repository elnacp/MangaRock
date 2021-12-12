using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecoverPasswordController : MonoBehaviour
{

    [SerializeField] InputField email;
    [SerializeField] Text message;
    [SerializeField] LoginController loginController;

    public void Start()
    {
        ResetRecoverPassword();
    }

    //Button recover have been clicked (Validate the data)
    public void RecoverPassoword()
    {
        if(email.text == "")
        {
            message.text = "Error: Tienes que rellenar el correo electrónico.";
        }
        else
        {
            //Return to login 
            loginController.ReturnFromRecoverPassword();
            ResetRecoverPassword();
        }
    }

    //Reset the inputfields
    public void ResetRecoverPassword()
    {
        message.text = "";
        email.text = "";
    }

}
