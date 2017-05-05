using ProjectManager.Interfaces;

namespace ProjectManager
{
    public class EngineProvider
    {
        private IEngine engine;

        public EngineProvider(IEngine engine)
        {
            this.engine = engine;
        }

        public void StartEngine()
        {
            this.engine.Start();
        }
    }
}
