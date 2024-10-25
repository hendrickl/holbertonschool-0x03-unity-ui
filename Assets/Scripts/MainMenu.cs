using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour 
{
	public Material trapMat;
	public Material goalMat;
	public Toggle colorblindMode;

	public void PlayMaze()
	{
		if (colorblindMode != null && colorblindMode.isOn)
        {
            if (trapMat != null)
            {
                trapMat.color = new Color32(255, 112, 0, 255); // Orange
            }

            // Change goal material to blue
            if (goalMat != null)
            {
                goalMat.color = Color.blue;
            }
        }

		SceneManager.LoadScene("Maze");
	}

	public void QuitMaze()
	{
		// Application.Quit();
		Debug.Log("Quit Game");
	}
}
