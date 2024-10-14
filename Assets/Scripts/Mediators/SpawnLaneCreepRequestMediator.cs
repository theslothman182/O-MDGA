using OMDGA.Events;
using Robotlegs.Bender.Bundles.MVCS;

namespace OMDGA.Mediators
{
    public class SpawnLaneCreepRequestMediator :
        Mediator
    {
        // ****** Methods ******
        public override void Initialize()
        {
            base.Initialize();
            AddViewListener<SpawnLaneCreepRequestEvent>(SpawnLaneCreepRequestEvent.Type.SpawnCreepRequest, Dispatch);
        }
    }
}