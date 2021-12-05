using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificacionesController : MonoBehaviour
{
    [SerializeField] Transform content;
    [SerializeField] GameObject prefabnotificaciones;

    public void AddNotificaciones(List<NotificacionClass> notificaciones)
    {
        DeleteContent();
        
        if(notificaciones.Count != 0)
        {
            foreach(NotificacionClass noti in notificaciones)
            {
                GameObject prefab = Instantiate(prefabnotificaciones, content);
                prefab.GetComponent<PrefabNotificacion>().AddInformation(noti);
            }
        }

    }

    public void DeleteContent()
    {
        foreach(Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }
}
