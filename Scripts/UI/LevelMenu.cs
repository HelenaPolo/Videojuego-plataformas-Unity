using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{

	public GameObject nivel1;
	public GameObject nivel2;
	public GameObject nivel3;

    
    void Start()
    {
		if (General.currentLevel >= 1)
		{
			 nivel1.gameObject.GetComponent<Image>().color = new Color(nivel1.gameObject.GetComponent<Image>().color.r, nivel1.gameObject.GetComponent<Image>().color.g, nivel1.gameObject.GetComponent<Image>().color.b, 1.0f);
		}

		if (General.currentLevel >= 2)
		{
			 nivel2.gameObject.GetComponent<Image>().color = new Color(nivel2.gameObject.GetComponent<Image>().color.r, nivel2.gameObject.GetComponent<Image>().color.g, nivel2.gameObject.GetComponent<Image>().color.b, 1.0f);
		}

		if (General.currentLevel >= 3)
		{
			nivel3.gameObject.GetComponent<Image>().color = new Color(nivel3.gameObject.GetComponent<Image>().color.r, nivel3.gameObject.GetComponent<Image>().color.g, nivel3.gameObject.GetComponent<Image>().color.b, 1.0f);
		}
    }

	public void GoToLevel1()
	{
		if (General.currentLevel >= 1)
		{
			SceneManager.LoadScene("Level1");
		}
	}
	public void GoToLevel2() {

		if (General.currentLevel >= 2) 
		{ 
			SceneManager.LoadScene("Level2");
		}
	}
	public void GoToLevel3()
	{
		if (General.currentLevel >= 3) {
			SceneManager.LoadScene("Level3");
		}
	}

}
