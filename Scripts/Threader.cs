/**
 * Copyright (c) 2016 Kevin von Flotow <vonflow@gmail.com>
 * 
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the
 * "Software"), to deal in the Software without restriction, including
 * without limitation the rights to use, copy, modify, merge, publish,
 * distribute, sublicense, and/or sell copies of the Software, and to
 * permit persons to whom the Software is furnished to do so, subject to
 * the following conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
 * LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
 * OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
 * WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using UnityEngine;

/// <summary>
/// simple plugin for executing code in the main thread.
/// </summary>
public class Threader : MonoBehaviour
{
	/// <summary>
	/// delegate type for use in the stack.
	/// </summary>
	public delegate void Callback();

	/// <summary>
	/// main stack of functions to execute in the main thread.
	/// </summary>
	public static Callback Stack;

	/// <summary>
	/// calls DontDestroyOnLoad on this gameObject,
	/// causing it to persist through scene loading.
	/// </summary>
	public bool DoNotDestroy = false;

	/// <summary>
	/// add a callback to the stack.
	/// </summary>
	public static void Add( Callback _callback )
	{
		Stack += _callback;
	}

	/// <summary>
	/// removes a callback from the stack.
	/// </summary>
	public static void Remove( Callback _callback )
	{
		Stack -= _callback;
	}

	/// <summary>
	/// clears the stack.
	/// </summary>
	public static void Clear()
	{
		Stack = null;
	}

	void Awake()
	{
		if ( this.DoNotDestroy )
		{
			DontDestroyOnLoad( this.gameObject );
		}
	}

	void Start()
	{
		// make sure the stack is always reset on start.
		Stack = null;
	}

	void Update ()
	{
		// do nothing if stack is empty.
		if ( Stack == null )
		{
			return;
		}

		// execute the stack.
		Stack();

		// clear the stack after executing all callbacks.
		Stack = null;
	}
}
