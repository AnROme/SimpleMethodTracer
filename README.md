SimpleMethodTracer
=============

Usage
-------

Create a MethodTracer instance at the beginning of you method to log enter and exit points:

```csharp
public class Test
{
	void Method()
	{
		using (new MethodTracer())
		{
			// some code
		}
	}
}
```

#### Output:

```
[Test::Method] -- enter
// other messages
[Test::Method] -- exit

```