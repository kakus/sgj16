using UnityEngine;
using System.Collections;
using System;

/**
 * Buttons on old phone keyboard
 */
public enum EHugoButton
{
	Key_1,
	Key_2,
	Key_3,
	Key_4,
	Key_5,
	Key_6,
	Key_7,
	Key_8,
	Key_9,
}

public interface IVirtualInput
{
	float GetVerticalAxis();
	float GetHorizontalAxis();
	bool IsButtonPressed(EHugoButton Button);
}

public class VirtualInputConfig
{
	public static bool UseAirConsoleInput = false;
}

public class PlayerOneVirtualInput: IVirtualInput
{
	public float GetHorizontalAxis()
	{
		if (VirtualInputConfig.UseAirConsoleInput)
		{
			return 0;
		}
		else
		{
			return Input.GetAxis("Horizontal");
		}
	}

	public float GetVerticalAxis()
	{
		if (VirtualInputConfig.UseAirConsoleInput)
		{
			return 0;
		}
		else
		{
			return Input.GetAxis("Vertical");
		}
	}

	public bool IsButtonPressed(EHugoButton Button)
	{
		if (VirtualInputConfig.UseAirConsoleInput)
		{
			return false;
		}
		else
		{
			switch (Button)
			{
				case EHugoButton.Key_4: return Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
				case EHugoButton.Key_6: return Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
				case EHugoButton.Key_2: return Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
				case EHugoButton.Key_8: return Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);
				default: return false;
			}
		}
	}
}

public class PlayerTwoVirtualInput: IVirtualInput
{
	public float GetHorizontalAxis()
	{
		if (VirtualInputConfig.UseAirConsoleInput)
		{
			return 0;
		}
		else
		{
			return Input.GetAxis("p2Horizontal");
		}
	}

	public float GetVerticalAxis()
	{
		if (VirtualInputConfig.UseAirConsoleInput)
		{
			return 0;
		}
		else
		{
			return Input.GetAxis("p2Vertical");
		}
	}

	public bool IsButtonPressed(EHugoButton Button)
	{
		if (VirtualInputConfig.UseAirConsoleInput)
		{
			return false;
		}
		else
		{
			switch (Button)
			{
				case EHugoButton.Key_4: return Input.GetKeyDown(KeyCode.J);
				case EHugoButton.Key_6: return Input.GetKeyDown(KeyCode.L);
				case EHugoButton.Key_2: return Input.GetKeyDown(KeyCode.I);
				case EHugoButton.Key_8: return Input.GetKeyDown(KeyCode.K);
				default: return false;
			}
		}
	}
}