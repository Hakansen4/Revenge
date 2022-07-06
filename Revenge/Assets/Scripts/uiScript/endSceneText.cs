using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class endSceneText : MonoBehaviour
{
    public TextMeshProUGUI MainText, GoMenu;
    private bool goMenuActive = false;
    GameObject gameMusic;
    [Multiline]
    public string Maintxt;
    void Start()
    {
        gameMusic = GameObject.FindGameObjectWithTag("GameMusics");
        Destroy(gameMusic);
        StartCoroutine("WriteMaintxt");
    }
    private void Update()
    {
        if (goMenuActive)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
    private IEnumerator WriteMaintxt()
    {
        foreach (char i in Maintxt)
        {
            MainText.text += i.ToString();
            if (i.ToString() == ".")
                yield return new WaitForSeconds(1);
            else
                yield return new WaitForSeconds(0.1f);
        }
        StartCoroutine(menuBT());
    }
    private IEnumerator menuBT()
    {
        yield return new WaitForSeconds(3);
        GoMenu.gameObject.SetActive(true);
        goMenuActive = true;
    }
}