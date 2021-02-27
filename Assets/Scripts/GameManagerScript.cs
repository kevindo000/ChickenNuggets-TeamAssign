using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManagerScript : MonoBehaviour, IMainLayout
{
    // Start is called before the first frame update
    public Transform instanceSpawn; 
    private GameObject activeGameObject;
    private int currentObjectIndex = 0;
    private GameObject activeCurrentObject;

    public GameObject[] objectStore;
    
    private float currentRotationAngle;
    private float rotationSpeed = 50f;
        

    void Start()
    {
        Destroy(activeCurrentObject);
        activeCurrentObject = BringGameObjectToScreen(currentObjectIndex, objectStore);
    }

    // Update is called once per frame
    void Update()
    {
        RotateInstanceSpawn();
    }

    void FixedUpdate()
    {
        
    }

    void RotateInstanceSpawn()
    {   
        instanceSpawn.Rotate(new Vector3(0f, rotationSpeed* Time.deltaTime, 0f));
    }
    

    GameObject BringGameObjectToScreen(int index, GameObject[] objectStore){
        GameObject target = objectStore[index];
        // Vector3 spawnCoords = new Vector3(instanceSpawn.position.x, instanceSpawn.position.y, instanceSpawn.position.z);
         
        GameObject cloned = Instantiate(target, new Vector3(0,0,0), Quaternion.identity);
        cloned.transform.parent = instanceSpawn;
        return cloned;
    }
    

    public void nextButtonPressed()
    {
        if (currentObjectIndex == objectStore.Length - 1)
        {
            return;
        }
         
        currentObjectIndex += 1;
        Destroy(activeCurrentObject);
        activeCurrentObject = BringGameObjectToScreen(currentObjectIndex, objectStore);
        
    }

    public void previousButtonPressed()
    {
        if (currentObjectIndex == 0)
        {
            return;
        }
         
        currentObjectIndex -= 1;
        Destroy(activeCurrentObject);
        activeCurrentObject = BringGameObjectToScreen(currentObjectIndex, objectStore);
    }
}

