using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfiguracionController : MonoBehaviour
{
    [SerializeField] GameObject actionBarconfiguracion;
    [SerializeField] GameObject actionBarNormal;

    [SerializeField] GameObject metodoPago;
    [SerializeField] GameObject notificaciones;
    [SerializeField] GameObject editarPerfil;
    [SerializeField] GameObject configuracionPanel;
    [SerializeField] GameObject changePasswordPanel;
    [SerializeField] GameObject addTarjetaPanel;
    [SerializeField] GameObject showTarjetaPanel;
    [SerializeField] GameObject addPaypalPanel;
    [SerializeField] GameObject showPaypalPanel;


    [SerializeField] FirebasePageController firebase;
    [SerializeField] HomeInit userData;


    private string positionActual = "";

    public void GoMetodoPago()
    {
        HideNormalActionBar();
        HideAllPanels();
        metodoPago.SetActive(true);
        positionActual = "metodoPago";
        firebase.AskTarjeta(userData.GetUser().username);
        firebase.AskPaypal(userData.GetUser().username);
    }

    

    public void GoNotificaciones()
    {
        HideNormalActionBar();
        HideAllPanels();
        notificaciones.SetActive(true);
        positionActual = "notificaciones";
    }

    public void GoEditarPerfil()
    {
        HideAllPanels();
        HideNormalActionBar();
        editarPerfil.SetActive(true);
        positionActual = "editarPerfil";

    }

    public void GoBack()
    {
        HideAllPanels();
        switch(positionActual)
        {
            case "metodoPago":
                GoConfiguracionPanel();
                break;
            case "notificaciones":
                GoConfiguracionPanel();
                break;
            case "editarPerfil":
                GoConfiguracionPanel();
                break;
            case "editarContraseña":
                GoEditarPerfil();
                break;
            case "addTarjeta":
                GoMetodoPago();
                break;
            case "showTarjeta":
                GoMetodoPago();
                break;
        }
    }

    public void GoChangePasswordPanel()
    {
        HideNormalActionBar();
        HideAllPanels();
        changePasswordPanel.SetActive(true);
        positionActual = "editarContraseña";
    }

    public void GoAddTarjeta()
    {
        HideNormalActionBar();
        HideAllPanels();
        addTarjetaPanel.SetActive(true);
        positionActual = "addTarjeta";
    }

    public void GoShowTarjeta(TarjetaClass tarjeta)
    {
        HideNormalActionBar();
        HideAllPanels();
        showTarjetaPanel.SetActive(true);
        positionActual = "showTarjeta";
        showTarjetaPanel.GetComponent<ShowTarjetaController>().AddInformation(tarjeta);
    }


    public void GoShowPaypal(PaypalClass paypal)
    {
        HideNormalActionBar();
        HideAllPanels();
        showPaypalPanel.SetActive(true);
        positionActual = "showPaypal";
        showPaypalPanel.GetComponent<ShowPaypalController>().AddInformation(paypal);
    }

    public void GoConfiguracionPanel()
    {
        HideAllPanels();
        ActivateNormalActionBar();
        configuracionPanel.SetActive(true);
    }



    private void HideAllPanels()
    {
        configuracionPanel.SetActive(false);
        metodoPago.SetActive(false);
        notificaciones.SetActive(false);
        editarPerfil.SetActive(false);
        configuracionPanel.SetActive(false);
        changePasswordPanel.SetActive(false);
        addTarjetaPanel.SetActive(false);
        showTarjetaPanel.SetActive(false);
        addPaypalPanel.SetActive(false);
        showPaypalPanel.SetActive(false);
    }

    private void HideNormalActionBar()
    {
        actionBarNormal.SetActive(false);
        actionBarconfiguracion.SetActive(true);
    }

    private void ActivateNormalActionBar()
    {
        actionBarNormal.SetActive(true);
        actionBarconfiguracion.SetActive(false);
    }


}
