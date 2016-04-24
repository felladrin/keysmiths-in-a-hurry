using UnityEngine;
using UnityEngine.UI;

public class MaterialsController : MonoBehaviour
{
	#region Singleton

	static MaterialsController instance;

	public static MaterialsController Instance {
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

	[SerializeField]
	int coins = 250;

	[SerializeField]
	int goldPieces = 50;

	[SerializeField]
	int silverPieces = 50;

	[SerializeField]
	int copperPieces = 50;

	public GameObject CoinsGameObject;
	public GameObject GoldPiecesGameObject;
	public GameObject SilverPiecesGameObject;
	public GameObject CopperPiecesGameObject;

	public MaterialType SelectedMaterial;

	void Start ()
	{
		SelectedMaterial = MaterialType.Gold;
		UpdateCoinsText ();
		UpdateGoldPiecesText ();
		UpdateSilverPiecesText ();
		UpdateCopperPiecesText ();
	}

	public int Coins {
		get {
			return coins;
		}
		set {
			coins = Mathf.Clamp (value, 0, 99999999);
			UpdateCoinsText ();
		}
	}

	public int GoldPieces {
		get {
			return goldPieces;
		}
		set {
			goldPieces = Mathf.Clamp (value, 0, 99999999);
			UpdateGoldPiecesText ();
		}
	}

	public int SilverPieces {
		get {
			return silverPieces;
		}
		set {
			silverPieces = Mathf.Clamp (value, 0, 99999999);
			UpdateSilverPiecesText ();
		}
	}

	public int CopperPieces {
		get {
			return copperPieces;
		}
		set {
			copperPieces = Mathf.Clamp (value, 0, 99999999);
			UpdateCopperPiecesText ();
		}
	}

	void UpdateCoinsText ()
	{
		CoinsGameObject.GetComponent<Text> ().text = coins + "c";
	}

	void UpdateGoldPiecesText ()
	{
		GoldPiecesGameObject.GetComponent<Text> ().text = goldPieces.ToString ();
	}

	void UpdateSilverPiecesText ()
	{
		SilverPiecesGameObject.GetComponent<Text> ().text = silverPieces.ToString ();
	}

	void UpdateCopperPiecesText ()
	{
		CopperPiecesGameObject.GetComponent<Text> ().text = copperPieces.ToString ();
	}

	public void OnClickBuyMaterial (int materialType)
	{
		var material = (MaterialType)materialType;

		switch (material) {
		case MaterialType.Copper:
			if (Coins >= 10) {
				Coins -= 10;
				CopperPieces += 10;
				EventManager.InvokeBoughtMaterial (material);
			}
			break;
		case MaterialType.Silver:
			if (Coins >= 20) {
				Coins -= 20;
				SilverPieces += 10;
				EventManager.InvokeBoughtMaterial (material);
			}
			break;
		case MaterialType.Gold:
			if (Coins >= 40) {
				Coins -= 40;
				GoldPieces += 10;
				EventManager.InvokeBoughtMaterial (material);
			}
			break;
		}
	}

	public void OnClickMaterialButton(int materialType) {
		var material = (MaterialType)materialType;
		SelectedMaterial = material;
		EventManager.InvokeChangedShapesMaterial (material);
	}

	void OnEnable ()
	{
		EventManager.OnCoinsReceived += OnCoinsReceived;
	}

	void OnDisable ()
	{
		EventManager.OnCoinsReceived -= OnCoinsReceived;
	}

	void OnCoinsReceived (int coinsReceived)
	{
		Coins += coinsReceived;
	}
}
