using System.Collections.Generic;
using System.Linq;

public class Dependencies
{
    private readonly IEnumerable<IInitializable> _initializables;
    private readonly IEnumerable<ISubscriber> _subscribers;
    private readonly IEnumerable<IUpdatable> _updatables;

    public Dependencies(object[] dependencies)
    {
        _initializables = dependencies.OfType<IInitializable>();
        _subscribers = dependencies.OfType<ISubscriber>();
        _updatables = dependencies.OfType<IUpdatable>();
    }

    public void InitializeForEach() => _initializables.ForEach(element => element.Initialize());

    public void SubscribeForEach() => _subscribers.ForEach(element => element.Subsribe());

    public void UnsubscribeForEach() => _subscribers.ForEach(element => element.Unsubsribe());

    public void UpdateForEach() => _updatables.ForEach(element => element.Update());
}