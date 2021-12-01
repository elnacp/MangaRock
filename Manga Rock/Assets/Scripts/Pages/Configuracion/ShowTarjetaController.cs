using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTarjetaController : MonoBehaviour
{
    [SerializeField] GameObject delanteTarjeta;
    [SerializeField] GameObject detrasTarjeta;
    [SerializeField] GameObject buttonDelante;
    [SerializeField] GameObject buttonDetras;

    [SerializeField] InputField numero;
    [SerializeField] InputField fechaCaducidad;
    [SerializeField] InputField cvv;

    [SerializeField] Text message;

    TarjetaClass data = new TarjetaClass();

    private void Start()
    {
    }

    public void AddInformation(TarjetaClass tarjeta)
    {
        data = tarjeta;
        message.text = "";
        Delante();
    }

    public void Delante()
    {
        delanteTarjeta.SetActive(true);
        buttonDetras.SetActive(true);

        detrasTarjeta.SetActive(false);
        buttonDelante.SetActive(false);

        numero.placeholder.GetComponent<Text>().text = data.number;
        fechaCaducidad.placeholder.GetComponent<Text>().text = data.fechaCaducidad;
    }

    public void Detras()
    {
        delanteTarjeta.SetActive(false);
        buttonDetras.SetActive(false);

        detrasTarjeta.SetActive(true);
        buttonDelante.SetActive(true);

        cvv.placeholder.GetComponent<Text>().text = data.cvv;
    }

    public void DeleteTarjeta()
    {
        FindObjectOfType<FirebasePageController>().DeleteTarjeta(data);
    }


    public void MessageAddTarjeta()
    {
        message.text = "La tarjeta se ha guardado correctamente.";
        message.color = Color.black;
    }

    public void UpdateTarjeta()
    {
        string new_number = "";
        string new_cvv = "";
        string new_fechaCaducidad = "";
        if(numero.text == "")
        {
            new_number = numero.placeholder.GetComponent<Text>().text;
        }
        else
        {
            new_number = numero.text;
        }

        if(cvv.text == "")
        {
            new_cvv = cvv.placeholder.GetComponent<Text>().text;
        }
        else
        {
            new_cvv = cvv.text;
        }

        if (fechaCaducidad.text == "")
        {
            new_fechaCaducidad = fechaCaducidad.placeholder.GetComponent<Text>().text;
        }
        else
        {
            new_fechaCaducidad = fechaCaducidad.text;
        }


        TarjetaClass new_Tarjeta = new TarjetaClass();
        new_Tarjeta.number = new_number;
        new_Tarjeta.cvv = new_cvv;
        new_Tarjeta.fechaCaducidad = new_fechaCaducidad;
        new_Tarjeta.username = data.username;


        FindObjectOfType<FirebasePageController>().UpdateTarjeta(new_Tarjeta);


    }


}
