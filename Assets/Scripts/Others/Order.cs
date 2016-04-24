public class Order
{
	readonly KeyPart bitPart;
	readonly KeyPart shaftPart;
	readonly KeyPart bowPart;
	string description;

	static readonly string[] customerGreeting = {
		"Hi.",
		"Hello.",
		"Hey!",
		"Hail!",
		"Hola!",
		"Nice to see you again.",
		"I'm glad you're open today!",
		"Bonjour!",
		"Hallo."
	};
	static readonly string[] customerIntroduction = {
		"I need your services to create a key with",
		"I wish to make a special order: a key with",
		"I want a custom key with",
		"I wonder if you could create a gift for me: a key with",
		"You might be able to create for me a key with",
		"I bet you can do me a key with",
		"No time to talk. Just do me a key with"
	};
	static readonly string[] customerChallenge = {
		"So, will you do it?",
		"Can you make it?",
		"Will you help me?",
		"Can you help me?",
		"I'm counting on you.",
		"I know you can do it.",
		"I need it urgently!",
		"Are you capable of making it?"
	};

	public KeyPart BitPart {
		get {
			return bitPart;
		}
	}

	public KeyPart ShaftPart {
		get {
			return shaftPart;
		}
	}

	public KeyPart BowPart {
		get {
			return bowPart;
		}
	}

	public Order ()
	{
		bitPart = new KeyPart (KeyPartType.Bit);
		shaftPart = new KeyPart (KeyPartType.Shaft);
		bowPart = new KeyPart (KeyPartType.Bow);
		description = generateDescription ();
	}

	public Order (KeyPart bitPart, KeyPart shaftPart, KeyPart bowPart)
	{
		this.bitPart = bitPart;
		this.shaftPart = shaftPart;
		this.bowPart = bowPart;
		description = generateDescription ();
	}

	public int Value {
		get {
			return bitPart.Value + shaftPart.Value + bowPart.Value;
		}
	}

	public string Description {
		get {
			return description;
		}
	}

	string generateDescription ()
	{
		string[] partsDescriptions = { bitPart.Description, shaftPart.Description, bowPart.Description };
		Util.ShuffleStringArray (partsDescriptions);
		string[] stringsToJoin = {
			Util.GetRandomStringFromArray (customerGreeting),
			Util.GetRandomStringFromArray (customerIntroduction),
			partsDescriptions [0] + ",",
			partsDescriptions [1] + " and",
			partsDescriptions [2] + ".",
			Util.GetRandomStringFromArray (customerChallenge)
		};
		return string.Join (" ", stringsToJoin);
	}
}