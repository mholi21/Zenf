using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public void StartGame()
    {
        Camera.main.GetComponent<Camera1st>().enabled = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnBomb>().enabled = true;
        gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
