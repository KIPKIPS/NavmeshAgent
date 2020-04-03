using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavController : MonoBehaviour {
    public Transform destination;
    public Vector3 targetPos;
    public NavMeshAgent nav;

    public Vector3 oriPos;
    public bool tar = false;
    void Awake() {
        oriPos = transform.position;
    }
    // Start is called before the first frame update
    void Start() {
        targetPos = destination.position;
        nav = GetComponent<NavMeshAgent>();
        nav.SetDestination(targetPos);
    }

    // Update is called once per frame
    void Update() {
        if (tar) {
            nav.SetDestination(oriPos);
        }
        else {
            nav.SetDestination(targetPos);
        }
        if (Vector3.Distance(transform.position,targetPos)<=0.1f) {
            tar = true;
        }
        if (Vector3.Distance(transform.position, oriPos) <= 0.1f) {
            tar = false;
        }
    }
}
