using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CloudGenerate : MonoBehaviour
{
    [Header("Instanties")]
    [SerializeField] private Transform pointMax;
    [SerializeField] private Transform pointMin;
    [SerializeField] private Transform pointEnd;
    [SerializeField] private Transform prefCloud;
    [SerializeField] private Transform transfListCloudFront;
    [SerializeField] private Transform transfListCloudBack;

    [Header("Variables")]
    [SerializeField] private float maxTimeForSpawn;
    [SerializeField] private float minTimeForSpawn;
    [SerializeField] private int layerCloud1;
    [SerializeField] private int layerCloud2;

    private float maxY;
    private float minY;
    private float xStart;
    private float xEnd;
    private float paddindX = 2;
    private float timeForStay;
    private List<GameObject> listCloudFront;
    private List<GameObject> listCloudBack;

    void Start(){
        if(transfListCloudFront == null) transfListCloudFront = GameObject.Find("ListCloudFront").GetComponent<Transform>();
        if(transfListCloudBack == null) transfListCloudBack = GameObject.Find("ListCloudBack").GetComponent<Transform>();

        maxY = pointMax.position.y;
        minY = pointMin.position.y;
        xStart = pointMax.position.x;
        xEnd = pointEnd.position.x;

        listCloudFront = getListOfChildren(transfListCloudFront);
        listCloudBack = getListOfChildren(transfListCloudBack);

        initCloudInRandomPositions(listCloudFront, layerCloud1);
        initCloudInRandomPositions(listCloudBack, layerCloud2);

        StartCoroutine(loopingSpawnCloud(layerCloud1, transfListCloudFront, listCloudFront));
        StartCoroutine(loopingSpawnCloud(layerCloud2, transfListCloudBack, listCloudBack));
    }

    private IEnumerator loopingSpawnCloud(int layer, Transform transfListCloud, List<GameObject> listCloud){
        timeForStay = Random.Range(minTimeForSpawn, maxTimeForSpawn);
        yield return new WaitForSeconds(timeForStay);
        addCloud(layer, transfListCloud, listCloud);
        StartCoroutine(loopingSpawnCloud(layer, transfListCloud, listCloud));
    }

    private void addCloud(int layer, Transform transfListCloud, List<GameObject> listCloud){

        Vector2 pos = new Vector2(xStart, Random.Range(minY, maxY));
        GameObject obj = null;

        for(int i = 0; i < listCloud.Count; i++){ // Check if have cloud unable
            if(listCloud[i].activeSelf == false){
                obj = listCloud[i];
                obj.transform.position = pos;
                obj.SetActive(true);
                break;
            }
        }
        if(obj == null) obj = Instantiate(prefCloud, pos, prefCloud.transform.rotation, transfListCloud).gameObject;

        listCloud.Add(obj.gameObject);
        obj.GetComponent<CloudInstantiate>().PassAttributes(xEnd, layer);
    }

    
    private List<GameObject> getListOfChildren(Transform transList){
        List<GameObject> list = new List<GameObject>();
        int count = transList.childCount;
        for(int i = 0; i < count; i++){
            list.Add(transList.GetChild(i).gameObject);
        }
        return list;
    }

    private void initCloudInRandomPositions(List<GameObject> listCloud, int layer){
        for(int i = 0; i < listCloud.Count; i++){
            listCloud[i].transform.position = new Vector3(Random.Range(xEnd + paddindX, xStart - paddindX), Random.Range(minY, maxY), 0);
            listCloud[i].SetActive(true);
            listCloud[i].GetComponent<CloudInstantiate>().PassAttributes(xEnd, layer);
        }
    }
    
}
