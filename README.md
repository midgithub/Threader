# Threader
This plugin does one thing - queues functions to be executed in the main thread.

### Instructions
Attach Threader.cs script to a GameObject, or drag Threader.prefab into the scene.

### Usage
```c#
private void Callback()
{
	Debug.Log( "Added directly to the stack with a predefined callback method." );
}

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

// remove a function from the stack. either syntax will work
Threader.Stack -= this.Callback;
Threader.Remove( this.Callback );

// clear the stack. either syntax will work.
Threader.Stack = null;
Threader.Clear();

```
