using UnityEngine;
using UnityEngine.UI;

public class ShapesController : MonoBehaviour
{
	#region Singleton

	static ShapesController instance;

	public static ShapesController Instance {
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

	[Header ("Bit Shapes")]
	public GameObject simpleBitGameObject;
	public GameObject cuteBitGameObject;
	public GameObject fancyBitGameObject;

	[Header ("Shaft Shapes")]
	public GameObject simpleShaftGameObject;
	public GameObject cuteShaftGameObject;
	public GameObject fancyShaftGameObject;

	[Header ("Bow Shapes")]
	public GameObject simpleBowGameObject;
	public GameObject cuteBowGameObject;
	public GameObject fancyBowGameObject;

	[Header ("Gold Material Images")]
	public Sprite goldenSimpleBit;
	public Sprite goldenCuteBit;
	public Sprite goldenFancyBit;
	public Sprite goldenSimpleShaft;
	public Sprite goldenCuteShaft;
	public Sprite goldenFancyShaft;
	public Sprite goldenSimpleBow;
	public Sprite goldenCuteBow;
	public Sprite goldenFancyBow;

	[Header ("Silver Material Images")]
	public Sprite silverSimpleBit;
	public Sprite silverCuteBit;
	public Sprite silverFancyBit;
	public Sprite silverSimpleShaft;
	public Sprite silverCuteShaft;
	public Sprite silverFancyShaft;
	public Sprite silverSimpleBow;
	public Sprite silverCuteBow;
	public Sprite silverFancyBow;

	[Header ("Copper Material Images")]
	public Sprite copperSimpleBit;
	public Sprite copperCuteBit;
	public Sprite copperFancyBit;
	public Sprite copperSimpleShaft;
	public Sprite copperCuteShaft;
	public Sprite copperFancyShaft;
	public Sprite copperSimpleBow;
	public Sprite copperCuteBow;
	public Sprite copperFancyBow;

	void OnEnable ()
	{
		EventManager.OnChangedShapesMaterial += OnChangedShapesMaterial;
	}

	void OnDisable ()
	{
		EventManager.OnChangedShapesMaterial -= OnChangedShapesMaterial;
	}

	public void OnChangedShapesMaterial (MaterialType material)
	{
		switch (material) {
		case MaterialType.Copper:
			simpleBitGameObject.GetComponent<Image> ().sprite = copperSimpleBit;
			cuteBitGameObject.GetComponent<Image> ().sprite = copperCuteBit;
			fancyBitGameObject.GetComponent<Image> ().sprite = copperFancyBit;
			simpleShaftGameObject.GetComponent<Image> ().sprite = copperSimpleShaft;
			cuteShaftGameObject.GetComponent<Image> ().sprite = copperCuteShaft;
			fancyShaftGameObject.GetComponent<Image> ().sprite = copperFancyShaft;
			simpleBowGameObject.GetComponent<Image> ().sprite = copperSimpleBow;
			cuteBowGameObject.GetComponent<Image> ().sprite = copperCuteBow;
			fancyBowGameObject.GetComponent<Image> ().sprite = copperFancyBow;
			break;
		case MaterialType.Silver:
			simpleBitGameObject.GetComponent<Image> ().sprite = silverSimpleBit;
			cuteBitGameObject.GetComponent<Image> ().sprite = silverCuteBit;
			fancyBitGameObject.GetComponent<Image> ().sprite = silverFancyBit;
			simpleShaftGameObject.GetComponent<Image> ().sprite = silverSimpleShaft;
			cuteShaftGameObject.GetComponent<Image> ().sprite = silverCuteShaft;
			fancyShaftGameObject.GetComponent<Image> ().sprite = silverFancyShaft;
			simpleBowGameObject.GetComponent<Image> ().sprite = silverSimpleBow;
			cuteBowGameObject.GetComponent<Image> ().sprite = silverCuteBow;
			fancyBowGameObject.GetComponent<Image> ().sprite = silverFancyBow;
			break;
		case MaterialType.Gold:
			simpleBitGameObject.GetComponent<Image> ().sprite = goldenSimpleBit;
			cuteBitGameObject.GetComponent<Image> ().sprite = goldenCuteBit;
			fancyBitGameObject.GetComponent<Image> ().sprite = goldenFancyBit;
			simpleShaftGameObject.GetComponent<Image> ().sprite = goldenSimpleShaft;
			cuteShaftGameObject.GetComponent<Image> ().sprite = goldenCuteShaft;
			fancyShaftGameObject.GetComponent<Image> ().sprite = goldenFancyShaft;
			simpleBowGameObject.GetComponent<Image> ().sprite = goldenSimpleBow;
			cuteBowGameObject.GetComponent<Image> ().sprite = goldenCuteBow;
			fancyBowGameObject.GetComponent<Image> ().sprite = goldenFancyBow;
			break;
		}
	}

	public void OnClickShapeButton (int buttonId)
	{
		GetComponent<AudioSource> ().Play ();

		switch (buttonId) {
		case 11:
			KeyController.Instance.UpdateBitPartSprite (KeyStyleType.Simple);
			break;
		case 12:
			KeyController.Instance.UpdateBitPartSprite (KeyStyleType.Cute);
			break;
		case 13:
			KeyController.Instance.UpdateBitPartSprite (KeyStyleType.Fancy);
			break;
		case 21:
			KeyController.Instance.UpdateShaftPartSprite (KeyStyleType.Simple);
			break;
		case 22:
			KeyController.Instance.UpdateShaftPartSprite (KeyStyleType.Cute);
			break;
		case 23:
			KeyController.Instance.UpdateShaftPartSprite (KeyStyleType.Fancy);
			break;
		case 31:
			KeyController.Instance.UpdateBowPartSprite (KeyStyleType.Simple);
			break;
		case 32:
			KeyController.Instance.UpdateBowPartSprite (KeyStyleType.Cute);
			break;
		case 33:
			KeyController.Instance.UpdateBowPartSprite (KeyStyleType.Fancy);
			break;
		}
	}
}
