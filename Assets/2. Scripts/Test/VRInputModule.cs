using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;


public class VRInputModule : BaseInputModule
{
    public Camera _camera;
    public SteamVR_Input_Sources _targetSource;
    public SteamVR_Action_Boolean _clickAction;

    private GameObject _currentObject = null;
    private PointerEventData _data = null;

    protected override void Awake()
    {
        base.Awake();

        _data = new PointerEventData(eventSystem);
    }

    public override void Process()
    {
        // Reset data, set camera
        _data.Reset();
        _data.position = new Vector2(_camera.pixelWidth / 2, _camera.pixelHeight / 2);

        // Raycast
        eventSystem.RaycastAll(_data, m_RaycastResultCache);
        _data.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);
        _currentObject = _data.pointerCurrentRaycast.gameObject;

        // Clear
        m_RaycastResultCache.Clear();

        // Hover
        HandlePointerExitAndEnter(_data, _currentObject);

        // Press
        if (_clickAction.GetStateDown(_targetSource))
            ProcessPress(_data);

        // Release
        if (_clickAction.GetStateUp(_targetSource))
            ProcessRelease(_data);
       
    }

    PointerEventData GetData()
    {
        return _data;
    }

    private void ProcessPress(PointerEventData data)
    {

    }

    private void ProcessRelease(PointerEventData data)
    {

    }





}
