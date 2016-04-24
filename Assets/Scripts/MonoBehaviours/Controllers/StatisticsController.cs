using UnityEngine;
using UnityEngine.UI;

public class StatisticsController : MonoBehaviour
{
	#region Singleton

	static StatisticsController instance;

	public static StatisticsController Instance {
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

	[Header ("Today Statistics")]
	public GameObject TodayKeysSold;
	public GameObject TodayKeysDiscarded;
	public GameObject TodayCoinsReceived;
	public GameObject TodayCoinsSpent;
	public GameObject TodaySatisfiedCustomers;
	public GameObject TodayUnsatisfiedCustomers;

	[Header ("All-Time Statistics")]
	public GameObject CurrentDay;
	public GameObject KeysSold;
	public GameObject KeysDiscarded;
	public GameObject CoinsReceived;
	public GameObject CoinsSpent;
	public GameObject SatisfiedCustomers;
	public GameObject UnsatisfiedCustomers;

	void Start ()
	{
		ResetToday ();
		ResetAllTime ();
	}

	public void ResetToday ()
	{
		TodayKeysSold.GetComponent<Text> ().text = "0";
		TodayKeysDiscarded.GetComponent<Text> ().text = "0";
		TodayCoinsReceived.GetComponent<Text> ().text = "0";
		TodayCoinsSpent.GetComponent<Text> ().text = "0";
		TodaySatisfiedCustomers.GetComponent<Text> ().text = "0";
		TodayUnsatisfiedCustomers.GetComponent<Text> ().text = "0";
	}

	public void ResetAllTime ()
	{
		CurrentDay.GetComponent<Text> ().text = "1";
		KeysSold.GetComponent<Text> ().text = "0";
		KeysDiscarded.GetComponent<Text> ().text = "0";
		CoinsReceived.GetComponent<Text> ().text = "0";
		CoinsSpent.GetComponent<Text> ().text = "0";
		SatisfiedCustomers.GetComponent<Text> ().text = "0";
		UnsatisfiedCustomers.GetComponent<Text> ().text = "0";
	}

	void OnEnable ()
	{
		EventManager.OnDeliveredKey += OnDeliveredKey;
		EventManager.OnDiscardedKey += OnDiscardedKey;
		EventManager.OnDayEnded += OnDayEnded;
		EventManager.OnBoughtMaterial += OnBoughtMaterial;
		EventManager.OnOrderTimeEnded += OnOrderTimeEnded;
		EventManager.OnRefusedOrder += OnRefusedOrder;
		EventManager.OnClientSatisfied += OnClientSatisfied;
		EventManager.OnCoinsReceived += OnCoinsReceived;
	}

	void OnDisable ()
	{
		EventManager.OnDeliveredKey -= OnDeliveredKey;
		EventManager.OnDiscardedKey -= OnDiscardedKey;
		EventManager.OnDayEnded -= OnDayEnded;
		EventManager.OnBoughtMaterial -= OnBoughtMaterial;
		EventManager.OnOrderTimeEnded -= OnOrderTimeEnded;
		EventManager.OnRefusedOrder -= OnRefusedOrder;
		EventManager.OnClientSatisfied -= OnClientSatisfied;
		EventManager.OnCoinsReceived -= OnCoinsReceived;
	}

	void OnDeliveredKey ()
	{
		TodayKeysSold.GetComponent<Text> ().text = (int.Parse (TodayKeysSold.GetComponent<Text> ().text) + 1).ToString ();
		KeysSold.GetComponent<Text> ().text = (int.Parse (KeysSold.GetComponent<Text> ().text) + 1).ToString ();
	}

	void OnDiscardedKey ()
	{
		TodayKeysDiscarded.GetComponent<Text> ().text = (int.Parse (TodayKeysDiscarded.GetComponent<Text> ().text) + 1).ToString ();
		KeysDiscarded.GetComponent<Text> ().text = (int.Parse (KeysDiscarded.GetComponent<Text> ().text) + 1).ToString ();
	}

	void OnDayEnded ()
	{
		ResetToday ();
		CurrentDay.GetComponent<Text> ().text = (int.Parse (CurrentDay.GetComponent<Text> ().text) + 1).ToString ();
	}

	void OnBoughtMaterial (MaterialType material)
	{
		int valueSpent = 0;

		switch (material) {
		case MaterialType.Copper:
			valueSpent = 10;
			break;
		case MaterialType.Silver:
			valueSpent = 20;
			break;
		case MaterialType.Gold:
			valueSpent = 40;
			break;
		}

		TodayCoinsSpent.GetComponent<Text> ().text = (int.Parse (TodayCoinsSpent.GetComponent<Text> ().text) + valueSpent).ToString ();
		CoinsSpent.GetComponent<Text> ().text = (int.Parse (CoinsSpent.GetComponent<Text> ().text) + valueSpent).ToString ();
	}

	void OnOrderTimeEnded ()
	{
		TodayUnsatisfiedCustomers.GetComponent<Text> ().text = (int.Parse (TodayUnsatisfiedCustomers.GetComponent<Text> ().text) + 1).ToString ();
		UnsatisfiedCustomers.GetComponent<Text> ().text = (int.Parse (UnsatisfiedCustomers.GetComponent<Text> ().text) + 1).ToString ();
	}

	void OnRefusedOrder ()
	{
		TodayUnsatisfiedCustomers.GetComponent<Text> ().text = (int.Parse (TodayUnsatisfiedCustomers.GetComponent<Text> ().text) + 1).ToString ();
		UnsatisfiedCustomers.GetComponent<Text> ().text = (int.Parse (UnsatisfiedCustomers.GetComponent<Text> ().text) + 1).ToString ();
	}

	void OnClientSatisfied (bool satisfied)
	{
		if (satisfied) {
			TodaySatisfiedCustomers.GetComponent<Text> ().text = (int.Parse (TodaySatisfiedCustomers.GetComponent<Text> ().text) + 1).ToString ();
			SatisfiedCustomers.GetComponent<Text> ().text = (int.Parse (SatisfiedCustomers.GetComponent<Text> ().text) + 1).ToString ();
		} else {
			TodayUnsatisfiedCustomers.GetComponent<Text> ().text = (int.Parse (TodayUnsatisfiedCustomers.GetComponent<Text> ().text) + 1).ToString ();
			UnsatisfiedCustomers.GetComponent<Text> ().text = (int.Parse (UnsatisfiedCustomers.GetComponent<Text> ().text) + 1).ToString ();
		}
	}

	void OnCoinsReceived (int coins)
	{

		TodayCoinsReceived.GetComponent<Text> ().text = (int.Parse (TodayCoinsReceived.GetComponent<Text> ().text) + coins).ToString ();
		CoinsReceived.GetComponent<Text> ().text = (int.Parse (CoinsReceived.GetComponent<Text> ().text) + coins).ToString ();
	}
}
