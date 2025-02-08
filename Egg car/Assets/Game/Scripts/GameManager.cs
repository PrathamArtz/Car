using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int playerLife = 3; // Set initial life count

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void ReduceLife()
    {
        playerLife--;
        Debug.Log("Life Reduced! Remaining Life: " + playerLife);

        if (playerLife <= 0)
        {
            Debug.Log("Game Over!");
            // Add Game Over logic here
        }
    }
}
