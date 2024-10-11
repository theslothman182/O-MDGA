// usings

namespace OMDGA.Utils
{
    [System.Serializable]
    public class DataParser<T>
    {
        // ****** Public Variables ******
        public T data;

        // ****** Methods ******
        public T GetData()
        {
            return data;
        }
    }
}