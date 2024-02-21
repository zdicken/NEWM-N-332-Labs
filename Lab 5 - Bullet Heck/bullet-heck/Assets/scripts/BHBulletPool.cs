using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BHBulletPool : MonoBehaviour {
    public static BHBulletPool instance;

    public GameObject prefab;
    public ObjectPool<GameObject> pool

    void Awake() {
        if (instance != null && instance != this) Destroy(this);
        else instance = this;
    }

    GameObject CreatedPooledObject() {
        GameObject newObject = GameObject.Instantiate(prefab);
        return newObject;
    }

    void OnGetFromPool(GameObject pooledObject) {
        pooledObject.SetActive(true);
    }

    void OnReturnToPool(GameObject pooledObject) {
        pooledObject.SetActive(false);
    }

    void OnDestroyPooledObject() {
        GameObject.Destroy(pooledObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        pool = new ObjectPool<GameObject>(CreatePooledObject, OnGetFromPool, OnReturnFromPool, OnDestroyPooledObject, true, 20, 100);

    }
}
