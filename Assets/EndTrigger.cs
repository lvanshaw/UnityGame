using UnityEngine.SceneManagement;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager manager;
    

    void OnTriggerEnter(Collider other) {
        
        manager.CompletedLevel();
        if (other.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().name == "Level 2")
            {
                UnityEngine.Debug.Log(SceneManager.GetActiveScene().name+" Here inside if");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
