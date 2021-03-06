﻿using UnityEngine;
using System.Collections;

public enum EGameState
{
    LOBBY_STATE,
    PLAY_STATE
}

public class GameStateManager : MonoBehaviour
{
	public EGameState StartState;
	public event System.Action<EGameState> OnGameStateChange;

	private static GameStateManager Instance;
	private AbstractGameState CurrentState;

    void Awake()
    {
		if (Instance == null)
		{
			Instance = this;
			SwitchGameState(StartState);
		}
		else
		{
			throw new System.Exception("You can't spawn more than one GameStateManager");
		}
    }

    // Update is called once per frame
    void Update()
    {
		if (CurrentState != null)
		{
			CurrentState.Update(Time.deltaTime);
		}
    }

    public void SwitchGameState(EGameState NewState)
	{
		if (CurrentState != null)
		{
			CurrentState.Shutdown();
		}

		switch (NewState)
		{
			case EGameState.LOBBY_STATE:
				CurrentState = new LobbyGameState();
				break;

			case EGameState.PLAY_STATE:
				CurrentState = new PlayState();
				break;
		}

		if (OnGameStateChange != null) OnGameStateChange.Invoke(NewState);
    }

	public AbstractGameState GetGameState()
	{
		return CurrentState;
	}

	public static GameStateManager GetInstance()
	{
		return Instance;
	}
}
