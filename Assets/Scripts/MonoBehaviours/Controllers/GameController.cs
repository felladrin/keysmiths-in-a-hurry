using UnityEngine;

public class GameController : MonoBehaviour {
	#region Singleton
	static GameController instance;

	public static GameController Instance {
		get { return instance; }
	}

	void Awake ()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
	}
	#endregion
}
