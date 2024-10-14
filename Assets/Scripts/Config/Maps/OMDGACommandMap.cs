using OMDGA.Commands;
using OMDGA.Events;
using Robotlegs.Bender.Extensions.EventCommand.API;

namespace OMDGA.Config.Maps
{
    public class OMDGACommandMap :
        Mapper<IEventCommandMap>
    {
        // ****** Constructors ******
        public OMDGACommandMap(IEventCommandMap mapper) :
            base(mapper)
        {
            // Empty
        }

        // ****** Methods ******
        public override void Map()
        {
            base.Map();

            // ********** Commands **********

            // Spawn Lane Creeps Request
            map.Map(SpawnLaneCreepRequestEvent.Type.SpawnCreepRequest).ToCommand<SpawnLaneCreepCommand>();
        }
    }
}