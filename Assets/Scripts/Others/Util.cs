using System;

public static class Util
{
	public static bool GetRandomBool ()
	{
		return new Random ().NextDouble () >= 0.5;
	}

	public static string GetRandomStringFromArray (string[] array)
	{
		return array [new Random ().Next (0, array.Length)];
	}

	public static T GetRandomEnum<T> ()
	{
		Array array = Enum.GetValues (typeof(T));
		return (T)array.GetValue (new Random ().Next (0, array.Length));
	}

	public static void ShuffleStringArray (string[] texts)
	{
		for (int t = 0; t < texts.Length; t++) {
			string tmp = texts [t];
			int r = new Random ().Next (t, texts.Length);
			texts [t] = texts [r];
			texts [r] = tmp;
		}
	}
}

