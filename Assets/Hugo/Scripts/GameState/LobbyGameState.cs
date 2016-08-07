using System;
using Newtonsoft.Json.Linq;
using NDream.AirConsole;

public class LobbyGameState : AbstractGameState
{
    private int ConnectedPlayers = 0;

    public override void Update(float TimeDelta)
    {
        if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.Space))
        {
            ConnectedPlayers += 1;
            GameStateManager.GetInstance().SwitchGameState(EGameState.PLAY_STATE);
        }
    }

    public override void OnPlayerConnected(int PlayerId)
    {
        ConnectedPlayers += 1;

        if (ConnectedPlayers == 1)
        {
            GameStateManager.GetInstance().SwitchGameState(EGameState.PLAY_STATE);
        }
    }

    public override void OnPlayerDisconnected(int PlayerId)
    {
        ConnectedPlayers -= 1;
        UnityEngine.Debug.Assert(ConnectedPlayers >= 0);
    }

    public override void Shutdown()
    {
        if (ConnectedPlayers != 1)
        {
            throw new System.Exception("Not enough players to playe the game!");
        }
        AirConsole.instance.SetActivePlayers(1);
    }

}