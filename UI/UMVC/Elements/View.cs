using Common.Basic.UMVC.Elements;
using Common.Unity.GameObjects;
using UnityEngine;

namespace Common.Unity.UI.UMCV
{
    public class View : MonoBehaviour, IView
    {
        public string ID { get; set; }

        public virtual void Hide() => gameObject.SetActive(false);
        public virtual void Show() => gameObject.SetActive(true);

        public virtual bool IsVisible => gameObject.activeSelf;


        IView IView.AsParent() => gameObject.GetOrAddComponent<View>();

        public virtual void FitToChildren() => gameObject.FitToLayoutChildren();

        T IView.GetParent<T>() => GetComponentInParent<T>();

        IView IView.GetParent() => transform.parent.GetOrAddComponent<View>();
    }
}
