using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Common.Unity.Scripts.Common
{
    public class GetSpritesExtentsCoord : MonoBehaviour
    {
        [SerializeField] private List<SpriteRenderer> _spriteRenderers;
        
        public float Get()
        {
            var a= _spriteRenderers
                .Select(r => r.bounds.size.y)
                .Aggregate((x, y) => x + y);

            return a;
        }
    }
};