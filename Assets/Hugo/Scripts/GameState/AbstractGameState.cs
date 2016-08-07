using Newtonsoft.Json.Linq;
using NDream.AirConsole;

public abstract class AbstractGameState
{
    public const int MAX_PLAYERS = 2;

    public abstract void OnPlayerConnected(int DeviceId);
    public abstract void OnPlayerDisconnected(int DeviceId);
    public abstract void Shutdown();

    public virtual void OnMessage(int FromDeviceId, JToken Message)
    {
        int PlayerId = AirConsole.instance.ConvertDeviceIdToPlayerNumber(FromDeviceId);
        if (PlayerId == 0 || PlayerId == 1)
        {
            ProcessInput(PlayerId, Message);
        }
    }

    public virtual void Update(float DeltaTime)
    {
        for (int PlayerId = 0; PlayerId < MAX_PLAYERS; ++PlayerId)
        {
            HugoInput.GetInputForPlayer(PlayerId).UpdateAxisValues(DeltaTime);
        }
    }

    protected void ProcessInput(int PlayerId, JToken Message)
    {
        if (Message["KeyDownEvent"] != null)
        {
            HugoInput.GetInputForPlayer(PlayerId).SetButtonDown((EHugoButton)(int)Message["KeyDownEvent"]["Key"]);
        }
        if (Message["KeyUpEvent"] != null)
        {
            HugoInput.GetInputForPlayer(PlayerId).SetButtonUp((EHugoButton)(int)Message["KeyUpEvent"]["Key"]);
        }
    }
}