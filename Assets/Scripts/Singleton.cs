using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    throw new System.NullReferenceException("Sahnede " + typeof(T).Name + " türden nesne bulunmuyor.");
                }
            }
            return instance;
        }

    }
    protected virtual void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (Instance == null) instance = this as T;
        else if (instance != this) Destroy(gameObject);
    }
    protected virtual void OnDestroy()
    {
        instance = null;
    }

}
