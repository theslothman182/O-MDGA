using OMDGA.Interfaces;
using OMDGA.VO;
using System.Collections.Generic;

namespace OMDGA.Models
{
    public class LaneCreepModel :
        ILaneCreepModel
    {
        // ****** Enumerations ******
        public enum LaneCreepType
        {
            Melee = 0,
            Ranged = 1,
            Seige = 2
        }

        // ****** Private Variables ******
        private Dictionary<LaneCreepType, LaneCreepData> laneCreepData = new Dictionary<LaneCreepType, LaneCreepData>();

        // ****** Methods ******
        public void SetLaneCreepData(LaneCreepData[] laneCreepData)
        {
            this.laneCreepData.Add(LaneCreepType.Melee,  laneCreepData[(int)LaneCreepType.Melee]);
            this.laneCreepData.Add(LaneCreepType.Ranged, laneCreepData[(int)LaneCreepType.Ranged]);
            this.laneCreepData.Add(LaneCreepType.Seige,  laneCreepData[(int)LaneCreepType.Seige]);
        }
    }
}