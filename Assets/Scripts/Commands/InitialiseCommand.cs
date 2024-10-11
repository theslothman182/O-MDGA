using OMDGA.Interfaces;
using OMDGA.Utils;
using OMDGA.VO;
using Robotlegs.Bender.Extensions.CommandCenter.API;
using Robotlegs.Bender.Framework.API;
using System.IO;
using UnityEngine;

namespace OMDGA.Commands
{
    public class InitialiseCommand :
        ICommand
    {
        // ****** Injects ******
        [Inject] public IContext context;
        [Inject] public ILaneCreepModel laneCreepModel;

        // ****** Methods ******
        public void Execute()
        {
            context.Detain(this);

            LoadLaneCreepData();
        }

        private void LoadLaneCreepData()
        {
            string dataPath = Application.streamingAssetsPath + "/configs/LaneCreepData.json";

            if (!File.Exists(dataPath))
            {
                Debug.LogError($"Failed To Find LaneCreepData at: {dataPath}");
                return;
            }

            string data = File.ReadAllText(dataPath);

            LaneCreepData[] laneCreepData = JsonUtility.FromJson<DataArrayParser<LaneCreepData>>(data).data;

            if (laneCreepData == null ||
                laneCreepData.Length == 0)
            {
                Debug.LogError($"Failed To Load LaneCreepData");
                return;
            }

            laneCreepModel.SetLaneCreepData(laneCreepData);
        }
    }
}