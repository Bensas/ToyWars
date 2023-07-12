using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ZoomOut : MonoBehaviour
{
    [SerializeField] private float _zoomOutSpeed;
    
    private CinemachineVirtualCamera _camera;
    private float _initialFieldOfView;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
        _initialFieldOfView = _camera.m_Lens.FieldOfView;
        
        StartCoroutine(ZoomOutCamera());
    }
    
    IEnumerator ZoomOutCamera()
    {
        _camera.m_Lens.FieldOfView = 1;
        while (_camera.m_Lens.FieldOfView < _initialFieldOfView)
        {
            _camera.m_Lens.FieldOfView += 1f;
            yield return new WaitForSeconds(_zoomOutSpeed/1000f);
        }

        _camera.m_Lens.FieldOfView = _initialFieldOfView;
    }


}
