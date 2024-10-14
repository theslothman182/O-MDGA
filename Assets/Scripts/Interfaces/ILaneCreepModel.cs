using OMDGA.Views;
using OMDGA.VO;
using UnityEngine;
using static OMDGA.Models.LaneCreepModel;

namespace OMDGA.Interfaces
{
    public interface ILaneCreepModel
    {
        public void SetLaneCreepData(LaneCreepData[] data);
        public void LoadReferences(GameObject[] references);
        public void SpawnCreep(BarracksView barracksView, LaneCreepType laneCreepType);
    }
}