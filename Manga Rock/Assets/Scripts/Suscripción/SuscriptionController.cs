using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SuscriptionController : MonoBehaviour
{
    [SerializeField] Text estadoSuscripcion;
    [SerializeField] Text planSuscripci�n;

    [SerializeField] Button planMensual;
    [SerializeField] Button planAnual;

    [SerializeField] Button cancelarSub;

    public void AddData(List<SuscritoClass> list)
    {
        int i = 0;
        foreach(SuscritoClass suscripcion in list)
        {
            if(i == 0)
            {
                if (suscripcion.suscrito == "si")
                {
                    estadoSuscripcion.text = "SUSCRITO";
                }
                else
                {
                    estadoSuscripcion.text = "NO SUSCRITO";
                    cancelarSub.interactable = false;

                }

                if (suscripcion.plan == "mensual")
                {
                    planSuscripci�n.text = "MENSUAL";
                    planMensual.interactable = false;
                }
                else
                {
                    if (suscripcion.plan == "anual")
                    {
                        planSuscripci�n.text = "ANUAL";
                        planAnual.interactable = false;
                    }
                    else
                    {
                        planSuscripci�n.text = "-";
                    }
                }
            }
            i++;
        }
    }

    public void CancelSub()
    {
        FindObjectOfType<PopupController>().GoCancelSub();
    }
}
