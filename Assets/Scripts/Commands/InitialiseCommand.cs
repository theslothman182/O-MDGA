using OMDGA.Interfaces;
using OMDGA.Utils;
using OMDGA.VO;
using Robotlegs.Bender.Extensions.CommandCenter.API;
using Robotlegs.Bender.Extensions.DirectCommand.API;
using Robotlegs.Bender.Framework.API;
using System;
using System.IO;
using UnityEngine;

namespace OMDGA.Commands
{
    public class InitialiseCommand :
        ICommand
    {
        // ****** Injections ******
        [Inject] public IContext context;
        [Inject] public IBuildingModel buildingModel;
        [Inject] public ILaneCreepModel laneCreepModel;

        // ****** Methods ******
        public void Execute()
        {
            context.Detain(this);

            LoadData<BuildingData>(buildingModel.SetBuildingData);
            LoadData<LaneCreepData>(laneCreepModel.SetLaneCreepData);

            EndInitialisation();
        }

        private void LoadData<T>(Action<T[]> callback) where T : class
        {
            string dataPath = Application.streamingAssetsPath + $"/configs/{typeof(T).Name}.json";

            if (!File.Exists(dataPath))
            {
                Debug.LogError($"Failed To Find {typeof(T).Name} at: {dataPath}");
                return;
            }

            string data = File.ReadAllText(dataPath);

            T[] dataArray = JsonUtility.FromJson<DataArrayParser<T>>(data).data;

            if (dataArray == null ||
                dataArray.Length == 0)
            {
                Debug.LogError($"Failed To Load {typeof(T).Name}");
                return;
            }

            callback(dataArray);
        }

        private void EndInitialisation()
        {
            context.injector.GetInstance<IDirectCommandMap>().Map<LoadReferenceCommand>().Execute();
        }
    }
}