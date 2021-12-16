using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionTitleController : MonoBehaviour
{
    [SerializeField] Text title;

    //Button to access to delete of the collection
    public void VerMasCollection()
    {
        FindObjectOfType<PageController>().GoCollectionPage(title.text);
    }
}
