using Microsoft.Extensions.DependencyInjection;


namespace SR.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection collection);
    }
}
