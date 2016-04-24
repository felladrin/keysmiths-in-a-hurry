using UnityEngine;

public class TimeController : MonoBehaviour {
	#region Singleton
	static TimeController instance;

	public static TimeController Instance {
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

	void Start () {
		InvokeRepeating ("DayEnded", 60 * 3, 60 * 3);
	}

	void DayEnded() {
		EventManager.InvokeDayEnded ();
	}
}
