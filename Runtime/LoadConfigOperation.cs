namespace Qw1nt.Runtime.Config
{
    public struct LoadConfigOperation<TConfig, TLoader>
        where TConfig : ConfigBase<TConfig, TLoader>
        where TLoader : struct, IConfigLoader<TConfig, TLoader>
    {
        public LoadConfigOperation(TLoader loader)
        {
            Loader = loader;
        }

        public readonly TLoader Loader;

        public static implicit operator string(LoadConfigOperation<TConfig, TLoader> operation)
        {
            return operation.Loader.Key;
        }
    }
}