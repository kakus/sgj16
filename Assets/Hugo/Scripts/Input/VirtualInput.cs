using UnityEngine;
using System.Collections;
using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

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

    void SetButtonDown(EHugoButton Button);
	void SetButtonUp(EHugoButton Button);
	void UpdateAxisValues(float TimeDelta);
}

public abstract class AbstractVirtualInputState
{
	protected Dictionary<EHugoButton, bool> IsKeyDown = new Dictionary<EHugoButton, bool>();
	protected Dictionary<string, float> AxisValue = new Dictionary<string, float>();

	public AbstractVirtualInputState()
	{
		foreach (EHugoButton Button in Enum.GetValues(typeof(EHugoButton)))
		{
			IsKeyDown[Button] = false;
		}

		AxisValue["Horizontal"] = 0;
		AxisValue["Vertical"] = 0;
	}

	public void SetButtonDown(EHugoButton Button)
	{
		IsKeyDown[Button] = true;
	}

	public void SetButtonUp(EHugoButton Button)
	{
		IsKeyDown[Button] = false;
	}
	
	public void UpdateAxisValues(float TimeDelta)
	{
		if (IsKeyDown[EHugoButton.Key_2])
		{
			AxisValue["Vertical"] = Mathf.Clamp(AxisValue["Vertical"] + 1.0f * TimeDelta, -1, 1);
		}
		else if (IsKeyDown[EHugoButton.Key_8])
		{
			AxisValue["Vertical"] = Mathf.Clamp(AxisValue["Vertical"] - 1.0f * TimeDelta, -1, 1);
		}
		else
		{
			AxisValue["Vertical"] *= 0.95f;
		}

		if (IsKeyDown[EHugoButton.Key_4])
		{
			AxisValue["Horizontal"] = Mathf.Clamp(AxisValue["Horizontal"] - 1.0f * TimeDelta, -1, 1);
		}
		else if (IsKeyDown[EHugoButton.Key_6])
		{
			AxisValue["Horizontal"] = Mathf.Clamp(AxisValue["Horizontal"] + 1.0f * TimeDelta, -1, 1);
		}
		else
		{
			AxisValue["Horizontal"] *= 0.95f;
		}
	}
}

public class PlayerOneVirtualInput: AbstractVirtualInputState, IVirtualInput
{
	public float GetHorizontalAxis()
	{
		return Input.GetAxis("Horizontal") + AxisValue["Horizontal"];
	}

	public float GetVerticalAxis()
	{
		return Input.GetAxis("Vertical") + AxisValue["Vertical"];
	}

	public bool IsButtonPressed(EHugoButton Button)
	{
		if (IsKeyDown[Button])
		{
			return true;
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


public class PlayerTwoVirtualInput: AbstractVirtualInputState, IVirtualInput
{
	public float GetHorizontalAxis()
	{
		return Input.GetAxis("p2Horizontal") + AxisValue["Horizontal"];
	}

	public float GetVerticalAxis()
	{
		return Input.GetAxis("p2Vertical") + AxisValue["Vertical"];
	}

	public bool IsButtonPressed(EHugoButton Button)
	{
		if (IsKeyDown[Button])
		{
			return true;
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