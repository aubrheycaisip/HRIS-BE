namespace HRIS_BE.Helpers.Models
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ServiceDependencyAttribute : Attribute
    {
        public ServiceLifetime Lifetime { get; }
        public Type? ServiceType { get; }
        public ServiceDependencyAttribute(ServiceLifetime lifetime = ServiceLifetime.Transient, Type serviceType = null)
        {
            Lifetime = lifetime;
            ServiceType = serviceType;
        }
    }
}
