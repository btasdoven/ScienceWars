﻿//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2012 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// Simple example script of how a button can be colored when the mouse hovers over it or it gets pressed.
/// </summary>

[AddComponentMenu("NGUI/Interaction/Button Color")]
public class UIButtonColor : MonoBehaviour
{
	/// <summary>
	/// Target with a widget, renderer, or light that will have its color tweened.
	/// </summary>

	public GameObject tweenTarget;

	/// <summary>
	/// Color to apply on hover event (mouse only).
	/// </summary>

	public Color hover = new Color(0.6f, 1f, 0.2f, 1f);

	/// <summary>
	/// Color to apply on the pressed event.
	/// </summary>

	public Color pressed = Color.grey;
	public Color downColor = new Color(163/255.0f, 235/255.0f, 1);

	/// <summary>
	/// Duration of the tween process.
	/// </summary>

	public float duration = 0.2f;

	public bool downButton = false;

	public bool Down {
		set
		{
			mIsButtonDown = value;
			OnPress(false);
		}
	}

	protected Color mColor;
	protected bool mInitDone = false;
	protected bool mStarted = false;
	protected bool mHighlighted = false;
	protected bool mIsButtonDown = false;
	/// <summary>
	/// UIButtonColor's default (starting) color. It's useful to be able to change it, just in case.
	/// </summary>

	public Color defaultColor { get { return mColor; } set { mColor = value; } }

	void Awake () { Init(); }

	void Start () { mStarted = true; OnEnable(); }

	protected virtual void OnEnable () 
	{ 
		if (mStarted && mHighlighted) 
			OnHover(UICamera.IsHighlighted(gameObject)); 

		if (mIsButtonDown)
			OnPress(false);
	}

	void OnDisable ()
	{
		if (tweenTarget != null)
		{
			TweenColor tc = tweenTarget.GetComponent<TweenColor>();

			if (tc != null)
			{
				tc.color = mColor;
				tc.enabled = false;
			}
		}
	}

	protected void Init ()
	{
		mInitDone = true;
		if (tweenTarget == null) tweenTarget = gameObject;
		UIWidget widget = tweenTarget.GetComponent<UIWidget>();

		if (widget != null)
		{
			mColor = widget.color;
		}
		else
		{
			Renderer ren = tweenTarget.renderer;

			if (ren != null)
			{
				mColor = ren.material.color;
			}
			else
			{
				Light lt = tweenTarget.light;

				if (lt != null)
				{
					mColor = lt.color;
				}
				else
				{
					Debug.LogWarning(NGUITools.GetHierarchy(gameObject) + " has nothing for UIButtonColor to color", this);
					enabled = false;
				}
			}
		}
	}

	protected virtual void OnPress (bool isPressed)
	{
		if (enabled) {
			if (mIsButtonDown) {
				TweenColor.Begin(tweenTarget, duration, downColor);
			}
			else
				TweenColor.Begin(tweenTarget, duration, isPressed ? pressed : (UICamera.IsHighlighted(gameObject) ? hover : mColor));

			if (downButton && !mIsButtonDown && isPressed)
				mIsButtonDown = true;
		}
	}

	protected virtual void OnHover (bool isOver)
	{
		if (enabled && !mIsButtonDown)
		{
			TweenColor.Begin(tweenTarget, duration, isOver ? hover : mColor);
			mHighlighted = isOver;
		}
	}
}