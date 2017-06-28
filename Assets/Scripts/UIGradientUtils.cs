﻿using UnityEngine;

public static class UIGradientUtils
{
	public static Color InterpolatedColor(Vector2 normalizedPosition, Color topLeft, Color topRight, Color bottomLeft, Color bottomRight)
	{
		Color top = Color.Lerp(topLeft, topRight, normalizedPosition.x);
		Color bottom = Color.Lerp(bottomLeft, bottomRight, normalizedPosition.x);
		return Color.Lerp(bottom, top, normalizedPosition.y);
	}

	public static Vector2 NormalizedPosition(Vector2 position, Rect rect)
	{
		float x = Mathf.InverseLerp (rect.xMin, rect.xMax, position.x);
		float y = Mathf.InverseLerp (rect.yMin, rect.yMax, position.y);
		return new Vector2(x, y);
	}

	public static Vector2 Rotate(Vector2 v, float cos, float sin)
	{
		float x = (cos * v.x) - (sin * v.y);
		float y = (sin * v.x) + (cos * v.y);
		return new Vector2(x, y);
	}

	static Vector2[] ms_verticesPositions = new Vector2[] { Vector2.up, Vector2.one, Vector2.right, Vector2.zero };
	public static Vector2[] VerticePositions
	{
		get { return ms_verticesPositions; }
	}

	public static float InverseLerp (float a, float b, float v)
	{
		return a != b ? (v - a) / (b - a) : 0f;
	}

	public static void Lerp(UIVertex a, UIVertex b, float t, ref UIVertex c)
	{
		c.position = Vector3.LerpUnclamped(a.position, b.position, t);
		c.normal = Vector3.LerpUnclamped(a.normal, b.normal, t);
		c.color = Color.LerpUnclamped(a.color, b.color, t);
		c.tangent = Vector3.LerpUnclamped(a.tangent, b.tangent, t);
		c.uv0 = Vector3.LerpUnclamped(a.uv0, b.uv0, t);
		c.uv1 = Vector3.LerpUnclamped(a.uv1, b.uv1, t);
		// c.uv2 = Vector3.LerpUnclamped(a.uv2, b.uv2, t);
		// c.uv3 = Vector3.LerpUnclamped(a.uv3, b.uv3, t);		
	}
}
