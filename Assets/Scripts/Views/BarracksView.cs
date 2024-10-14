using OMDGA.Events;
using OMDGA.Interfaces;
using Robotlegs.Bender.Platforms.Unity.Extensions.Mediation.Impl;
using UnityEngine;
using static OMDGA.Models.LaneCreepModel;

namespace OMDGA.Views
{
    public class BarracksView :
        EventView,
        ISpawnLaneCreepRequester
    {
        // ****** Serialized Fields ******
        [SerializeField] private LaneCreepType laneCreepType;

        // ****** Methods ******
        private void RequestLaneCreepSpawn()
        {
            dispatcher.Dispatch(new SpawnLaneCreepRequestEvent(this, laneCreepType));
        }
    }
}