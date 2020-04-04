using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OffMeshLinkController : MonoBehaviour {
    public Transform destination;
    public Vector3 targetPos;
    public NavMeshAgent nav;
    // Start is called before the first frame update
    void Start() {
        targetPos = destination.position;
        nav = GetComponent<NavMeshAgent>();
        nav.SetDestination(targetPos);
    }

    // Update is called once per frame
    void Update() {

    }
}
