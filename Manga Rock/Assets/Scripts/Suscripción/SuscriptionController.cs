using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class SuscriptionController : MonoBehaviour
{
    [SerializeField] Text estadoSuscripcion;
    [SerializeField] Text planSuscripción;

    [SerializeField] Button planMensual;
    [SerializeField] Button planAnual;

    [SerializeField] Button cancelarSub;
    [SerializeField] Button comprarSub;

    private string planActualSelected = "";
    private bool noSuscrito = false;

    //Add all the information in relation with the suscription
    public void AddData(List<SuscritoClass> list)
    {
        Debug.Log(list.Count);

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
                    planSuscripción.text = "MENSUAL";
                    planMensual.interactable = false;
                }
                else
                {
                    if (suscripcion.plan == "anual")
                    {
                        planSuscripción.text = "ANUAL";
                        planAnual.interactable = false;
                    }
                    else
                    {
                        planSuscripción.text = "-";
                    }
                }
            }
            i++;
        }

        if(list.Count == 0)
        {
            noSuscrito = true;
            estadoSuscripcion.text = "-";
            planSuscripción.text = "-";
            planMensual.interactable = true;
            planAnual.interactable = true;
            cancelarSub.interactable = false;
        }

        comprarSub.interactable = false;
    }

    //Cancel the suscription (button action)
    public void CancelSub()
    {
        FindObjectOfType<PopupController>().GoCancelSub();
    }

    //Select the plan that the player have
    public void PlanSelected(string plan)
    {
        if(plan == "mensual")
        {
            planActualSelected = "mensual";
        }
        else
        {
            planActualSelected = "anual";
        }
        comprarSub.interactable = true;
    }

    //Buy the sub - Send to firebase
    public void ComprarSub()
    {
        string username = FindObjectOfType<HomeInit>().GetUser().username;
        if(estadoSuscripcion.text == "SUSCRITO" )
        {
            //Si esta suscrito update de plan 
            FindObjectOfType<FirebasePageController>().UpdateSub(username, planActualSelected , "si");
        }
        else
        {
            if(noSuscrito)
            {
                Dictionary<string, object> sub = new Dictionary<string, object>
                {
                    {"plan", planActualSelected },
                    {"suscrito", "si" },
                    {"username", username }
                };

                FindObjectOfType<FirebasePageController>().AddSub(sub);
            }
        }
        UpdateView(planActualSelected, "si");

    }

    //Update the panel view, when user buy the sub
    public void UpdateView(string plan, string suscrito)
    {
        if(suscrito == "si")
        {
            estadoSuscripcion.text = "SUSCRITO";
            cancelarSub.interactable = true;
        }
        else
        {
            estadoSuscripcion.text = "-";
            cancelarSub.interactable = false;
        }
        if (plan == "mensual")
        {
            planSuscripción.text = "MENSUAL";
            planMensual.interactable = false;
        }
        else
        {
            if (plan == "anual")
            {
                planSuscripción.text = "ANUAL";
                planAnual.interactable = false;
            }
            else
            {
                planSuscripción.text = "-";
            }
        }

        comprarSub.interactable = false;


    }





}
