using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeController : MonoBehaviour
{

    [SerializeField] NovedadesController p_novedades;
    [SerializeField] RecomendacionesController p_recomendaciones;
    [SerializeField] TopVentasController p_topventas;

    //Ask the information to firebase
    public void AddInformation()
    {
        p_novedades.GetNovedades();
        p_recomendaciones.GetRecomendaciones();
        p_topventas.GetTopVentas();
    }







}
