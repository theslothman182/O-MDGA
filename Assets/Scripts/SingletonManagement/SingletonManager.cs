using System.Collections.Generic;
using UnityEngine;

namespace OMDGA.SingletonManagement
{
    public static class SingletonManager
    {
        // ****** Static Variables ******
        private static GameObject singletonManagerGameObject;
        private static Dictionary<string, object> singletons = new Dictionary<string, object>();

        // ****** Constructors ******
        static SingletonManager()
        {
            singletonManagerGameObject = new GameObject("SingletonManager");
            Object.DontDestroyOnLoad(singletonManagerGameObject);
        }

        // ****** Methods ******
        // Creates a new singleton instance of the given type. If a singleton of the give type already exists, it will return null.
        public static T CreateSingletonMonoBehaviour<T, K>()
            where T : class
            where K : MonoBehaviour
        {
            string key = typeof(T).ToString();

            if (singletons.ContainsKey(key))
            {
                Debug.LogError($"SingletonManager: {key} already exists.");
                return null;
            }

            T singleton = singletonManagerGameObject.AddComponent<K>() as T;

            if (singleton == null)
            {
                Debug.LogError($"SingletonManager: {key} could not be created.");
                return null;
            }

            singletons.Add(key, singleton);
            return singleton;
        }

        // Register a singleton with the SingletonManager. Management of the singleton is up to the caller. Recoomend either using CreateSingleton or setting the singleton to not be destroyed on load.
        // Returns the object as a T is succeful, null otherwise.
        public static T Register<T>(object obj)
            where T : class
        {
            string key = typeof (T).ToString();

            if (singletons.ContainsKey(key))
            {
                Debug.LogError($"SingletonManager: {key} already exists.");
                return null;
            }

            singletons.Add(key, obj);
            return obj as T;
        }

        // Returns a singleton of the given type. If the singleton does not exist, it will return null.
        public static T GetInstance<T>()
            where T : class
        {
            string key = typeof(T).ToString();

            if (!singletons.ContainsKey(key))
            {
                Debug.LogError($"SingletonManager: {key} does not exist.");
                return null;
            }

            return singletons[key] as T;
        }

        // Unregister a singleton from the SingletonManager. Management of the singleton is up to the caller.
        // If it is a MonoBehaviour, it is destroyed.
        public static bool Unregister<T>()
            where T : class
        {
            string key = typeof(T).ToString();

            if (!singletons.ContainsKey(key))
            {
                Debug.LogError($"SingletonManager: {key} does not exist.");
                return false;
            }

            T singleton = singletons[key] as T;

            if (singleton == null)
            {
                Debug.LogError($"SingletonManager: {key} is not a valid singleton.");
                return false;
            }

            if (singleton.GetType() == typeof(MonoBehaviour))
            {
                MonoBehaviour monoBehaviour = singleton as MonoBehaviour;
                Object.Destroy(monoBehaviour);
            }

            singletons.Remove(key);
            return true;
        }
    }
}