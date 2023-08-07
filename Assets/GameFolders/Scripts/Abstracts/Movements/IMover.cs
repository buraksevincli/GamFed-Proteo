namespace GameFolders.Scripts.Abstracts.Movements
{
    public interface IMover
    {
        void FixedTick(float horizontal, float moveSpeed);

        float GetVelocityY();
    }
}
