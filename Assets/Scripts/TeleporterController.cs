using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterController : MonoBehaviour 
{
	public GameObject linkedTeleporter;
	private bool _isTeleported;
	private Transform _currentTeleporterTransform;

	private void Start() 
	{
		_isTeleported = false;	
	}

    private void OnTriggerEnter(Collider other)
    {
		while (_isTeleported == true)
		{
			if (other.CompareTag("Player"))
        	{
        	    other.transform.position = linkedTeleporter.transform.position;
				_isTeleported = false;
        	}		
		}
    }

	private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isTeleported = false;
        }
    }
}
