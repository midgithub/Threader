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

### License
Copyright (c) 2016 Kevin von Flotow <vonflow@gmail.com>

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
