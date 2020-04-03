using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavController_1 : MonoBehaviour {
    public Vector3 targetPos;
    public NavMeshAgent nav;
    // Start is called before the first frame update
    void Start() {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update() {
        //获取射线,由相机指向鼠标的位置
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        //射线碰撞检测 碰撞点为射线与Ground层物体的接触点
        Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Ground"));
        //hit.point为碰撞点坐标
        targetPos = hit.point;
        //寻路终点为碰撞点坐标
        nav.SetDestination(targetPos);
    }
}
