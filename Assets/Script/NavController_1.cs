using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavController_1 : MonoBehaviour {
    public Vector3 targetPos;
    public NavMeshAgent nav;
    public GameObject prefab;
    private Vector3 screenPos;
    public Transform canvas;
    public GameObject point;
    private IEnumerator ie;
    // Start is called before the first frame update
    void Start() {
        point = Instantiate(Resources.Load<GameObject>("Point"));
        nav = this.GetComponent<NavMeshAgent>();
        point.SetActive(false);
        point.transform.parent = canvas;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(1)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//获取射线,由相机指向鼠标的位置
            RaycastHit hit = new RaycastHit();
            //射线碰撞检测 碰撞点为射线与Ground层物体的接触点
            Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Ground"));
            targetPos = hit.point;//hit.point为碰撞点坐标
            //将碰撞点的世界坐标转化到屏幕坐标
            screenPos = Camera.main.WorldToScreenPoint(targetPos);
            ie = Point(screenPos);
            StartCoroutine(ie);
            nav.SetDestination(targetPos);//寻路终点为碰撞点坐标
        }
    }

    IEnumerator Point(Vector3 pos) {
        point.transform.position = pos;
        point.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        point.SetActive(false);
        StopCoroutine(ie);
    }
}
