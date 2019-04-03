using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Options;
    public Image CanvasBack;

    void Start()
    {
        MainMenu.SetActive(true);
        Options.SetActive(false);
        CanvasBack = GetComponent<Image>();
        DontDestroyOnLoad(this.gameObject);
    }

    public void ShowMenuMain()
    {
        MainMenu.SetActive(true);
        Options.SetActive(false);
    }

    public void ShowMenuOptions()
    {
        MainMenu.SetActive(false);
        Options.SetActive(true);
    }

    public void NewGame()
    {
        MainMenu.SetActive(false);
        Options.SetActive(false);
        CanvasBack.enabled = false;
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    void Update()
    {
        
    }
}
