using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIMenuManager : MonoBehaviour
{
    private GameManager gameManager;
    public TextMeshProUGUI MFtext;
    public void Start()
    {
        gameManager = GameManager.Instance;
        if (gameManager != null)
        {
            string topname = gameManager.TopName;
            int score = gameManager.TopScore;
            MFtext.text = $"The Badass MOFO to beat : {topname} : {score}";
        }
    }    

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OnNameChanged(string name)
    {
        Debug.Log(name);
        gameManager.PlayerName = name;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
}
