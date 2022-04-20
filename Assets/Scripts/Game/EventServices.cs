using System;

public class EventServices : MonoSingletonGeneric<EventServices>
{
    public event Action PlayerFiredBullet;
    public void InvokeOnPlayerFiredBulletEvent()
    {
        PlayerFiredBullet?.Invoke();
    }
}
