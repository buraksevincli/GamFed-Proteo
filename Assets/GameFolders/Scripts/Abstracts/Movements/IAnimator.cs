namespace GameFolders.Scripts.Abstracts.Movements
{
    public interface IAnimator
    {
        void SetRunAnimation(float horizontal);
        void SetJumpAnimation();
        void SetJumpAnimationValue(float jumpValue);
        void StandDownAnimation();
        void StandUpAnimation();
        void SetBarkAnimation();
    }
}
