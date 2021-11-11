using System.Collections.Generic;

namespace Controller
{
    internal sealed class Controllers : IInitialize, IExecute, ILateExecute, ICleanup
        {
            private readonly List<IInitialize> _initializeControllers;
            private readonly List<IExecute> _executeControllers;
            private readonly List<ILateExecute> _lateControllers;
            private readonly List<ICleanup> _cleanupControllers;

            internal Controllers()
            {
                _initializeControllers = new List<IInitialize>(8);
                _executeControllers = new List<IExecute>(8);
                _lateControllers = new List<ILateExecute>(8);
                _cleanupControllers = new List<ICleanup>(8);
            }

            internal Controllers Add(IController controller)
            {
                if (controller is IInitialize InitializeController)
                {
                    _initializeControllers.Add(InitializeController);
                }

                if (controller is IExecute executeController)
                {
                    _executeControllers.Add(executeController);
                }

                if (controller is ILateExecute lateExecuteController)
                {
                    _lateControllers.Add(lateExecuteController);
                }

                if (controller is ICleanup cleanupController)
                {
                    _cleanupControllers.Add(cleanupController);
                }

                return this;
            }

            public void Initialize()
            {
                for (var index = 0; index < _initializeControllers.Count; ++index)
                {
                    _initializeControllers[index].Initialize();
                }
            }

            public void Execute(float deltaTime)
            {
                for (var index = 0; index < _executeControllers.Count; ++index)
                {
                    _executeControllers[index].Execute(deltaTime);
                }
            }

            public void LateExecute(float deltaTime)
            {
                for (var index = 0; index < _lateControllers.Count; ++index)
                {
                    _lateControllers[index].LateExecute(deltaTime);
                }
            }

            public void Cleanup()
            {
                for (var index = 0; index < _cleanupControllers.Count; ++index)
                {
                    _cleanupControllers[index].Cleanup();
                }
            }
        }
}
