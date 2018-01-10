using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

    public GameObject pausePanel;

	// Use this for initialization
	void Start () {

        Time.timeScale = 1;
        pausePanel.SetActive(false);
	}

    public void ClickPause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePause()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }


}
