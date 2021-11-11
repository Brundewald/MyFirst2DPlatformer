using System;

namespace Controller
{
    public interface IUserInputProxy
    {
        event Action<float> OnAxisChange;
        void GetAxis();
    }
}
