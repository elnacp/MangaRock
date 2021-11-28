using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LibraryController : MonoBehaviour
{
    [SerializeField] GameObject bibliotecaPanel;
    [SerializeField] GameObject coleccionesPanel;

    [SerializeField] GameObject button_biblioteca;
    [SerializeField] GameObject button_colecciones;

    public void GoBiblioteca()
    {
        ButtonSelected(button_biblioteca);
        ButtonDeselected(button_colecciones);
        bibliotecaPanel.SetActive(true);
        coleccionesPanel.SetActive(false);
    }

    public void GoCollection()
    {
        ButtonSelected(button_colecciones);
        ButtonDeselected(button_biblioteca);
        bibliotecaPanel.SetActive(false);
        coleccionesPanel.SetActive(true);
    }

    public void ButtonSelected(GameObject button)
    {
        button.GetComponent<Image>().color = Color.black;
        button.transform.GetChild(0).GetComponent<Text>().color = Color.white;
    }

    public void ButtonDeselected(GameObject button)
    {
        button.GetComponent<Image>().color = Color.white;
        button.transform.GetChild(0).GetComponent<Text>().color = Color.black;
    }
}
