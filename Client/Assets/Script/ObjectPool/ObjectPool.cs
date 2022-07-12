using System.Collections.Generic;
using UnityEngine;

namespace LinChTools{
    public class ObjectPool<T> where T: MonoBehaviour
    {
        private Queue<T> _pool; 
        private Transform _trans;
        private GameObject Perfab;
        private static ObjectPool<T> _instance;
        public static ObjectPool<T> Ins{
            get {
                if(_instance == null){
                    _instance = new ObjectPool<T>();
                }
                return _instance;
            }
        }
        public void InitPool(GameObject obj, Transform tran, int size){
            Perfab = obj;
            _trans = tran;
            _pool=new Queue<T>();
            for(int i=0;i<size;i++){
                Spawn();
            }
        }
        private void Spawn(){
            T _tmp = GameObject.Instantiate(Perfab).GetComponent<T>();
            _pool.Enqueue(_tmp);
            _tmp.transform.parent = _trans;
            _tmp.gameObject.SetActive(false);
        }
        public T GetItem(){
            if(_pool.Count<=0){
                Spawn();
            }
            T _t=_pool.Dequeue();
            _t.gameObject.SetActive(true);
            return _t;
        }
        public void RecycleItem(T _t){
            if(_pool.Count<+0){
                return;
            }
            _pool.Enqueue(_t);
            _t.gameObject.SetActive(false);
        }
    }
}

