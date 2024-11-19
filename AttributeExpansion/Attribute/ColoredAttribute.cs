using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Momos.Tools.Attributes
{
    public class ColoredAttribute : PropertyAttribute
    {
        public Color Color { get; private set; }

        public ColoredAttribute(float r, float g, float b)
        {
            Color = new Color(r, g, b);
        }
    }
}