using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WishlistController : MonoBehaviour
{
    [SerializeField] Transform content;
    [SerializeField] GameObject prefab;
   
    public void AddMangas(List<WishlistClass> wishlist)
    {
        int i = 1;
        foreach(WishlistClass manga in wishlist)
        {
            GameObject element = Instantiate(prefab, content);
            element.GetComponent<WishlistPrefab>().AddInformation(manga, i);
            i++;
        }
    }

}
