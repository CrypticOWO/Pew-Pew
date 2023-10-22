using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransferScore : MonoBehaviour
{
    public Text PlayerScore; // Reference to the UI Text element

    // Start is called before the first frame update
    void Start()
    {
        // Retrieve the saved score from PlayerPrefs
        float Score = PlayerPrefs.GetFloat("Score", 0f);

        // Update the UI Text with the retrieved score
        PlayerScore.text = Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
