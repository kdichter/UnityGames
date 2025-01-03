using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net.NetworkInformation;

public class PauseGame : MonoBehaviour
{
    public Camera cam;
    public static bool isPaused = false;
    public static bool isGameOver = false;
    public static bool isWin = false;
    public GameObject enemy;
    public GameObject PauseMenuUI;
    public GameObject GameOverUI;
    public GameObject WinUI;
    public GameObject CrosshairUI;

    // public GameObject[] player;
    public void Win()
    {
        isWin = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemy.SetActive(false);
        CrosshairUI.SetActive(false);
        WinUI.SetActive(true);
    }
    public void GameOver()
    {
        isGameOver = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameOverUI.SetActive(true);
        CrosshairUI.SetActive(false);
    }
    public void Pause()
    {
        // if not paused
        if (Time.timeScale == 1)
        {
            // pause and activate pause menu
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            CrosshairUI.SetActive(false);
            PauseMenuUI.SetActive(true);
            isPaused = true;
        }
        else
        {
            // if paused, resume game and remove pause menu
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            CrosshairUI.SetActive(true);
            PauseMenuUI.SetActive(false);
            isPaused = false;
        }
    }

    public void Restart()
    {
        // Reset player elements if necessary and set time and UI properly
        SceneManager.LoadScene("Main");
        isPaused = false;
        isGameOver = false;
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        CrosshairUI.SetActive(true);
        PauseMenuUI.SetActive(false);
        GameOverUI.SetActive(false);
    }

    public void Quit()
    {
        //Debug.Log("Quitting Game...");
        Application.Quit();
    }

    public void TitleScreen()
    {
        SceneManager.LoadScene("Title Screen");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
}