using OMDGA.Interfaces;
using UnityEngine;

namespace OMDGA.Config.Maps
{
    public class Mapper<T> :
        IMapper
    {
        // ****** Public Variables ******
        public T map;

        // ****** Constructors ******
        public Mapper(T mapper)
        {
            map = mapper;
        }

        // ****** Methods ******
        public virtual void Map()
        {
            if (map == null)
            {
                Debug.LogError("Mapper is null");
                return;
            }
        }
    }
}