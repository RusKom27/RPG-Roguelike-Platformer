using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
	private Animator _transitionsSceneAnimator;
	private GameObject panelPause, panelOptions, fadePause, NPCTask, _pauseButton;
	private bool isPaused = false;
    //public AudioSource someSound;

    private void Awake()
	{
		panelPause = GameObject.Find("Canvas/Pause/Panel");
		panelOptions = GameObject.Find("Canvas/Pause/Options");
		fadePause = GameObject.Find("Canvas/Pause/FadePause");
		NPCTask = GameObject.Find("Canvas/Dialog/NPCTask");
		_pauseButton = GameObject.Find("Canvas/PauseButton");
		_transitionsSceneAnimator = GameObject.Find("Canvas/TransitionsScene").GetComponent<Animator>();
	}

	private void Start()
	{
		panelPause.SetActive(false);
		panelOptions.SetActive(false);
		fadePause.SetActive(false);
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
            if (!isPaused)
            {
                
                ToPause();
            }
            else
            {
                
                OutPause();
            }
            //someSound.Play();
        }
	}

	public void ToPause()
	{
		if (!isPaused)
		{
			if(_pauseButton.activeSelf)
				_pauseButton.SetActive(false);
			isPaused = true;
			panelPause.SetActive(true);
			fadePause.SetActive(true);
			if (Time.timeScale == 1)
				Time.timeScale = 0;
		}
	}

	public void OutPause()
	{
		if (isPaused)
		{
			if (!_pauseButton.activeSelf)
				_pauseButton.SetActive(true);
			isPaused = false;
			panelPause.SetActive(false);
			fadePause.SetActive(false);
			panelOptions.SetActive(false);
			Time.timeScale = 1;
			if (NPCTask.activeSelf)
				Time.timeScale = 0;
		}
	}
	public void Continue()
	{
		if (!_pauseButton.activeSelf)
			_pauseButton.SetActive(true);
		isPaused = false;
		panelPause.SetActive(false);
		fadePause.SetActive(false);
		Time.timeScale = 1;
		if (NPCTask.activeSelf)
			Time.timeScale = 0;
	}
	public void ToMenu()
	{
		if (!_pauseButton.activeSelf)
			_pauseButton.SetActive(true);
		Time.timeScale = 1;
		isPaused = false;
		gameObject.SetActive(false);
		_transitionsSceneAnimator.SetTrigger("Exit");
		
	}
	public void LoadSceneAnimation(int index)
	{
		SceneManager.LoadScene(index);
	}

	public void InOptions()
	{
		panelPause.SetActive(false);
		panelOptions.SetActive(true);
	}
	public void OutOptions()
	{
		panelPause.SetActive(true);
		panelOptions.SetActive(false);
	}
	public void DeathButton()
	{
		_transitionsSceneAnimator.SetTrigger("Exit");
	}

}
