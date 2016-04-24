public delegate void GamePausedEventHandler (bool paused);
public delegate void CustomerLeftQueueEventHandler ();
public delegate void DeliveredKeyEventHandler ();
public delegate void DiscardedKeyEventHandler ();
public delegate void DayEndedEventHandler ();
public delegate void BoughtMaterialEventHandler (MaterialType material);
public delegate void ChangedShapesMaterialEventHandler (MaterialType material);
public delegate void OrderTimeEndedEventHandler ();
public delegate void RefusedOrderEventHandler ();
public delegate void ChangedKeyPartEventHandler (KeyPartType part);
public delegate void ChangedKeyStyleEventHandler (KeyStyleType style);
public delegate void ClientSatisfiedEventHandler (bool satisfied);
public delegate void CoinsReceivedEventHandler (int coins);

public static class EventManager
{
	public static event GamePausedEventHandler OnGamePaused;
	public static event CustomerLeftQueueEventHandler OnCustomerLeftQueue;
	public static event DeliveredKeyEventHandler OnDeliveredKey;
	public static event DiscardedKeyEventHandler OnDiscardedKey;
	public static event DayEndedEventHandler OnDayEnded;
	public static event BoughtMaterialEventHandler OnBoughtMaterial;
	public static event ChangedShapesMaterialEventHandler OnChangedShapesMaterial;
	public static event OrderTimeEndedEventHandler OnOrderTimeEnded;
	public static event RefusedOrderEventHandler OnRefusedOrder;
	public static event ChangedKeyPartEventHandler OnChangedKeyPart;
	public static event ChangedKeyStyleEventHandler OnChangedKeyStyle;
	public static event ClientSatisfiedEventHandler OnClientSatisfied;
	public static event CoinsReceivedEventHandler OnCoinsReceived;

	public static void InvokeGamePaused (bool paused)
	{
		if (OnGamePaused != null)
			OnGamePaused (paused);
	}

	public static void InvokeCustomerLeftQueue ()
	{
		if (OnCustomerLeftQueue != null)
			OnCustomerLeftQueue ();
	}

	public static void InvokeDeliveredKey ()
	{
		if (OnDeliveredKey != null)
			OnDeliveredKey ();
	}

	public static void InvokeDiscardedKey ()
	{
		if (OnDiscardedKey != null)
			OnDiscardedKey ();
	}

	public static void InvokeDayEnded ()
	{
		if (OnDayEnded != null)
			OnDayEnded ();
	}

	public static void InvokeBoughtMaterial (MaterialType material)
	{
		if (OnBoughtMaterial != null)
			OnBoughtMaterial (material);
	}

	public static void InvokeChangedShapesMaterial (MaterialType material)
	{
		if (OnChangedShapesMaterial != null)
			OnChangedShapesMaterial (material);
	}

	public static void InvokeOrderTimeEnded ()
	{
		if (OnOrderTimeEnded != null)
			OnOrderTimeEnded ();
	}

	public static void InvokeRefusedOrder ()
	{
		if (OnRefusedOrder != null)
			OnRefusedOrder ();
	}

	public static void InvokeChangedKeyPart (KeyPartType part)
	{
		if (OnChangedKeyPart != null)
			OnChangedKeyPart (part);
	}

	public static void InvokeChangedKeyStyle (KeyStyleType style)
	{
		if (OnChangedKeyStyle != null)
			OnChangedKeyStyle (style);
	}

	public static void InvokeClientSatisfied (bool satisfied)
	{
		if (OnClientSatisfied != null)
			OnClientSatisfied (satisfied);
	}

	public static void InvokeCoinsReceived (int coins)
	{
		if (OnCoinsReceived != null)
			OnCoinsReceived (coins);
	}
}