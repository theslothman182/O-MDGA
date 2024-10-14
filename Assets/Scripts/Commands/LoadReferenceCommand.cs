using OMDGA.Interfaces;
using Robotlegs.Bender.Extensions.CommandCenter.API;
using System;
using UnityEngine;

namespace OMDGA.Commands
{
    public class LoadReferenceCommand :
        ICommand
    {
        // ****** Injections ******
        [Inject] public IBuildingModel buildingModel;
        [Inject] public ILaneCreepModel laneCreepModel;

        // ****** Methods ******
        public void Execute()
        {
            LoadReferences("Buildings", buildingModel.LoadReferences);
            LoadReferences("LaneCreeps", laneCreepModel.LoadReferences);
        }

        private bool LoadReference(string filePath, out GameObject reference)
        {
            reference = Resources.Load<GameObject>(filePath);
            return reference != null;
        }

        private void LoadReference(string filePath, Action<GameObject> callback)
        {
            if (!LoadReference(filePath, out GameObject reference))
            {
                Debug.LogError($"Could not find GameObject at: Assets/Resources/{filePath}");
                return;
            }

            callback(reference);
        }

        private bool LoadReferences(string folderPath, out GameObject[] references)
        {
            references = Resources.LoadAll<GameObject>(folderPath);
            return references != null && references.Length != 0;
        }

        private void LoadReferences(string folderPath, Action<GameObject[]> callback)
        {
            if (!LoadReferences(folderPath, out GameObject[] references))
            {
                Debug.LogError($"Could not find GameObjects in: Assets/Resources/{folderPath}");
                return;
            }

            callback(references);
        }
    }
}