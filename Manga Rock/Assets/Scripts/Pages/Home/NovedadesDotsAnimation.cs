using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NovedadesDotsAnimation : MonoBehaviour
{

    [SerializeField] Transform content;
    [SerializeField] GameObject dot_prefab;

    private GameObject[] dots;

    void Start()
    {

    }

    public void AddDots(int numberDots)
    {
        if(content.childCount == 0)
        {
            AddDotList(numberDots);
        }
        else
        {
            foreach(Transform child in content)
            {
                GameObject.Destroy(child.gameObject);
            }

            for(int i = 0; i < numberDots; i++)
            {
                Destroy(dots[i]);
            }

            AddDotList(numberDots);
        }


        
    }

    private void AddDotList(int num)
    {
        for (int i = 0; i < num; i++)
        {
            GameObject prefab = Instantiate(dot_prefab, content);
            if (i == 0)
            {
                prefab.GetComponent<DotController>().ActivateDot();
            }
            else
            {
                prefab.GetComponent<DotController>().DeactivateDot();
            }
        }

        SaveAllDots();
    }

    private void SaveAllDots()
    {
        dots = GameObject.FindGameObjectsWithTag("dot");
    }

    

    public void MoveDot(int index)
    {
 
        MakeAllDotsInactive();

        dots[index].GetComponent<DotController>().ActivateDot();
       
    }

    private void MakeAllDotsInactive()
    {
        for(int i = 0; i < dots.Length; i++)
        {
            dots[i].GetComponent<DotController>().DeactivateDot();
        }
    }

}
