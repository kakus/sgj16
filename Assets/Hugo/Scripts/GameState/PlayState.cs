using System;
using Newtonsoft.Json.Linq;
using NDream.AirConsole;

public class PlayState : AbstractGameState
{
    public override void OnMessage(int FromDeviceId, JToken Message)
    {
        base.OnMessage(FromDeviceId, Message);
    }

    public override void Update(float DeltaTime)
    {
        base.Update(DeltaTime);
    }

    public override void OnPlayerConnected(int DeviceId)
    {
        AirConsole.instance.Message(DeviceId, new { error = "too_many_players" });
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