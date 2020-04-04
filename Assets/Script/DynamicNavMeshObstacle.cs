using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DynamicNavMeshObstacle : MonoBehaviour {
    public Transform destination;
    public Vector3 targetPos;
    public NavMeshAgent nav;
    public GameObject door;
    private IEnumerator ie;
    // Start is called before the first frame update
    void Start() {
        ie = OpenDoor();
        targetPos = destination.position;
        nav = GetComponent<NavMeshAgent>();
        nav.SetDestination(targetPos);
        StartCoroutine(ie);
    }

    // Update is called once per frame
    void Update() {

    }

    IEnumerator OpenDoor() {
        yield return new WaitForSeconds(6);
        door.transform.RotateAround(new Vector3(-5.178f, 4.47f, 3.75f), Vector3.up, 90);
        Debug.Log("open");
        StopCoroutine(ie);
    }
}
