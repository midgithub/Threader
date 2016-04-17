using UnityEngine;
using System.Collections;

public class ThreaderTest : MonoBehaviour
{
	private void Callback()
	{
		Debug.Log( "Added directly to the stack with a predefined callback method." );
	}

	private IEnumerator UpdateThreader()
	{
		Threader.Stack += this.Callback;

		Threader.Stack += () =>
		{
			Debug.Log( "Added directly to the stack." );
		};

		Threader.Add( this.Callback );

		Threader.Add( () =>
			{
				Debug.Log( "Added with Add method." );
			}
		);

		yield return new WaitForSeconds( 2f );

		StartCoroutine( this.UpdateThreader() );

		// either syntax will work
		Threader.Stack -= this.Callback;
		// Threader.Remove( this.Callback );
		Debug.Log( "Removed a function from the stack." );
	}

	// Use this for initialization
	void Start ()
	{
		StartCoroutine( this.UpdateThreader() );
	}
}
