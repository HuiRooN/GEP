using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{

	Animator anim;
	public GameObject WarningPanel;

	private AudioSource audio1;
	public AudioClip doorsound;

	// Start is called before the first frame update
	void Start()
    {
		anim = GetComponent<Animator>();
		WarningPanel.SetActive(false);
		this.audio1 = this.gameObject.AddComponent<AudioSource>();
		this.audio1.clip = this.doorsound;
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (SceneManager.GetActiveScene().name == "Stage1_Complete" && Player.missionPoint == 2)
			{
				anim.SetBool("isOpen", true);
				this.audio1.volume = 0.5f;
				this.audio1.Play();
			}
			if (SceneManager.GetActiveScene().name == "Stage1_Complete" && Player.missionPoint != 2)
			{
				WarningPanel.SetActive(true);
				StartCoroutine(Wait());
			}
		}

		if (SceneManager.GetActiveScene().name == "Stage2_Complete" && other.gameObject.tag == "Player")
		{
			anim.SetBool("isOpen", true);
			this.audio1.volume = 0.5f;
			this.audio1.Play();
		}
	}

	void OnTriggerExit(Collider other)
	{
		anim.SetBool("isOpen", false);
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(3.0f);
		WarningPanel.SetActive(false);
	}

}
