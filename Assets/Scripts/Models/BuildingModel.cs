using OMDGA.Interfaces;
using OMDGA.VO;
using System.Collections.Generic;
using UnityEngine;

namespace OMDGA.Models
{
    public class BuildingModel :
        IBuildingModel
    {
        // ****** Enumerations ******
        public enum BuildingType
        {
            MeleeBarracks = 0,
            RangedBarrack = 1
        }

        // ****** Private Variables ******
        private Dictionary<BuildingType, BuildingData> laneCreepData = new Dictionary<BuildingType, BuildingData>();
        private Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>();

        // ****** Methods ******
        public void SetBuildingData(BuildingData[] data)
        {
            laneCreepData.Add(BuildingType.MeleeBarracks, data[(int)BuildingType.MeleeBarracks]);
            laneCreepData.Add(BuildingType.RangedBarrack, data[(int)BuildingType.RangedBarrack]);
        }

        public void LoadReferences(GameObject[] references)
        {
            foreach (GameObject go in references)
            {
                if (!prefabs.ContainsKey(go.name))
                {
                    prefabs.Add(go.name, go);
                    continue;
                }

                Debug.LogError($"There is already a prefab with the name {go.name}");
            }
        }
    }
}