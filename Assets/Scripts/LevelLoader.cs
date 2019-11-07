
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour
{
	void Awake()
	{
		DontDestroyOnLoad(gameObject);
		SceneManager.sceneLoaded += OnLoad;
	}
	void OnLoad(Scene scene, LoadSceneMode mode)
	{
		if (scene.buildIndex == 1)
		{
			StartCoroutine(IELoad());
		}
	}

	IEnumerator IELoad()
	{
		AsyncOperation aso = SceneManager.LoadSceneAsync(2);
		//loading screen stuff
		yield break;
	}
}