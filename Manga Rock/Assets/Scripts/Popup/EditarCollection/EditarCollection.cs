using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditarCollection : MonoBehaviour
{
    [SerializeField] GameObject prefabManga;
    [SerializeField] GameObject line;
    [SerializeField] Transform content;
    [SerializeField] Text title;

    private List<ColeccionBibliotecaClass> listCollection = new List<ColeccionBibliotecaClass>();
    private List<ColeccionBibliotecaClass> removeItems = new List<ColeccionBibliotecaClass>();
    public void AddMangas(List<ColeccionBibliotecaClass> list, string name)
    {
        ClearContent();

        listCollection = list;
        title.text = name;

        int amount = list.Count;
        int i = 1;
        foreach(ColeccionBibliotecaClass element in list)
        {
            GameObject prefab = Instantiate(prefabManga, content);
            prefab.GetComponent<MangaDeleteCollection>().AddManga(element);
            if(i != amount)
            {
                Instantiate(line, content);
            }
            i++;
        }

    }

    private void ClearContent()
    {
        foreach(Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }

    public void AddDeleteList(ColeccionBibliotecaClass element)
    {
        removeItems.Add(element);
    }

    public void RemoveFromDeleteList(ColeccionBibliotecaClass element)
    {
        removeItems.Remove(element);
    }
  
    public void AcceptRemove()
    {
        Debug.Log(removeItems.Count);
    }

    
    


}
