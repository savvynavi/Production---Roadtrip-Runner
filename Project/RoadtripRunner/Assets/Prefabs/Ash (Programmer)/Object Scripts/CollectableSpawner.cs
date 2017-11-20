using UnityEngine;

//SCRIPT EFFECT: 
//Has an adjustable chance to spawn a Collectable, which must have a Trigger Collider, above the Spawner. Collectable is destroyed on Player collision

public class CollectableSpawner : MonoBehaviour
{
    public string playerTag = "Player";                             //Set this string to whatever the Player object tag is
    public string upgradeControllerTag = "UpgradeController";       //Set this string to whatever the UpgradeManager object tag is

    private GameObject upgradeController;

    private GameObject collectableObject;   
    public GameObject collectablePrefab;                            //Set this to the collectable prefab. Make sure it has a BoxCollider with IsTrigger checked
    public int ChanceOutOf100 = 80;                                 //Controls how likely it is that a collectable will spawn


    void Start()
    {
        upgradeController = GameObject.FindGameObjectWithTag(upgradeControllerTag);

        if (Random.Range(1, 100) > ChanceOutOf100) { return; }

        Vector3 SpawnLocation = new Vector3(0, 1, 0);
        collectableObject = Instantiate(collectablePrefab, transform.position + SpawnLocation, new Quaternion(0, 90, 90, 0));
        collectableObject.transform.parent = transform;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != playerTag) { return; }

        upgradeController.GetComponent<UpgradeControl>().currency++;
        Destroy(collectableObject);
    }
}
