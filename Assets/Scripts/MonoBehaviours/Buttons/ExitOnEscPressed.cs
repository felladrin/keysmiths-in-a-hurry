using UnityEngine;
using UnityEngine.SceneManagement;

namespace HeadOfState
{
	public class ExitOnEscPressed : MonoBehaviour
	{
		void Update ()
		{
			if (Input.GetKey (KeyCode.Escape))
				SceneManager.LoadScene(0);
		}
	}
}