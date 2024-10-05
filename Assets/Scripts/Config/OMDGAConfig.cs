using OMDGA.Config.Maps;
using OMDGA.Interfaces;
using OMDGA.Model;
using OMDGA.SingletonManagement;
using Robotlegs.Bender.Framework.API;
using Robotlegs.Bender.Extensions.Mediation.API;
using Robotlegs.Bender.Extensions.EventCommand.API;

namespace OMDGA.Config
{
    public class OMDGAConfig :
        IConfig
    {
        // ****** Injects ******
        [Inject] public IContext context;

        // ****** Methods ******
        public void Configure()
        {
            IMediatorMap mediatorMap = context.injector.GetInstance<IMediatorMap>();
            IEventCommandMap commandMap = context.injector.GetInstance<IEventCommandMap>();

            // ********** Models **********
            context.injector.Map<IOMDGAModel>().ToSingleton<OMDGAModel>();

            // ********** Mediators **********
            OMDGAMediatorMap mediatorMapper = new OMDGAMediatorMap(mediatorMap);
            mediatorMapper.Map();

            // ********** Commands **********
            OMDGACommandMap commandMapper = new OMDGACommandMap(commandMap);
            commandMapper.Map();

            MakeAvailableSingletons();
        }

        private void MakeAvailableSingletons()
        {
            IOMDGAModel model = context.injector.GetInstance<IOMDGAModel>();
            SingletonManager.Register<IOMDGAModel>(model);
        }
    }
}