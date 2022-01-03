using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameMenu : MonoBehaviour {

	public UIDocument menuScreen;
	private VisualElement _root;
	private bool isPaused = false;
	
	private void OnEnable()
	{
		
		AssignButtonEvents();
		Time.timeScale = 0; // pause the scene
	}

	private void hide(VisualElement ve)
	{
		ve.style.display = DisplayStyle.None;
	}

	private void show(VisualElement ve)
	{
		ve.style.display = DisplayStyle.Flex;
	}
	
	private void AssignButtonEvents()
	{
		
		_root = menuScreen.rootVisualElement;
		_root.Q<Button>("pause-button").clicked += () => Time.timeScale = 0;
		var inGameButtons = _root.Q<VisualElement>("in-game-buttons");
		var startMenuWrapper = _root.Q<VisualElement>("start-menu-wrapper");
		hide(inGameButtons);
		var startButton = _root.Q<Button>("start-button");
		var pauseButton = _root.Q<Button>("pause-button");
		pauseButton.text = "Waiting...";
		pauseButton.clicked += () =>
		{
			isPaused = !isPaused; // toggle
			if (isPaused)
			{
				pauseButton.text = "Resume";
				Time.timeScale = 0;
			}
			else // it's running
			{
				pauseButton.text = "Pause";
				Time.timeScale = 1;
			}
		};
		
		startButton.clickable.clicked += () =>
		{
			show(inGameButtons);
			Time.timeScale = 1; // start
			Debug.Log("Start clicked!");
			hide(startMenuWrapper);
		};
		
// show:

		_root.Q<Button>("exit-button").clickable.clicked += () =>
		{
			Debug.Log("Quit");
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif

			// Button quitButton = _root.Q<Button>("quit-button");
			// quitButton.clickable = new Clickable((evt) => { };

		};


	}
}
