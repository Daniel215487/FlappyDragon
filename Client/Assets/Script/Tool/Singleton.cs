using UnityEngine;

namespace LinChTools{
    //單例製作 繼承Mono
    public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour { 
    protected static T _ins;
    public static T Ins {
            get { 
                if (_ins == null) {
                    _ins = (T)FindObjectOfType(typeof(T));
                    if (_ins == null) {
                        GameObject obj = new GameObject(typeof(T).ToString());
                        _ins = obj.AddComponent<T>();
                    }
                }
                return _ins; 
            }
        }
    }
}
