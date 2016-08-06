public class HugoInput 
{
	private static IVirtualInput PlayerOneInput = new PlayerOneVirtualInput();
	private static IVirtualInput PlayerTwoInput = new PlayerTwoVirtualInput();

	public static IVirtualInput GetInputForPlayer(int PlayerNum)
	{
		switch (PlayerNum)
		{
			case 0: return PlayerOneInput;
			case 1: return PlayerTwoInput;
			default: throw new System.Exception("We only support up to two players.");
		}
	}
}
