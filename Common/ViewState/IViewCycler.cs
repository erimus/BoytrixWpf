using System;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Boytrix.Logic.Business.Common.ViewState
{
    public interface IViewCycler
    {
        bool CanGoNext();
        bool CanGoPrevious();
        void GoPrevious();
        void GoNext();
        void Add(PageDetails pageDegtails);
        void Remove(PageDetails pageDegtails);
        PageDetails CurrentPage { get; }
        void Clear();
    }
}