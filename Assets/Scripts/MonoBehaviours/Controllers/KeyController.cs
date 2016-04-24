using UnityEngine;
using UnityEngine.UI;

public class KeyController : MonoBehaviour
{
	#region Singleton

	static KeyController instance;

	public static KeyController Instance {
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

	public GameObject keyBitGameObject;
	public GameObject keyShaftGameObject;
	public GameObject keyBowGameObject;

	public Sprite emptyBitPart;
	public Sprite emptyShaftPart;
	public Sprite emptyBowPart;

	[SerializeField]
	KeyPart bitPart;
	[SerializeField]
	KeyPart shaftPart;
	[SerializeField]
	KeyPart bowPart;

	void Start ()
	{
		bitPart = new KeyPart (KeyPartType.Bit, MaterialType.Gold);
		shaftPart = new KeyPart (KeyPartType.Shaft, MaterialType.Gold);
		bowPart = new KeyPart (KeyPartType.Bow, MaterialType.Gold);
		ResetForm ();
	}

	void OnEnable ()
	{
		EventManager.OnDiscardedKey += ResetForm;
		EventManager.OnDeliveredKey += ResetForm;
	}

	void OnDisable ()
	{
		EventManager.OnDiscardedKey -= ResetForm;
		EventManager.OnDeliveredKey -= ResetForm;
	}

	void ResetForm() {
		keyBitGameObject.GetComponent<Image> ().sprite = emptyBitPart;
		keyShaftGameObject.GetComponent<Image> ().sprite = emptyShaftPart;
		keyBowGameObject.GetComponent<Image> ().sprite = emptyBowPart;
	}

	public bool IsAssembled () {
		return (keyBitGameObject.GetComponent<Image> ().sprite != emptyBitPart
		&& keyShaftGameObject.GetComponent<Image> ().sprite != emptyShaftPart
		&& keyBowGameObject.GetComponent<Image> ().sprite != emptyBowPart);
	}

	public bool IsEmpty() {
		return (keyBitGameObject.GetComponent<Image> ().sprite == emptyBitPart
			&& keyShaftGameObject.GetComponent<Image> ().sprite == emptyShaftPart
			&& keyBowGameObject.GetComponent<Image> ().sprite == emptyBowPart);
	}

	public int GetKeyValue() {
		return bitPart.Value + shaftPart.Value + bowPart.Value;
	}

	public bool IsCostumerSatisfiedWithIt() {
		var order = CurrentOrderController.Instance.CurrentCustomer.Order;
		var bitPartAsked = order.BitPart;
		var shaftPartAsked = order.ShaftPart;
		var bowPartAsked = order.BowPart;

		int score = 0;

		if (bitPart.material == bitPartAsked.material)
			score++;

		if (bitPart.style == bitPartAsked.style)
			score++;

		if (shaftPart.material == shaftPartAsked.material)
			score++;

		if (shaftPart.style == shaftPartAsked.style)
			score++;

		if (bowPart.material == bowPartAsked.material)
			score++;

		if (bowPart.style == bowPartAsked.style)
			score++;

		return (score >= 3);
	}

	public void UpdateBitPartSprite (KeyStyleType style)
	{
		bitPart.material = MaterialsController.Instance.SelectedMaterial;
		bitPart.style = style;

		switch (bitPart.material) {
		case MaterialType.Copper:
			if (MaterialsController.Instance.CopperPieces < 7)
				return;

			MaterialsController.Instance.CopperPieces -= 7;
			switch (bitPart.style) {
			case KeyStyleType.Simple:
				keyBitGameObject.GetComponent<Image> ().sprite = ShapesController.Instance.copperSimpleBit;
				break;
			case KeyStyleType.Cute:
				keyBitGameObject.GetComponent<Image> ().sprite = ShapesController.Instance.copperCuteBit;
				break;
			case KeyStyleType.Fancy:
				keyBitGameObject.GetComponent<Image> ().sprite = ShapesController.Instance.copperFancyBit;
				break;
			}
			break;
		case MaterialType.Silver:
			if (MaterialsController.Instance.SilverPieces < 7)
				return;
			
			MaterialsController.Instance.SilverPieces -= 7;
			switch (bitPart.style) {
			case KeyStyleType.Simple:
				keyBitGameObject.GetComponent<Image> ().sprite = ShapesController.Instance.silverSimpleBit;
				break;
			case KeyStyleType.Cute:
				keyBitGameObject.GetComponent<Image> ().sprite = ShapesController.Instance.silverCuteBit;
				break;
			case KeyStyleType.Fancy:
				keyBitGameObject.GetComponent<Image> ().sprite = ShapesController.Instance.silverFancyBit;
				break;
			}
			break;
		case MaterialType.Gold:
			if (MaterialsController.Instance.GoldPieces < 7)
				return;
			
			MaterialsController.Instance.GoldPieces -= 7;
			switch (bitPart.style) {
			case KeyStyleType.Simple:
				keyBitGameObject.GetComponent<Image> ().sprite = ShapesController.Instance.goldenSimpleBit;
				break;
			case KeyStyleType.Cute:
				keyBitGameObject.GetComponent<Image> ().sprite = ShapesController.Instance.goldenCuteBit;
				break;
			case KeyStyleType.Fancy:
				keyBitGameObject.GetComponent<Image> ().sprite = ShapesController.Instance.goldenFancyBit;
				break;
			}
			break;
		}
	}

	public void UpdateShaftPartSprite (KeyStyleType style)
	{
		shaftPart.material = MaterialsController.Instance.SelectedMaterial;
		shaftPart.style = style;

		switch (shaftPart.material) {
		case MaterialType.Copper:
			if (MaterialsController.Instance.CopperPieces < 17)
				return;
			
			MaterialsController.Instance.CopperPieces -= 17;
			switch (shaftPart.style) {
			case KeyStyleType.Simple:
				keyShaftGameObject.GetComponent<Image> ().sprite = ShapesController.Instance.copperSimpleShaft;
				break;
			case KeyStyleType.Cute:
				keyShaftGameObject.GetComponent<Image> ().sprite = ShapesController.Instance.copperCuteShaft;
				break;
			case KeyStyleType.Fancy:
				keyShaftGameObject.GetComponent<Image> ().sprite = ShapesController.Instance.copperFancyShaft;
				break;
			}
			break;
		case MaterialType.Silver:
			if (MaterialsController.Instance.SilverPieces < 17)
				return;

			MaterialsController.Instance.SilverPieces -= 17;
			switch (shaftPart.style) {
			case KeyStyleType.Simple:
				keyShaftGameObject.GetComponent<Image> ().sprite = ShapesController.Instance.silverSimpleShaft;
				break;
			case KeyStyleType.Cute:
				keyShaftGameObject.GetComponent<Image> ().sprite = ShapesController.Instance.silverCuteShaft;
				break;
			case KeyStyleType.Fancy:
				keyShaftGameObject.GetComponent<Image> ().sprite = ShapesController.Instance.silverFancyShaft;
				break;
			}
			break;
		case MaterialType.Gold:
			if (MaterialsController.Instance.GoldPieces < 17)
				return;
			
			MaterialsController.Instance.GoldPieces -= 17;
			switch (shaftPart.style) {
			case KeyStyleType.Simple:
				keyShaftGameObject.GetComponent<Image> ().sprite = ShapesController.Instance.goldenSimpleShaft;
				break;
			case KeyStyleType.Cute:
				keyShaftGameObject.GetComponent<Image> ().sprite = ShapesController.Instance.goldenCuteShaft;
				break;
			case KeyStyleType.Fancy:
				keyShaftGameObject.GetComponent<Image> ().sprite = ShapesController.Instance.goldenFancyShaft;
				break;
			}
			break;
		}
	}

	public void UpdateBowPartSprite (KeyStyleType style)
	{
		bowPart.material = MaterialsController.Instance.SelectedMaterial;
		bowPart.style = style;

		switch (bowPart.material) {
		case MaterialType.Copper:
			if (MaterialsController.Instance.CopperPieces < 15)
				return;

			MaterialsController.Instance.CopperPieces -= 15;
			switch (bowPart.style) {
			case KeyStyleType.Simple:
				keyBowGameObject.GetComponent<Image> ().sprite = ShapesController.Instance.copperSimpleBow;
				break;
			case KeyStyleType.Cute:
				keyBowGameObject.GetComponent<Image> ().sprite = ShapesController.Instance.copperCuteBow;
				break;
			case KeyStyleType.Fancy:
				keyBowGameObject.GetComponent<Image> ().sprite = ShapesController.Instance.copperFancyBow;
				break;
			}
			break;
		case MaterialType.Silver:
			if (MaterialsController.Instance.SilverPieces < 15)
				return;

			MaterialsController.Instance.SilverPieces -= 15;
			switch (bowPart.style) {
			case KeyStyleType.Simple:
				keyBowGameObject.GetComponent<Image> ().sprite = ShapesController.Instance.silverSimpleBow;
				break;
			case KeyStyleType.Cute:
				keyBowGameObject.GetComponent<Image> ().sprite = ShapesController.Instance.silverCuteBow;
				break;
			case KeyStyleType.Fancy:
				keyBowGameObject.GetComponent<Image> ().sprite = ShapesController.Instance.silverFancyBow;
				break;
			}
			break;
		case MaterialType.Gold:
			if (MaterialsController.Instance.GoldPieces < 15)
				return;

			MaterialsController.Instance.GoldPieces -= 15;
			switch (bowPart.style) {
			case KeyStyleType.Simple:
				keyBowGameObject.GetComponent<Image> ().sprite = ShapesController.Instance.goldenSimpleBow;
				break;
			case KeyStyleType.Cute:
				keyBowGameObject.GetComponent<Image> ().sprite = ShapesController.Instance.goldenCuteBow;
				break;
			case KeyStyleType.Fancy:
				keyBowGameObject.GetComponent<Image> ().sprite = ShapesController.Instance.goldenFancyBow;
				break;
			}
			break;
		}
	}
}
