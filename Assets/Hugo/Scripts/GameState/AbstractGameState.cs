
public abstract class AbstractGameState
{
    public const int MAX_PLAYERS = 2;

    public abstract void OnPlayerConnected(int DeviceId);
    public abstract void OnPlayerDisconnected(int DeviceId);
    public abstract void Shutdown();
    public virtual void Update(float f){}

}