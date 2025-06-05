using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainManager : MonoBehaviour
{
    public void OnReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
