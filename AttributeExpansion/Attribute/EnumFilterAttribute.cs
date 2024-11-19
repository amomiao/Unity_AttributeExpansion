using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Momos.Tools.Attributes
{
    public class EnumFilterAttribute : PropertyAttribute
    {
        public Type EnumType { get; private set; }

        public EnumFilterAttribute(Type type)
        {
            EnumType = type;
        }
    }
}