namespace Infrastructure.DI;
/// <summary>
/// Provides a simple dependency injection container for registering and resolving services and their implementations.
/// </summary>
/// <remarks>This container supports both instance-based and type-based service registrations.  Services can be
/// registered as specific instances or as mappings between service types and their implementations. When resolving a
/// service, the container will attempt to construct the implementation using its constructor,  recursively resolving
/// any dependencies required by the constructor parameters.</remarks>
public class SimpleContainer
{
    private readonly Dictionary<Type, object> _instance = new();
    private readonly Dictionary<Type, Type> _registrations = new();
    public void RegisterInstance<TService>(object instance) => _instance[typeof(TService)] = instance;
    public void Register<Tservice, TImpl>() where TImpl : Tservice
    {
        _registrations[typeof(Tservice)] = typeof(TImpl);
    }
    public T Resolve<T>()
    {
        var t = typeof(T);
        if (_instance.TryGetValue(t, out var inst)) return (T)inst;
        if (_registrations.TryGetValue(t, out var implType))
        {
            var ctor = implType.GetConstructors()[0];
            var parameters = ctor.GetParameters();
            var args = new object?[parameters.Length];

            for (var i = 0; i < parameters.Length; i++) 
            {
                var paramType = parameters[i].ParameterType;
                var method = typeof(SimpleContainer).GetMethod(nameof(Resolve))!.MakeGenericMethod(paramType);
                args[i] = method.Invoke(this, null);
            }
            var createdObj = Activator.CreateInstance(implType, args);
            if (createdObj is null)
                throw new InvalidOperationException($"Could not create instance of {implType.FullName}");
            return (T)createdObj;
        }
        throw new InvalidOperationException($"Type {t.FullName} not supported");
    }
}
