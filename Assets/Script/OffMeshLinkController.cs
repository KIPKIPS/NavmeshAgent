using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OffMeshLinkController : MonoBehaviour {
    public Transform destination;
    public Vector3 targetPos;
    public NavMeshAgent nav;

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
        yield return new WaitForSeconds(8);
        Debug.Log("open");
        //若AI在开门之前就抵达门,则它的寻路目标需要重新设置
        nav.areaMask = nav.areaMask|1<<4;//将寻路的第四层(Door)添加到可以寻路的层里面
        //重新制定寻路的目标
        nav.SetDestination(targetPos);
        StopCoroutine(ie);
    }
}
