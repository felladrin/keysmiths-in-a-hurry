using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CustomerQueueController : MonoBehaviour
{
	#region Singleton

	static CustomerQueueController instance;

	public static CustomerQueueController Instance {
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

	public List<GameObject> customersGameObjects;

	public List<Customer> customers;

	public Sprite highPatience;
	public Sprite midPatience;
	public Sprite lowPatience;

	void Start ()
	{
		customers = new List<Customer> { new Customer (), new Customer (), new Customer (), new Customer (), new Customer () };
		CallNextCustomer ();
	}

	public void CallNextCustomer ()
	{
		CurrentOrderController.Instance.CurrentCustomer = customers [0];

		customersGameObjects [0].GetComponent<Text> ().text = customers [1].Name;
		customersGameObjects [0].GetComponentInChildren<Image> ().sprite = getPatienceSprite(customers [1].Patience);
		customersGameObjects [1].GetComponent<Text> ().text = customers [2].Name;
		customersGameObjects [1].GetComponentInChildren<Image> ().sprite = getPatienceSprite(customers [2].Patience);
		customersGameObjects [2].GetComponent<Text> ().text = customers [3].Name;
		customersGameObjects [2].GetComponentInChildren<Image> ().sprite = getPatienceSprite(customers [3].Patience);
		customersGameObjects [3].GetComponent<Text> ().text = customers [4].Name;
		customersGameObjects [3].GetComponentInChildren<Image> ().sprite = getPatienceSprite(customers [4].Patience);

		customers.RemoveAt (0);
		var newCustomer = new Customer ();
		customers.Add (newCustomer);

		customersGameObjects [4].GetComponent<Text> ().text = customers [4].Name;
		customersGameObjects [4].GetComponentInChildren<Image> ().sprite = getPatienceSprite(customers [4].Patience);
	}

	Sprite getPatienceSprite(int patience) {
		if (patience < 40)
			return lowPatience;
		else if (patience < 50)
			return midPatience;
		else
			return highPatience;
	}

	void OnEnable ()
	{
		EventManager.OnOrderTimeEnded += CallNextCustomer;
		EventManager.OnDeliveredKey += CallNextCustomer;
	}

	void OnDisable ()
	{
		EventManager.OnOrderTimeEnded -= CallNextCustomer;
		EventManager.OnDeliveredKey -= CallNextCustomer;
	}
}
