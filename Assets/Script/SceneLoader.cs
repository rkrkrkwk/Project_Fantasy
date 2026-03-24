using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void StartGame(int saveSlot)
    {
        SaveManager.Instance.SetSaveSlot(saveSlot);
        SceneManager.LoadScene("InGame");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
