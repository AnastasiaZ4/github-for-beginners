using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectingCell : MonoBehaviour
{
    public static SelectingCell instance;
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Color");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                foreach (Transform child in transform)
                {
                    Debug.Log("hit.transform.name " + hit.transform.name);
                    Debug.Log("child.transform.name " + child.transform.name);
                    if (hit.transform.name == child.transform.name)
                    {

                        if (GameManager.instance.selectedCell != child.gameObject)
                        {
                            //
                            //GameObject target = GameObject.Find(GameManager.instance.selectedTarget.transform.name);
                            Debug.Log("Color red");
                            ClearSelection();
                            //GameManager.instance.selectedTarget.GetComponentInChildren<Renderer>().material.color = Color.blue;
                            child.GetComponent<Renderer>().material.color = Color.red * 0.3f;
                            GameManager.instance.selectedCell = child.gameObject;
                        }
                        else
                        {
                            Debug.Log("Clear");
                            ClearSelection();
                        }
                    }
                }
            }
        }
    }

    public void ClearSelection()
    {
        if (GameManager.instance.selectedCell)
        {
            Debug.Log("Clear 2");
            GameManager.instance.selectedCell.GetComponent<Renderer>().material.color = Color.black* 0.2f;
            GameManager.instance.selectedCell = null;
        }
    }
}
