using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    public Button CtButton;
    private void Awake()
    {
        SaveObjects save = SaveManager.Load();
        if(save != null)
        {
            if (save.Saved)
                CtButton.interactable = true;
        }
    }
    public void ContinueButton()
    {
        SceneManager.LoadScene("1");
    }
    public void NewGameButton()
    {
        SaveObjects save = new SaveObjects();
        save.Saved = false;
        SaveManager.Save(save);
        SceneManager.LoadScene("1");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
