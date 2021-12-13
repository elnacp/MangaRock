using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddTarjetaController : MonoBehaviour
{
    [SerializeField] GameObject delanteTarjeta;
    [SerializeField] GameObject detrasTarjeta;
    [SerializeField] GameObject buttonDelante;
    [SerializeField] GameObject buttonDetras;

    [SerializeField] InputField numero;
    [SerializeField] InputField fechaCaducidad;
    [SerializeField] InputField cvv;

    [SerializeField] Text message;

    [SerializeField] Button addButton;

    [SerializeField] FirebasePageController firebase;

    private void Start()
    {
        Delante();
        message.text = "";
    }

    //Show from part of the card
    public void Delante()
    {
        delanteTarjeta.SetActive(true);
        buttonDelante.SetActive(false);
        detrasTarjeta.SetActive(false);
        buttonDetras.SetActive(true);
    }

    //Show back part of the card
    public void Detras()
    {
        delanteTarjeta.SetActive(false);
        buttonDelante.SetActive(true);
        detrasTarjeta.SetActive(true);
        buttonDetras.SetActive(false);
    }

    //Add card if all the information is correct
    public void AddNewTarjeta()
    {
        if( numero.text != "" && fechaCaducidad.text != "" && cvv.text != "")
        {
            string username = FindObjectOfType<HomeInit>().GetUser().username;

            Dictionary<string, object> new_tarjeta = new Dictionary<string, object>
            {
                {"username", username },
                {"number", numero.text },
                {"fechaCaducidad", fechaCaducidad.text },
                {"cvv", cvv.text },
            };

            firebase.AddTarjeta(new_tarjeta);

            addButton.interactable = false;
        }
        else
        {
            message.text = "Error: Parece que no has insertado los datos correctamente.";
            message.color = Color.red;
        }
        

    }

    //Show error message
    public void AddMessageError()
    {
        message.text = "Error: parece que no se ha podido guardar la tarjeta.";
        message.color = Color.red;
    }

    //Show correct message
    public void AddMessageDone()
    {
        message.text = "Se ha guardado la tarjeta con exito";
        message.color = Color.black;
    }


}
