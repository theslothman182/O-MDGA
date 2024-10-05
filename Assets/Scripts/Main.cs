using OMDGA.Config;
using Robotlegs.Bender.Framework.API;
using Robotlegs.Bender.Framework.Impl;
using Robotlegs.Bender.Platforms.Unity.Bundles;
using Robotlegs.Bender.Platforms.Unity.Extensions.ContextViews.Impl;
using UnityEngine;

namespace OMDGA
{
    public class Main :
        MonoBehaviour
    {
        // ****** Variables ******
        IContext context;

        // ****** Methods ******
        public void Start()
        {
            context = new Context();
            context.Install<UnitySingleContextBundle>()
                .Configure(new OMDGAConfig())
                .Configure(new TransformContextView(transform));
            context.AfterInitializing(ContextReady);
            context.Initialize();
        }

        private void ContextReady()
        {
            Debug.Log("Context Ready");
        }
    }
}