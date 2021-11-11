namespace Controller
{
    public interface ILateExecute: IController
    {
        void LateExecute(float deltaTime);
    }
}
