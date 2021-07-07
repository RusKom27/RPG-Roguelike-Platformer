using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
	public int allowScene = 1;
	private GameObject step1, step2, step3, step4, step5, _HUD;
	private void Awake()
	{
		step1 = GameObject.Find("Canvas/StartScene/Step1");
		step2 = GameObject.Find("Canvas/StartScene/Step2");
		step3 = GameObject.Find("Canvas/StartScene/Step3");
		step4 = GameObject.Find("Canvas/StartScene/Step4");
		step5 = GameObject.Find("Canvas/StartScene/Step5");
		_HUD = GameObject.Find("Canvas/HUD");
	}
	private void Start()
	{
		Time.timeScale = 0;
		_HUD.SetActive(false);
		if (allowScene == 0)
		{
			Over();
			Time.timeScale = 1;
		}
		step2.SetActive(false);
		step3.SetActive(false);
		step4.SetActive(false);
		step5.SetActive(false);
		
	}
	public void ToStep2()
	{
		step1.SetActive(false);
		step2.SetActive(true);
	}
	public void ToStep3()
	{
		step2.SetActive(false);
		step3.SetActive(true);
	}
	public void ToStep4()
	{
		step3.SetActive(false);
		step4.SetActive(true);
	}
	public void ToStep5()
	{
		step4.SetActive(false);
		step5.SetActive(true);
	}
	public void Over()
	{
		gameObject.SetActive(false);
		_HUD.SetActive(true);
		allowScene = 0;
		Time.timeScale = 1;
		PlayerPrefs.SetInt("allowScene", 0);
	}
}
