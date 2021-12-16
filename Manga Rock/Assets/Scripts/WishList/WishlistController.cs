using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WishlistController : MonoBehaviour
{
    [SerializeField] Transform content;
    [SerializeField] GameObject prefab;
    [SerializeField] FirebasePageController firebase;
    [SerializeField] HomeInit userData;
   
    //Add the information of the mangas in the wishlist
    public void AddMangas(List<WishlistClass> wishlist)
    {
        DeleteContent();
        int i = 1;
        foreach(WishlistClass manga in wishlist)
        {
            GameObject element = Instantiate(prefab, content);
            element.GetComponent<WishlistPrefab>().AddInformation(manga, i);
            i++;
        }
    }

    //update the wishlist
    public void UpdateWishlist(string title)
    {
        foreach(Transform child in content.transform)
        {
            if(child.tag == "manga")
            {
                if(child.GetComponent<WishlistPrefab>().GetTitleManga() == title)
                {
                    Destroy(child.gameObject);
                }
            }
        }

    }

    //delete the content
    public void DeleteContent()
    {
        foreach (Transform child in content.transform)
        {
           if(child.tag == "manga")
           {
                Destroy(child.gameObject);
           }
        }
    }

   

}
