using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionTitleController : MonoBehaviour
{
    [SerializeField] Text title;

    public void VerMasCollection()
    {
        FindObjectOfType<PageController>().GoCollectionPage(title.text);
    }
}
