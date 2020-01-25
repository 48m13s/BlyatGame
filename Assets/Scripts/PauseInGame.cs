using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseInGame : MonoBehaviour
{
	public GameObject PauseButton;
	public GameObject MenuNavigation;
	public bool IfPause = false;
    // Update is called once per frame
    void Update()
    {
	    if (IfPause){
		    StartPause();
	    }
	    else if (!IfPause){
		    StartResume();
	    }
        
    }

    public void StartPause(){
	    PauseButton.SetActive(false);
	    MenuNavigation.SetActive(true);
	    IfPause = true;
	    Time.timeScale = 0f;
    }

    public void StartResume(){
	    PauseButton.SetActive(true);
	    MenuNavigation.SetActive(false);
	    IfPause = false;
	    Time.timeScale = 1f;
    }

    public void ExitGame(){
	    Application.Quit();
    }

    public void StartMenu(){
	    SceneManager.LoadScene("Menu");
	    Time.timeScale = 1f;
    }


}
