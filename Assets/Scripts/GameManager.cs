using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int errors;
    public GameObject winscreen;

    void Start()
    {
     winscreen.SetActive(false);   
    }
    void Update()
    {
      if(Input.GetKeyDown("r")) 
   {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
    }

    public void Win()
    {
        if( errors == 0)
        {
          winscreen.SetActive(true);
        }
    }
}
