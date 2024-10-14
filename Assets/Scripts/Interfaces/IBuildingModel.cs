using OMDGA.VO;
using UnityEngine;

namespace OMDGA.Interfaces
{
    public interface IBuildingModel
    {
        public void SetBuildingData(BuildingData[] data);
        public void LoadReferences(GameObject[] references);
    }
}