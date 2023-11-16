using UnityEngine.SceneManagement;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager manager;
    

    void OnTriggerEnter(Collider other) {
        manager.CompletedLevel();
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level 2");
        }
    }
}
