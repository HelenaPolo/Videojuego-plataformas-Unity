using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndPanel : MonoBehaviour
{
 
	public void ContinueLevel()
	{
		if (General.currentLevel == 1)
		{
			SceneManager.LoadScene("Level1");
		}
		if (General.currentLevel == 2)
		{
			SceneManager.LoadScene("Level2");
		}
		if (General.currentLevel == 3)
		{
			SceneManager.LoadScene("Level3");
		}
		Debug.Log(General.currentLevel);
	}



}
