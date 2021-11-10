using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationBarController : MonoBehaviour
{
    
    [SerializeField] GameObject home;
    [SerializeField] GameObject library;
    [SerializeField] GameObject search;
    [SerializeField] GameObject notifications;
    [SerializeField] GameObject profile;

    [SerializeField] Transform bar;

    private Transform home_pos;
    private Transform library_pos;
    private Transform search_pos;
    private Transform noti_pos;
    private Transform profile_pos;

    


    private float speed = 1000;

    public Vector3 destination;

    private void Start()
    {
        home_pos = home.GetComponent<Transform>();
        library_pos = library.GetComponent<Transform>();
        search_pos = search.GetComponent<Transform>();
        noti_pos = notifications.GetComponent<Transform>();
        profile_pos = profile.GetComponent<Transform>();

        destination = bar.position;
    }

    public void Update()
    {
        bar.position = Vector3.MoveTowards(bar.position, destination, speed * Time.deltaTime);
    }


    public void GoHome()
    {
        MoveNavigationBar(1);
    }

    public void GoLibrary()
    {
        MoveNavigationBar(2);
    }

    public void GoSearch()
    {
        MoveNavigationBar(3);
    }

    public void GoNotifications()
    {
        MoveNavigationBar(4);
    }

    public void GoProfile()
    {
        MoveNavigationBar(5);
    }

    public void MoveNavigationBar(int num)
    {

        AllDisable();

        switch (num)
        {
            case 1:
                destination = new Vector3(home_pos.position.x + 15, bar.position.y);
                home.GetComponent<StateButtonNavigationBar>().ActiveButton();
                break;
            case 2:
                destination = new Vector3(library_pos.position.x + 15, bar.position.y);
                library.GetComponent<StateButtonNavigationBar>().ActiveButton();
                break;
            case 3:
                destination = new Vector3(search_pos.position.x + 15, bar.position.y);
                search.GetComponent<StateButtonNavigationBar>().ActiveButton();
                break;
            case 4:
                destination = new Vector3(noti_pos.position.x + 15, bar.position.y);
                notifications.GetComponent<StateButtonNavigationBar>().ActiveButton();
                break;
            case 5:
                destination = new Vector3(profile_pos.position.x + 15, bar.position.y);
                profile.GetComponent<StateButtonNavigationBar>().ActiveButton();
                break;
        }
    }

    public void AllDisable()
    {
        home.GetComponent<StateButtonNavigationBar>().DisableButton();
        library.GetComponent<StateButtonNavigationBar>().DisableButton();
        search.GetComponent<StateButtonNavigationBar>().DisableButton();
        notifications.GetComponent<StateButtonNavigationBar>().DisableButton();
        profile.GetComponent<StateButtonNavigationBar>().DisableButton();

    }


}
