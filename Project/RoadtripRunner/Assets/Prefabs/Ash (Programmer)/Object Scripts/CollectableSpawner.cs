using UnityEngine;

//SCRIPT EFFECT: 
//Has an adjustable chance to spawn a Collectable, which must have a Trigger Collider, above the Spawner. Collectable is destroyed on Player collision

public class CollectableSpawner : MonoBehaviour
{
    private GameObject collectableObject;   
    public GameObject player;
    public GameObject currencyController;
    public GameObject collectablePrefab;                    //Set this to the collectable prefab. Make sure it has a BoxCollider with IsTrigger checked
    public int ChanceOutOf100 = 80;                         //Controls how likely it is that a collectable will spawn
    public string playerTag = "Player";                     //Set this string to whatever the Player object tag is
    public string currencyControllerTag = "CurrencyController";   //Set this string to whatever the Currency Manager object tag is


    void Start ()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
        currencyController = GameObject.FindGameObjectWithTag(currencyControllerTag);

        if (Random.Range(1, 100) > ChanceOutOf100) { return; }

        Vector3 SpawnLocation = new Vector3(0, 1, 0);
        collectableObject = Instantiate(collectablePrefab, transform.position + SpawnLocation, new Quaternion(0, 90, 90, 0));
        collectableObject.transform.parent = transform;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != playerTag) { return; }
        currencyController.GetComponent<CurrencyManagerScript>().currency++;
        Destroy(collectableObject);
    }
}
