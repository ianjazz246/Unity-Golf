using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleButtonLatched : MonoBehaviour
{
    public Transform buttonPad;
    public UnityEvent onButtonPressEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag("Player"))
		{
            onButtonPressEvent.Invoke();
        }
	}
}
