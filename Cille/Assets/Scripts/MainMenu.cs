using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); // Oyun sahnesine geç
    }

    public void ExitGame()
    {
        Application.Quit(); // Oyundan çık
        Debug.Log("Oyun kapandı!"); // Editor'de test için log bas
    }
}
