namespace Qw1nt.Runtime.Config
{
    public interface IConfigLoader<TConfig, TLoader>
        where TLoader : IConfigLoader<TConfig, TLoader>
    {
        public string Key { get; }
    }
}