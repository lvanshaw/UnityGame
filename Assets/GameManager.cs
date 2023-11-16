using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;
    public string sceneName = "Level 2";
    public void GameOver()
    {

        if (!gameEnded)
        {
            UnityEngine.Debug.Log("Game Over");
            PlayerCollision.healthAmount = 100f;
            gameEnded = true;
            Restart();
        }

    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void GameStart() {
        SceneManager.LoadScene("Level 1");
    }

    public void CompletedLevel() {
        UnityEngine.Debug.Log("Completed");
        /*if (p.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }*/
    }
    
}
