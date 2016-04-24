using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneIdOnButtonClick : MonoBehaviour
{
	public void OnClick(int SceneIdOnBuildSettings)
	{
		SceneManager.LoadScene(SceneIdOnBuildSettings);
	}
}