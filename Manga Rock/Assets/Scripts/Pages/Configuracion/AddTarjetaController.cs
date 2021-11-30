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


    private void Start()
    {
        Delante();
    }


    public void Delante()
    {
        delanteTarjeta.SetActive(true);
        buttonDelante.SetActive(false);
        detrasTarjeta.SetActive(false);
        buttonDetras.SetActive(true);
    }

    public void Detras()
    {
        delanteTarjeta.SetActive(false);
        buttonDelante.SetActive(true);
        detrasTarjeta.SetActive(true);
        buttonDetras.SetActive(true);
    }

    
}
