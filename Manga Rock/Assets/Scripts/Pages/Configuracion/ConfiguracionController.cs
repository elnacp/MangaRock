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

    //Show metodo the pago panel
    public void GoMetodoPago()
    {
        HideNormalActionBar();
        HideAllPanels();
        metodoPago.SetActive(true);
        positionActual = "metodoPago";
        firebase.AskTarjeta(userData.GetUser().username);
        firebase.AskPaypal(userData.GetUser().username);
    }

    //Show notifications panel
    public void GoNotificaciones()
    {
        HideNormalActionBar();
        HideAllPanels();
        notificaciones.SetActive(true);
        positionActual = "notificaciones";
    }

    //Show edit profile panel
    public void GoEditarPerfil()
    {
        HideAllPanels();
        HideNormalActionBar();
        editarPerfil.SetActive(true);
        positionActual = "editarPerfil";

    }

    //Go Back button depending in where the user is
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
            case "addPaypal":
                GoMetodoPago();
                break;
            case "showPaypal":
                GoMetodoPago();
                break;
        }
    }

    //Show Change password panel
    public void GoChangePasswordPanel()
    {
        HideNormalActionBar();
        HideAllPanels();
        changePasswordPanel.SetActive(true);
        positionActual = "editarContraseña";
    }

    //Show add tarjeta panel
    public void GoAddTarjeta()
    {
        HideNormalActionBar();
        HideAllPanels();
        addTarjetaPanel.SetActive(true);
        positionActual = "addTarjeta";
    }

    //Show add paypal panel
    public void GoAddPaypal()
    {
        HideNormalActionBar();
        HideAllPanels();
        addPaypalPanel.SetActive(true);
        positionActual = "addPaypal";
    }

    // Show tarjeta panel
    public void GoShowTarjeta(TarjetaClass tarjeta)
    {
        HideNormalActionBar();
        HideAllPanels();
        showTarjetaPanel.SetActive(true);
        positionActual = "showTarjeta";
        showTarjetaPanel.GetComponent<ShowTarjetaController>().AddInformation(tarjeta);
    }

    //Show paypal panel
    public void GoShowPaypal(PaypalClass paypal)
    {
        HideNormalActionBar();
        HideAllPanels();
        showPaypalPanel.SetActive(true);
        positionActual = "showPaypal";
        showPaypalPanel.GetComponent<ShowPaypalController>().AddInformation(paypal);
    }

    //Show configuration panel
    public void GoConfiguracionPanel()
    {
        HideAllPanels();
        ActivateNormalActionBar();
        configuracionPanel.SetActive(true);
    }

    //Hide all the panels
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

    //Hide action bar with shoplist and menu
    private void HideNormalActionBar()
    {
        actionBarNormal.SetActive(false);
        actionBarconfiguracion.SetActive(true);
    }

    //Activate action bar with shoplist and menu
    private void ActivateNormalActionBar()
    {
        actionBarNormal.SetActive(true);
        actionBarconfiguracion.SetActive(false);
    }


}
