using UnityEngine;

public class Customer
{
	Order order;
	readonly string name;
	readonly int patience;

	public Customer ()
	{
		name = RandomName.Generate(2);
		patience = Random.Range (30, 60);
		order = new Order ();
	}

	public Order Order {
		get {
			return order;
		}
	}

	public string Name {
		get {
			return name;
		}
	}

	public int Patience {
		get {
			return patience;
		}
	}
}
