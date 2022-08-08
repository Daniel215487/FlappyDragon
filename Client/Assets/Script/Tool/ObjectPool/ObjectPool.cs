using System.Collections.Generic;
using UnityEngine;

namespace LinChTools{
    // 泛型物件池
    public class ObjectPool<T> where T: MonoBehaviour
    {
        private Queue<T> _pool; 
        private Transform _trans;               //生成父物件
        private GameObject Perfab;              //生成物
        private static ObjectPool<T> _instance; //物件池單例
        public static ObjectPool<T> Ins{
            get {
                if(_instance == null){
                    _instance = new ObjectPool<T>();
                }
                return _instance;
            }
        }
        /// <summary>
        /// 物件池初始化，(生成物、父物件、數量)
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="tran"></param>
        /// <param name="size"></param>
        public void InitPool(GameObject obj, Transform tran, int size){
            Perfab = obj;
            _trans = tran;
            _pool=new Queue<T>();
            for(int i=0;i<size;i++){
                Spawn();
            }
        }
        /// <summary>
        /// 生成物件並隱藏
        /// </summary>
        private void Spawn(){
            T _tmp = GameObject.Instantiate(Perfab).GetComponent<T>();
            _pool.Enqueue(_tmp);
            _tmp.transform.parent = _trans;
            _tmp.gameObject.SetActive(false);
        }
        /// <summary>
        /// 池裡取物件
        /// </summary>
        /// <returns></returns>
        public T GetItem(){
            if(_pool.Count<=0){
                Spawn();
            }
            T _t=_pool.Dequeue();
            _t.gameObject.SetActive(true);
            return _t;
        }
        /// <summary>
        /// 回收物件
        /// </summary>
        /// <param name="_t"></param>
        public void RecycleItem(T _t){
            if(_pool.Count<=0){
                return;
            }
            _pool.Enqueue(_t);
            _t.gameObject.SetActive(false);
        }
    }
}

