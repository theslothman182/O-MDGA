using OMDGA.VO;

namespace OMDGA.Interfaces
{
    public interface ILaneCreepModel
    {
        public void SetLaneCreepData(LaneCreepData[] laneCreepData);
    }
}