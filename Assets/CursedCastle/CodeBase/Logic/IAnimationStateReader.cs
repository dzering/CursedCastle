using UnityEditor.Animations;

namespace CursedCastle.CodeBase.Logic
{
    public interface IAnimationStateReader
    {
        void EnteredState(int hashState);
        void ExitedState(int hashState);
        AnimatorState state { get; }
    }
}