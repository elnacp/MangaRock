using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TarjetaController : MonoBehaviour
{
    [SerializeField] Text number;
    [SerializeField] Text fechaCaducidad;

    TarjetaClass tarjeta;
    public void AddInformation(TarjetaClass tarjeta)
    {
        number.text = "Visa/Tarjeta "+ tarjeta.number;
        fechaCaducidad.text = tarjeta.fechaCaducidad;

        this.tarjeta = tarjeta;
    }
}
