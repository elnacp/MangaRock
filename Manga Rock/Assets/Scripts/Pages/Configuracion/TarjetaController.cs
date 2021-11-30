using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TarjetaController : MonoBehaviour
{
    [SerializeField] Text number;
    [SerializeField] Text fechaCaducidad;

    TarjetaClass data = new TarjetaClass();
    public void AddInformation(TarjetaClass tarjeta)
    {
        number.text = "Visa/Tarjeta "+ tarjeta.number;
        fechaCaducidad.text = tarjeta.fechaCaducidad;

        data = tarjeta;
    }

    public void MostrarTarjeta()
    {
        FindObjectOfType<ConfiguracionController>().GoShowTarjeta(data);
    }
    
}
