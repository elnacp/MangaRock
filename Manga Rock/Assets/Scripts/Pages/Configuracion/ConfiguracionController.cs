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

    private string positionActual = "";

    public void GoMetodoPago()
    {
        HideNormalActionBar();
        HideAllPanels();
        metodoPago.SetActive(true);
        positionActual = "metodoPago";
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
        }
    }

    private void GoConfiguracionPanel()
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
