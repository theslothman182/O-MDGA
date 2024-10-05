using Robotlegs.Bender.Extensions.Mediation.API;

namespace OMDGA.Config.Maps
{
    public class OMDGAMediatorMap :
    Mapper<IMediatorMap>
    {
        // ****** Constructors ******
        public OMDGAMediatorMap(IMediatorMap mapper) :
            base(mapper)
        {
            // Empty
        }

        // ****** Methods ******
        public override void Map()
        {
            base.Map();

            // ********** Mediators **********
            //map.Map(dispatcher).ToMediator<Mediator>();
            //map.Map(listener).ToMediator<Mediator>();
        }
    }
}