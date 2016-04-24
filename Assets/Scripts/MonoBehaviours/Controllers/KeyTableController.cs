using UnityEngine;
using System.Collections;

public class KeyTableController : MonoBehaviour {
	#region Singleton
	static KeyTableController instance;

	public static KeyTableController Instance {
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

	public void OnClickDiscardButton()
	{
		if (!KeyController.Instance.IsEmpty ()) {
			EventManager.InvokeDiscardedKey ();
		}
	}

	public void OnClickDeliverButton()
	{
		if (KeyController.Instance.IsAssembled ()) {
			EventManager.InvokeClientSatisfied (KeyController.Instance.IsCostumerSatisfiedWithIt ());
			EventManager.InvokeCoinsReceived (CurrentOrderController.Instance.CurrentCustomer.Order.Value);
			EventManager.InvokeDeliveredKey ();
		}
	}
}
