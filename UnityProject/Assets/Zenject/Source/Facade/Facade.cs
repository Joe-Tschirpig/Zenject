using System.Collections.Generic;

namespace Zenject
{
    [System.Diagnostics.DebuggerStepThrough]
    public class Facade : IFacade
    {
        [Inject(InjectSources.Local)]
        TickableManager _tickableManager = null;

        [Inject(InjectSources.Local)]
        InitializableManager _initializableManager = null;

        [Inject(InjectSources.Local)]
        DisposableManager _disposablesManager = null;

        // For cases where you have objects that aren't referenced anywhere but still want them to be
        // created on startup
        [InjectOptional(InjectSources.Local)]
        public List<object> _initialObjects = null;

        public TickableManager TickableManager
        {
            get
            {
                return _tickableManager;
            }
        }

        public InitializableManager InitializableManager
        {
            get
            {
                return _initializableManager;
            }
        }

        public DisposableManager DisposableManager
        {
            get
            {
                return _disposablesManager;
            }
        }

        public virtual void Initialize()
        {
            _initializableManager.Initialize();
        }

        public virtual void Dispose()
        {
            _disposablesManager.Dispose();
        }

        public virtual void Tick()
        {
            _tickableManager.Update();
        }

        public virtual void LateTick()
        {
            _tickableManager.LateUpdate();
        }

        public virtual void FixedTick()
        {
            _tickableManager.FixedUpdate();
        }
    }
}
