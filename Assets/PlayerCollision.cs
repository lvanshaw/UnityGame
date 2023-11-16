using System;
using UnityEngine;
using UnityEngine.UI;
public class PlayerCollision : MonoBehaviour
{
    //public PalayerM movement;

    public Image healthBar;
    //Player p = new Player();
    public static float healthAmount = 100f;

    void Start() {
        healthBar.fillAmount = healthAmount;
    }
    void OnCollisionEnter(Collision collisionInfo) {

        if (collisionInfo.collider.tag == "Obstacles") {

            //movement.enabled = false;
            TakeDamage(35);
            if(healthAmount <=0)
                FindObjectOfType<GameManager>().GameOver();
                
                //Application.LoadLevel(Application.loadedLevel)
        }
    }

    public void TakeDamage(float damage) {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Heal(float healingAmount) {
        healthAmount += healingAmount;
        healthAmount = Math.Clamp(healingAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100f;
    }
}
