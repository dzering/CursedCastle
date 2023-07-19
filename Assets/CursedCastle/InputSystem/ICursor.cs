using CursedCastle.CodeBase.Infrastructure;

namespace CursedCastle.InputSystem
{
    public interface ICursor : IService
    {
        void OnUIFocus(bool hasUI);
    }
}