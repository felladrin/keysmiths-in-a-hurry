[System.Serializable]
public class KeyPart
{
	public KeyPartType part;
	public MaterialType material;
	public KeyStyleType style;

	public KeyPart (KeyPartType part)
	{
		this.part = part;
		material =  (MaterialType)UnityEngine.Random.Range (0, 3);
		style = (KeyStyleType)UnityEngine.Random.Range (0, 3);
	}

	public KeyPart (KeyPartType part, MaterialType material)
	{
		this.part = part;
		this.material = material;
		style = Util.GetRandomEnum<KeyStyleType> ();
	}

	public KeyPart (KeyPartType part, MaterialType material, KeyStyleType style)
	{
		this.part = part;
		this.material = material;
		this.style = style;
	}

	public int Value {
		get {
			switch (material) {
			case MaterialType.Copper:
				return 20;
			case MaterialType.Silver:
				return 30;
			case MaterialType.Gold:
				return 50;
			default:
				return 0;
			}
		}
	}

	public string Description {
		get {
			switch (part) {
			case KeyPartType.Bit:
				switch (material) {
				case MaterialType.Copper:
					switch (style) {
					case KeyStyleType.Simple:
						return "a simple copper bit";
					case KeyStyleType.Cute:
						return "a cute copper bit";
					case KeyStyleType.Fancy:
						return "a stylish copper bit";
					}
					break;
				case MaterialType.Silver:
					switch (style) {
					case KeyStyleType.Simple:
						return "a simple silver bit";
					case KeyStyleType.Cute:
						return "a cute silver bit";
					case KeyStyleType.Fancy:
						return "a stylish silver bit";
					}
					break;
				case MaterialType.Gold:
					switch (style) {
					case KeyStyleType.Simple:
						return "a simple golden bit";
					case KeyStyleType.Cute:
						return "a cute golden bit";
					case KeyStyleType.Fancy:
						return "a stylish golden bit";
					}
					break;
				}
				break;
			case KeyPartType.Shaft:
				switch (material) {
				case MaterialType.Copper:
					switch (style) {
					case KeyStyleType.Simple:
						return "a copper basic shaft";
					case KeyStyleType.Cute:
						return "a copper spikey shaft";
					case KeyStyleType.Fancy:
						return "a copper thin shaft";
					}
					break;
				case MaterialType.Silver:
					switch (style) {
					case KeyStyleType.Simple:
						return "a silver basic shaft";
					case KeyStyleType.Cute:
						return "a silver spikey shaft";
					case KeyStyleType.Fancy:
						return "a silver thin shaft";
					}
					break;
				case MaterialType.Gold:
					switch (style) {
					case KeyStyleType.Simple:
						return "a golden basic shaft";
					case KeyStyleType.Cute:
						return "a golden spikey shaft";
					case KeyStyleType.Fancy:
						return "a golden thin shaft";
					}
					break;
				}
				break;
			case KeyPartType.Bow:
				switch (material) {
				case MaterialType.Copper:
					switch (style) {
					case KeyStyleType.Simple:
						return "a copper circular bow";
					case KeyStyleType.Cute:
						return "a copper cute bow";
					case KeyStyleType.Fancy:
						return "a copper fancy bow";
					}
					break;
				case MaterialType.Silver:
					switch (style) {
					case KeyStyleType.Simple:
						return "a silver circular bow";
					case KeyStyleType.Cute:
						return "a silver cute bow";
					case KeyStyleType.Fancy:
						return "a silver fancy bow";
					}
					break;
				case MaterialType.Gold:
					switch (style) {
					case KeyStyleType.Simple:
						return "a golden circular bow";
					case KeyStyleType.Cute:
						return "a golden cute bow";
					case KeyStyleType.Fancy:
						return "a golden fancy bow";
					}
					break;
				}
				break;
			}
			return "";
		}
	}
}