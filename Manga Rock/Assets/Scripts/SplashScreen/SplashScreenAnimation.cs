using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase.Firestore;

public class SplashScreenAnimation : MonoBehaviour
{

    public Image splashImage;
    FirebaseFirestore db;
    private bool isLogged = false;
    private bool ask = false;

    IEnumerator Start()
    {
        db = FirebaseFirestore.DefaultInstance;
        splashImage.canvasRenderer.SetAlpha(0.0f);
        FadeIn();
        yield return new WaitForSeconds(2.5f);
        FadeOut();
        yield return new WaitForSeconds(2.5f);
        //SceneManager.LoadScene("LogIn");
        SomeUserIsLogged();
        

    }

    private void Update()
    {
        if(ask)
        {
            if(isLogged)
            {
                SceneManager.LoadScene("Home");
            }
            else
            {
                SceneManager.LoadScene("LogIn");
            }
        }
    }

    private void SomeUserIsLogged()
    {
        db.Collection("User").WhereEqualTo("loggeado", "yes").GetSnapshotAsync().ContinueWith((task) =>
        {
            if (task.IsCompleted)
            {
                if (task.Result.Count == 0)
                {
                    //no user loggead
                    isLogged = false;
                }
                else
                {
                    isLogged = true;
                }
  
            }
            ask = true;
        });
    }

    void FadeIn()
    {
        splashImage.CrossFadeAlpha(1.0f, 1.5f, false);
    }

    void FadeOut()
    {
        splashImage.CrossFadeAlpha(0.0f, 2.5f, false);
    }
}
