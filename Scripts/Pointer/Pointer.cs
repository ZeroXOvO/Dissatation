using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Pointer : MonoBehaviour
{
    public float m_DefaultLenght = 5.0f;
    public GameObject m_Dot;
    public InputModule m_InputModule;

    private LineRenderer m_lineRenderer = null;


    private void Awake()
    {
        m_lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        UpdateLine();
    }

    private void UpdateLine()
    {
        // use default or distance
        PointerEventData data = m_InputModule.GetData();
        float targetLenght = data.pointerCurrentRaycast.distance == 0 ? m_DefaultLenght : data.pointerCurrentRaycast.distance;

        // Raycast
        RaycastHit hit = CreatRaycast(targetLenght);

        //Deafult
        Vector3 endPosition = transform.position + (transform.forward * targetLenght);

        //or based on hit
        if (hit.collider != null)
            endPosition = hit.point;

        // set postion of the dot
        m_Dot.transform.position = endPosition;

        //set linerenderer
        m_lineRenderer.SetPosition(0, transform.position);
        m_lineRenderer.SetPosition(1, endPosition);
    }

    private RaycastHit CreatRaycast(float lenght)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, lenght);

        return hit;
    }
}
