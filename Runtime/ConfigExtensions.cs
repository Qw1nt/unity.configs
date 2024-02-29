using Cysharp.Threading.Tasks;
using Qw1nt.Runtime.AddressablesContentController.Common;
using Qw1nt.Runtime.AddressablesContentController.Core;

namespace Qw1nt.Runtime.Config
{
    public static class ConfigExtensions
    {
        public static async UniTask<ContentOperation<TConfig>> LoadAsync<TConfig, TLoader>(this ConfigBase<TConfig, TLoader> config)
            where TConfig : ConfigBase<TConfig, TLoader>
            where TLoader : struct, IConfigLoader<TConfig, TLoader>
        {
            return await ContentController.Default.LoadAsync<TConfig>(new TLoader().Key);
        }
    }
}