namespace Controller
{
    public class InputInitialization:IInitialize
    {
        private readonly IUserInputProxy _inputHorizontal;
        private readonly IUserInputProxy _inputVertical;

        public InputInitialization()
        {
            _inputHorizontal = new UserInputHorizontal();
            _inputVertical = new UserInputVertical();
        }

        public (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) GetInput()
        {
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical)
                result = (_inputHorizontal, _inputVertical);
            return result;
        }

        public void Initialize()
        {
        }
    }
}
