using UnityEngine;
using UnityEngine.UI;

public class CurrentOrderController : MonoBehaviour
{
	#region Singleton

	static CurrentOrderController instance;

	public static CurrentOrderController Instance {
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

	void Start ()
	{
		InvokeRepeating ("DecreseTimeLeft", 1, 1);
	}

	Customer currentCustomer;
	public GameObject DescriptionGameObject;
	public GameObject TimeLeftGameObject;

	int timeLeft = 45;

	public void OnClickRefuseOderButton ()
	{
		EventManager.InvokeRefusedOrder ();
	}

	public int TimeLeft {
		get {
			return timeLeft;
		}
		set {
			timeLeft = value;
			TimeLeftGameObject.GetComponent<Text> ().text = timeLeft + " seconds";
		}
	}

	void UpdateDescription ()
	{
		DescriptionGameObject.GetComponent<Text> ().text = currentCustomer.Name + ": \"" + currentCustomer.Order.Description + "\"";
		TimeLeftGameObject.GetComponent<Text> ().text = timeLeft + " seconds";
	}

	void DecreseTimeLeft ()
	{
		if (timeLeft > 0) {
			TimeLeftGameObject.GetComponent<Text> ().text = --timeLeft + " seconds";
		} else {
			EventManager.InvokeOrderTimeEnded ();
		}
	}

	public Customer CurrentCustomer {
		get {
			return currentCustomer;
		}
		set {
			currentCustomer = value;
			UpdateDescription ();
			TimeLeft = currentCustomer.Patience;
		}
	}
}
