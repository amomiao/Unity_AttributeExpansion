using UnityEngine;

namespace Momos.Tools.Attributes
{
    public class GUIAliasAttribute : PropertyAttribute
    {
        public string Alias { get; set; }

        public GUIAliasAttribute(string alias)
        {
            Alias = alias;
        }
    }
}