using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private bool gameEnded = false;

    public GameObject gameOverUI;

	// Update is called once per frame
	void Update () {
		if (gameEnded)
        {
            return;
        }

        if (Input.GetKeyDown("k"))
        {
            EndGame();
        }

        if (NexusStats.nexusHealth <= 0)
        {
            EndGame();
        }
	}

    void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
    }
}
