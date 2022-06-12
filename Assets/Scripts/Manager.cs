using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void GotoTitle()
	{
		SceneManager.LoadScene("Title");
	}

	public void GotoStage1()
	{
		SceneManager.LoadScene("Stage1_Complete");
	}

	public void Restart()
	{
		if(PlayerPrefs.GetInt("SaveScene") == 1)
		{
			SceneManager.LoadScene("Stage1_Complete");
		}
		if (PlayerPrefs.GetInt("SaveScene") == 2)
		{
			SceneManager.LoadScene("Stage2_Complete");
		}
	}
}
