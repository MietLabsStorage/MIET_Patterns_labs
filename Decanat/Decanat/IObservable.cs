using System.Collections.Generic;

namespace Decanat
{
    public interface IObservable
    {
        List<IObserver> Observers { get; }
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }
}