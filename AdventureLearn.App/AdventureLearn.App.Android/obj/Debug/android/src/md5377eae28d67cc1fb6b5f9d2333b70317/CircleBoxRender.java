package md5377eae28d67cc1fb6b5f9d2333b70317;


public class CircleBoxRender
	extends md51558244f76c53b6aeda52c8a337f2c37.VisualElementRenderer_1
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_draw:(Landroid/graphics/Canvas;)V:GetDraw_Landroid_graphics_Canvas_Handler\n" +
			"";
		mono.android.Runtime.register ("AsNum.XFControls.Droid.CircleBoxRender, AsNum.XFControls.Droid", CircleBoxRender.class, __md_methods);
	}


	public CircleBoxRender (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == CircleBoxRender.class)
			mono.android.TypeManager.Activate ("AsNum.XFControls.Droid.CircleBoxRender, AsNum.XFControls.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public CircleBoxRender (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == CircleBoxRender.class)
			mono.android.TypeManager.Activate ("AsNum.XFControls.Droid.CircleBoxRender, AsNum.XFControls.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public CircleBoxRender (android.content.Context p0)
	{
		super (p0);
		if (getClass () == CircleBoxRender.class)
			mono.android.TypeManager.Activate ("AsNum.XFControls.Droid.CircleBoxRender, AsNum.XFControls.Droid", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public void draw (android.graphics.Canvas p0)
	{
		n_draw (p0);
	}

	private native void n_draw (android.graphics.Canvas p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
