using Common.Basic.Maths;
using Common.Basic.UMVC.Elements;
using Common.Unity.Components;
using Common.Unity.GameObjects;
using System.Linq;

namespace Common.Unity.UI.UMVC
{
    public static class ViewTransformExtensions
    {
        public static int GetSiblingIndexOfParent<TParent>(this IView view)
            where TParent : IView
        {
            var parent = view.GetParent<TParent>();
            return GetSiblingIndex(parent);
        }

        public static int GetSiblingIndex(this IView view)
        {
            var transform = view.ToTransform();
            return transform.GetSiblingIndex();
        }

        
        public static int GetSiblingsCountOfParent<TParent, TChild>(this IView view)
            where TParent : IView
            where TChild : IView
        {
            var parent = view.GetParent<TParent>().ToTransform().parent;
            var children = parent.GetChildren<TChild>();

            return NumericExtensions.Clamp(children.Count() - 1, 0, int.MaxValue);
        }
    }
}
