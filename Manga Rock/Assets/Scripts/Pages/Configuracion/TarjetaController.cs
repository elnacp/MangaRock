using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TarjetaController : MonoBehaviour
{
    [SerializeField] Text number;
    [SerializeField] Text fechaCaducidad;

    TarjetaClass data = new TarjetaClass();

    //Add information to the card
    public void AddInformation(TarjetaClass tarjeta)
    {
        number.text = "Visa/Tarjeta "+ tarjeta.number;
        fechaCaducidad.text = tarjeta.fechaCaducidad;

        data = tarjeta;
    }

    //Go to show the card
    public void MostrarTarjeta()
    {
        FindObjectOfType<ConfiguracionController>().GoShowTarjeta(data);
    }
    
}
