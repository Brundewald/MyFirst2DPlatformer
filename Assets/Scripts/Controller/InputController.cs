using View;

namespace Controller
{
    public class InputController:IExecute
    {
        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;
        private readonly CharacterControlView _characterControlView;

        public InputController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical)input)
        {
            _horizontal = input.inputHorizontal;
            _vertical = input.inputVertical;
        }

        public void Execute(float deltaTime)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
        }
    }
}
