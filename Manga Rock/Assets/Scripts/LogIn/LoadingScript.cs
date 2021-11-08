using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScript : MonoBehaviour
{

    private float speed = 800f;

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<RectTransform>().Rotate(0f, 0f, speed * Time.deltaTime);
    }


}
