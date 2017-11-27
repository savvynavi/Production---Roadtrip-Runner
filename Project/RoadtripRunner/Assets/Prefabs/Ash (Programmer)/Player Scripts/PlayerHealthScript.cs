using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthScript : MonoBehaviour
{
    public int playerHealth = 3;
    public float minimumKnockback = 30.0f;
    public float knockbackMultiplier = 1.1f;
    public int sceneToUnload = 1;

    public string obstacleTag = "Obstacle";
    public string menuControllerTag = "MenuController";

    private bool bouncing = false;


    void Update()
    {
        if (playerHealth > 0) { return; }

        GameObject.FindGameObjectWithTag(menuControllerTag).GetComponent<MenuControl>().OnGameEnd();
        SceneManager.UnloadSceneAsync(sceneToUnload);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == obstacleTag)
        {
            DamageAndMove(1);
            bouncing = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == obstacleTag && bouncing)
            bouncing = false;
    }

    public void DamageAndMove(int Damage)
    {
        if (!bouncing)
            playerHealth -= Damage;

        float knockback = (GetComponent<Rigidbody>().velocity.x < minimumKnockback) ? minimumKnockback : GetComponent<Rigidbody>().velocity.x;
        GetComponent<Rigidbody>().AddForce(new Vector3(-knockback * knockbackMultiplier, -4, 0), ForceMode.Impulse);
    }
}