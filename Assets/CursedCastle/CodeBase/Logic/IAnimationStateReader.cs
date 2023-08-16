namespace CursedCastle.CodeBase.Logic
{
    public interface IAnimationStateReader
    {
        void EnteredState(int hashState);
        void ExitedState(int hashState);
        AnimatorState State { get; }
    }
}