using System.Collections.Generic;
using UnityEngine;

//SCRIPT EFFECT: 
//Spawns in Platforms in start function, moves them between the back of the camera and the location of the End segment of the platform.
//When platforms move depends on the SpawnFront and SpawnBack floats, but by default should be at the edges of the camera.

public class SegmentControl : MonoBehaviour
{
    public GameObject[] prefabSegments;

    private List<GameObject> segmentObjects = new List<GameObject>();
    private Dictionary<int, GameObject> unseenObjects = new Dictionary<int, GameObject>();
    private Dictionary<int, GameObject> seenObjects = new Dictionary<int, GameObject>();
    private Dictionary<int, bool> canSpawnPlatform = new Dictionary<int, bool>();

    public Vector3 firstSegmentPosition;
    public int segmentIndex = 0;
    public float spawnFront = 1.1f;                     //Adjust SpawnFront to change how far ahead of the camera Platforms will appear. Default is 1, right cam edge
    public float spawnBack = 0f;                        //Adjust SpawnBack to change how far behind the camera platforms must be to move to loadpos. Default is 0, left cam edge

    private Camera mainCamera;
    private Vector3 loadPos;

    public float distanceBehindCam = 10;
    public string cameraTag = "MainCamera";             //Set this string to whatever the Camera object tag is
    public string endTag = "End";                       //Set this string to whatever the End object tag is

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag(cameraTag).GetComponent<Camera>();
        SetLoadPos();

        foreach (GameObject prefab in prefabSegments)
        {
            segmentObjects.Add(Instantiate(prefab, loadPos, new Quaternion()));
            unseenObjects.Add(segmentObjects.Count -1, segmentObjects[segmentObjects.Count - 1]);
        }

        PlaceNextSegment(firstSegmentPosition);
    }
	
	void Update()
    {
        float CamZPos = mainCamera.transform.position.z;
        for (int i = 0; i < segmentObjects.Count; i++)
        {
            Vector3 viewPos = mainCamera.WorldToViewportPoint(segmentObjects[i].transform.position);

            if (viewPos.x > spawnBack && viewPos.x < spawnFront && viewPos.z > CamZPos && seenObjects.ContainsKey(i) == false)
            {
                seenObjects.Add(i, segmentObjects[i]);
                unseenObjects.Remove(i);
                canSpawnPlatform.Add(i, true);
            }


            Transform target = GetTransformOfChild(segmentObjects[i]);
            viewPos = mainCamera.WorldToViewportPoint(target.position);

            if (viewPos.x < spawnBack && unseenObjects.ContainsKey(i) == false)
            {
                unseenObjects.Add(i, segmentObjects[i]);
                seenObjects.Remove(i);
                canSpawnPlatform.Remove(i);
            }

            if (viewPos.x > spawnBack && viewPos.x < spawnFront && viewPos.z > CamZPos && canSpawnPlatform[i] == true)
            {
                PlaceNextSegment(target.position);
                canSpawnPlatform[i] = false;
            }
        }
    }


    private void SetLoadPos()
    {
        loadPos = mainCamera.transform.position;
        loadPos.z -= distanceBehindCam;
    }

    private Transform GetTransformOfChild(GameObject Segment)
    {
        foreach (Transform child in Segment.transform)
            if (child.tag == endTag)
                return child.transform;

        return null;
    }

    private void PlaceNextSegment(Vector3 SpawnToPos)
    {
        SetLoadPos();
        foreach (var Entry in unseenObjects)
            Entry.Value.transform.position = loadPos;

        int RandNum = Random.Range(0, unseenObjects.Count);
        int Index = 0;

        foreach (var Entry in unseenObjects)
            if (Index++ == RandNum)
                segmentIndex = Entry.Key;

        segmentObjects[segmentIndex].transform.position = SpawnToPos;
    }
}