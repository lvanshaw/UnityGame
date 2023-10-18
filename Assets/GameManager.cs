using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;
    public void GameOver()
    {

        if (!gameEnded)
        {
            UnityEngine.Debug.Log("Game Over");
            gameEnded = true;
            Restart();
        }

    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void CompletedLevel() {
        UnityEngine.Debug.Log("Completed");
    }
    
}
