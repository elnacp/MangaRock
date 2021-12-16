using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WishlistButtonAnimation : MonoBehaviour
{
    [SerializeField] Sprite active;
    [SerializeField] Sprite deactive;

    //Activate wishlist button
    public void WishListButtonActive()
    {
        this.GetComponent<Image>().sprite = active;
    }

    //Deactivate wishlist button
    public void WishListButtonDeactive()
    {
        this.GetComponent<Image>().sprite = deactive;
    }
}
