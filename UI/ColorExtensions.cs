﻿using UnityEngine;

namespace Common.Unity.UI
{
    public static class ColorExtensions
    {
        public static Color GetRandomColor()
        {
            float r = Random.Range(0f, 1f);
            float g = Random.Range(0f, 1f);
            float b = Random.Range(0f, 1f);

            return new Color(r, g, b);
        }

        public static Color GetRandomColor(float a)
        {
            var color = GetRandomColor();
            color.a = a;
            return color;
        }
    }
}
