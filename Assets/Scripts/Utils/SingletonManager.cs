using System.Collections.Generic;
using UnityEngine;

namespace OMDGA.Utils
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

        // ****** Method ******
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

            if (singletonManagerGameObject.AddComponent<K>() is not T singleton)
            {
                Debug.LogError($"SingletonManager: {key} could not be created.");
                return null;
            }

            singletons.Add(key, singleton);
            return singleton;
        }

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

        public static bool Unregister<T>()
            where T : class
        {
            string key = typeof(T).ToString();

            if (!singletons.ContainsKey(key))
            {
                Debug.LogError($"SingletonManager: {key} does not exist.");
                return false;
            }

            if (singletons[key] is not T singleton)
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