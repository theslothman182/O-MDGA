using OMDGA.Events;
using OMDGA.Interfaces;
using Robotlegs.Bender.Extensions.CommandCenter.API;

namespace OMDGA.Commands
{
    public class SpawnLaneCreepCommand :
        ICommand
    {
        // ****** Injections ******
        [Inject] public ILaneCreepModel model;
        [Inject] public SpawnLaneCreepRequestEvent evt;

        // ****** Methods ******
        public void Execute()
        {
            model.SpawnCreep(evt.BarracksView, evt.LaneCreepType);
        }
    }
}