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

    [SerializeField] Text numero;
    [SerializeField] Text fechaCaducidad;
    [SerializeField] Text cvv;


    TarjetaClass data = new TarjetaClass();

    private void Start()
    {
    }

    public void AddInformation(TarjetaClass tarjeta)
    {
        data = tarjeta;
        Delante();
    }

    public void Delante()
    {
        delanteTarjeta.SetActive(true);
        buttonDetras.SetActive(true);

        detrasTarjeta.SetActive(false);
        buttonDelante.SetActive(false);

        numero.text = data.number;
        fechaCaducidad.text = data.fechaCaducidad;
    }

    public void Detras()
    {
        delanteTarjeta.SetActive(false);
        buttonDetras.SetActive(false);

        detrasTarjeta.SetActive(true);
        buttonDelante.SetActive(true);

        cvv.text = data.cvv;
    }

}
