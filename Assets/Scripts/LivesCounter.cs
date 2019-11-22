using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesCounter : MonoBehaviour
{
    public int lives;

    public int maxNumberOfLives = 3;

    private GameObject[] hearts;

    // Start is called before the first frame update
    void Start()
    {
        // Set the initial number of lives to its maximum
        lives = maxNumberOfLives;

        // Initialise the array of hearts
        hearts = new GameObject[maxNumberOfLives];

        // Cycle among children and get the hearts we need
        for (int i = 0; i < maxNumberOfLives; i++)
        {
            hearts[i] = transform.GetChild(i).gameObject;
        }
    }

    public void AddLife()
    {
        if (lives < maxNumberOfLives)
        {
            lives++;
        }

        UpdateGrafics();
    }

    public void RemoveLife()
    {
        lives--;
        if (lives <= 0)
        {
            // TODO: Game Over Screen
            SceneManager.LoadScene("Level1");
        }

        UpdateGrafics();
    }

    public void UpdateGrafics()
    {
        for (int i = 0; i < maxNumberOfLives; i++)
        {
            hearts[i].SetActive(i < lives);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
