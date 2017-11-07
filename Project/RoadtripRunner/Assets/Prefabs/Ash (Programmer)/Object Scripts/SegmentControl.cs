using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SegmentControl : MonoBehaviour
{
    public GameObject[] prefabSegments;
    private List<GameObject> segmentObjects = new List<GameObject>();
    public int segmentIndex = 0;

    private Camera mainCamera;
    private Vector3 loadPos;
    public Vector3 firstSegmentPosition;

    public string cameraTag = "MainCamera";
    public string endTag = "End";
    public float distanceBehindCam = 10;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag(cameraTag).GetComponent<Camera>();
        SetLoadPos();

        foreach (GameObject prefab in prefabSegments)
            segmentObjects.Add(Instantiate(prefab, loadPos, new Quaternion()));

        segmentObjects[segmentIndex = SetRandIndex(-1)].transform.position = firstSegmentPosition;
    }
	
	void Update()
    {
        SetLoadPos();
        Transform target = GetTransformOfChild(segmentObjects[segmentIndex]);
        Vector3 viewPos = mainCamera.WorldToViewportPoint(target.position);
        if (viewPos.x < 1)
            PlaceNextSegment(target.position);
    }

    private void SetLoadPos()
    {
        loadPos = mainCamera.transform.position;
        loadPos.z -= distanceBehindCam;
    }

    private void PlaceNextSegment(Vector3 SpawnToPos)
    {
        int lastIndex = segmentIndex;
        segmentIndex = SetRandIndex(lastIndex);

        segmentObjects[segmentIndex].transform.position = SpawnToPos;

        for (int i = 0; i < segmentObjects.Count; i++)
            if (i != lastIndex && i != segmentIndex)
                segmentObjects[i].transform.position = loadPos;
    }

    //Sets index to rand if it does not equal last index, returns last index.
    private int SetRandIndex(int NumberOtherThan)
    {
        while (true)
        {
            int RandNum = Random.Range(0, prefabSegments.Length);
            if (RandNum != NumberOtherThan)
                return RandNum;
        }
    }

    public Transform GetTransformOfChild(GameObject Segment)
    {
        for (int i = 0; i < Segment.transform.childCount; i++)
            if (Segment.transform.GetChild(i).tag == endTag)
                return Segment.transform.GetChild(i).transform;

        return null;
    }
}