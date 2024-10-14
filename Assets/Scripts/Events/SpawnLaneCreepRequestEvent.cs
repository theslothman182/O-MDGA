using OMDGA.Views;
using static OMDGA.Models.LaneCreepModel;

namespace OMDGA.Events
{
    public class SpawnLaneCreepRequestEvent :
        Robotlegs.Bender.Extensions.EventManagement.Impl.Event
    {
        // ****** Enumerations ******
        public enum Type
        {
            SpawnCreepRequest
        }

        // ****** Properties ******
        public BarracksView BarracksView { get; private set; }
        public LaneCreepType LaneCreepType { get; private set; }

        // ****** Constructors ****** 
        public SpawnLaneCreepRequestEvent(BarracksView barracksView, LaneCreepType laneCreepType) :
            base(Type.SpawnCreepRequest)
        {
            BarracksView = barracksView;
            LaneCreepType = laneCreepType;
        }
    }
}