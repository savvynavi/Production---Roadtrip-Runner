using System.Collections.Generic;
using UnityEngine;

public class SegmentControl : MonoBehaviour
{
    public GameObject prefabSegment1;
    public GameObject prefabSegment2;
    public GameObject prefabSegment3;

    public GameObject[] prefabSegments;
    private List<GameObject> segmentObjects = new List<GameObject>();
    public int segmentIndex = 0;

    private Camera mainCamera;
    private Vector3 loadPos;
    public Vector3 firstSegmentPosition;

    public string cameraTag = "MainCamera";

    void Start ()
    {
        mainCamera = GameObject.FindGameObjectWithTag(cameraTag).GetComponent<Camera>();
        SetLoadPos();

        foreach (GameObject prefab in prefabSegments)
            segmentObjects.Add(Instantiate(prefab, loadPos, new Quaternion()));

        segmentIndex = Random.Range(0, prefabSegments.Length);
        segmentObjects[segmentIndex].transform.position = firstSegmentPosition;
    }
	
	void Update ()
    {
        SetLoadPos();
        Transform target = segmentObjects[segmentIndex].gameObject.transform.GetChild(1);
        Vector3 viewPos = mainCamera.WorldToViewportPoint(target.position);
        if (viewPos.x < 1)
            PlaceNextSegment(target.position);
    }

    private void SetLoadPos()
    {
        loadPos = mainCamera.transform.position;
        loadPos.z -= 10;
    }

    private void PlaceNextSegment(Vector3 SpawnToPos)
    {
        int lastIndex = segmentIndex;
        segmentIndex = Random.Range(0, prefabSegments.Length);

        if (segmentIndex == lastIndex)
            while (segmentIndex == lastIndex)
                segmentIndex = Random.Range(0, prefabSegments.Length);

        segmentObjects[segmentIndex].transform.position = SpawnToPos;
    }
}
