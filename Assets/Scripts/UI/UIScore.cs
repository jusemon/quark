using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    /// <summary>
    /// The UI text
    /// Reference to the Text component, set in the Start() function
    /// </summary>
    private Text uiText;

    /// <summary>
    /// Current score of the player
    /// </summary>
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        // Get a Reference to the Text component
        uiText = GetComponent<Text>();
    }

    // Update is called once per frame
    public void IncreaseScore(int points)
    {
        // Increase the points
        score += points;

        // Update the score count
        uiText.text = score.ToString("000");
    }
}
