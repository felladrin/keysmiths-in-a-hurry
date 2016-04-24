using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour {
	#region Singleton
	static MusicController instance;

	public static MusicController Instance {
		get { return instance; }
	}

	void Awake ()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
	}
	#endregion

	public AudioClip MenuMusic;
	public AudioClip GameplayMusic;

	AudioSource audioSource;

	void Start() {
		audioSource = GetComponent<AudioSource> ();
	}

	void Update() {
		if (SceneManager.GetActiveScene ().buildIndex == 4 && audioSource.clip != GameplayMusic) {
			audioSource.clip = GameplayMusic;
			audioSource.Play ();
		} else if (SceneManager.GetActiveScene ().buildIndex != 4 && audioSource.clip != MenuMusic) {
			audioSource.clip = MenuMusic;
			audioSource.Play ();
		}
	}
}
