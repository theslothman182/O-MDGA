using OMDGA.Interfaces;
using OMDGA.Views;
using OMDGA.VO;
using System.Collections.Generic;
using UnityEngine;

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
        private Dictionary<string, GameObject> prefabs = new Dictionary<string, GameObject>();

        // ****** Methods ******
        public void SetLaneCreepData(LaneCreepData[] data)
        {
            laneCreepData.Add(LaneCreepType.Melee,  data[(int)LaneCreepType.Melee]);
            laneCreepData.Add(LaneCreepType.Ranged, data[(int)LaneCreepType.Ranged]);
            laneCreepData.Add(LaneCreepType.Seige,  data[(int)LaneCreepType.Seige]);
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

        public void SpawnCreep(BarracksView barracksView, LaneCreepType laneCreepType)
        {
            if (prefabs == null ||
                prefabs.Count == 0)
            {
                Debug.LogWarning("The Prefab Dictionary in LaneCreepModel is empty");
                return;
            }

            /////////////////////////////////////////////////////
            // TODO: Replace after fleshing out barracks.
            /////////////////////////////////////////////////////
            
            GameObject creep = GameObject.Instantiate(prefabs["MinionPrefab"], barracksView.transform.position, Quaternion.Euler(barracksView.transform.rotation.eulerAngles));

            /////////////////////////////////////////////////////

            if (!creep.TryGetComponent(out LaneCreepView view))
            {
                Debug.LogError($"{creep.name} does not have a LaneCreepView component");
                GameObject.Destroy(creep);
                return;
            }

            view.SetSpawnStats(laneCreepData[laneCreepType]);
        }
    }
}