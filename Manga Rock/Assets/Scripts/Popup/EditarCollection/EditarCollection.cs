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

    //Add information
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

    //Clear the content
    private void ClearContent()
    {
        foreach(Transform child in content)
        {
            Destroy(child.gameObject);
        }
    }

    //Add manga to delete list
    public void AddDeleteList(ColeccionBibliotecaClass element)
    {
        removeItems.Add(element);
    }

    //Remove manga from collection
    public void RemoveFromDeleteList(ColeccionBibliotecaClass element)
    {
        removeItems.Remove(element);
    }
  
    //Accept button
    public void AcceptRemove()
    {
        foreach(ColeccionBibliotecaClass element in removeItems)
        {
            string username = FindObjectOfType<HomeInit>().GetUser().username;
            FindObjectOfType<FirebasePageController>().DeleteMangaFromCollection(element, username, title.text);
            listCollection.Remove(element);
        }

        FindObjectOfType<PopupController>().HidePopup();

        //FindObjectOfType<PageController>().ChangePage("library");
        FindObjectOfType<CollectionPageController>().AddInformation(listCollection);
    }

    //Cancel button
    public void Cancel()
    {
        FindObjectOfType<PopupController>().HidePopup();
        FindObjectOfType<CollectionPageController>().AddInformation(listCollection);

    }







}
