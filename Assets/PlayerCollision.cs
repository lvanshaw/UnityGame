using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    //public PalayerM movement;

    void OnCollisionEnter(Collision collisionInfo) {

        if (collisionInfo.collider.tag == "Obstacles") {

            //movement.enabled = false;
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
