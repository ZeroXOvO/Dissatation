using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;


public class InputModule : BaseInputModule
{
    public Camera m_camera;
    public SteamVR_Input_Sources m_TargetSouce;
    public SteamVR_Action_Boolean m_ClickAction;

    private GameObject m_CurrentObject = null;
    private PointerEventData m_Data = null;

    protected override void Awake()
    {
        base.Awake();

        m_Data = new PointerEventData(eventSystem);
    }

    public override void Process()
    {
        // Reset Data, Set camera
        m_Data.Reset();
        m_Data.position = new Vector2(m_camera.pixelWidth / 2, m_camera.pixelHeight / 2);

        //Raycast
        eventSystem.RaycastAll(m_Data, m_RaycastResultCache);
        m_Data.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);
        m_CurrentObject = m_Data.pointerCurrentRaycast.gameObject;

        //Clear Raycast
        m_RaycastResultCache.Clear();

        //Hanlde Hover State
        HandlePointerExitAndEnter(m_Data, m_CurrentObject);

        //Deal with press 
        if (m_ClickAction.GetStateDown(m_TargetSouce))
            ProcessPress(m_Data);

        //Deal with Release
        if (m_ClickAction.GetStateUp(m_TargetSouce))
            ProcessRelease(m_Data);
    }

    public PointerEventData GetData()
    {
        return m_Data;
    }

    private void ProcessPress(PointerEventData data)
    {
        // Setting Raycast
        data.pointerPressRaycast = data.pointerCurrentRaycast;

        // Check For Object Hit, Get The Down Handler, Then Call
        GameObject newPointerPress = ExecuteEvents.ExecuteHierarchy(m_CurrentObject, data, ExecuteEvents.pointerDownHandler);

        // If No Down Handler, Try and Get Click Handler
        if (newPointerPress == null)
            newPointerPress = ExecuteEvents.GetEventHandler<IPointerClickHandler>(m_CurrentObject);

        //Set Data
        data.pressPosition = data.position;
        data.pointerPress = newPointerPress;
        data.rawPointerPress = m_CurrentObject;
    }

    private void ProcessRelease(PointerEventData data)
    {
        // Execute Pointer Up
        ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerUpHandler);

        // Checking For Click Handler
        GameObject pointerUpHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(m_CurrentObject);

        // Checking If Actual 
        if(data.pointerPress == pointerUpHandler)
        {
            ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerClickHandler);
        }

        // Clear Selected Gameobject
        eventSystem.SetSelectedGameObject(null);

        // Reset Date
        data.pressPosition = Vector2.zero;
        data.pointerPress = null;
        data.rawPointerPress = null;
    }
}
