using System;


public class PlayState : AbstractGameState
{
    public override void OnPlayerConnected(int DeviceId)
    {
        // AirConsole.instance.Message(DeviceId, new { Error = "TooManyPlayers" });
    }

    public override void OnPlayerDisconnected(int DeviceId)
    {
        // todo
        // what to do with life
        throw new NotImplementedException();
    }

    public override void Shutdown()
    {
        // todo ?
    }
}