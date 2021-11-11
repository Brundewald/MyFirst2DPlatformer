using System;
using UnityEngine;

namespace Controller
{
    public class UserInputVertical:IUserInputProxy
    {
        public event Action<float> OnAxisChange = delegate(float f) {  };

        public void GetAxis()
        {
            OnAxisChange.Invoke(Input.GetAxis(AxisManager.Vertical));
        }
    }
}
