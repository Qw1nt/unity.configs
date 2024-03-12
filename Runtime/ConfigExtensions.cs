using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

#if CONFIG_CONTENT_CONTROLLER_INTEGRATION
using Qw1nt.Runtime.AddressablesContentController.Common;
using Qw1nt.Runtime.AddressablesContentController.Core;
#endif

namespace Qw1nt.Runtime.Config
{
    public static class ConfigExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static LoadConfigOperation<TConfig, TLoader> Load<TConfig, TLoader>(
            this ConfigBase<TConfig, TLoader> config)
            where TConfig : ConfigBase<TConfig, TLoader>
            where TLoader : struct, IConfigLoader<TConfig, TLoader>
        {
            return new LoadConfigOperation<TConfig, TLoader>(new TLoader());
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TConfig FromResources<TConfig, TLoader>(
            this LoadConfigOperation<TConfig, TLoader> operation)
            where TConfig : ConfigBase<TConfig, TLoader>
            where TLoader : struct, IConfigLoader<TConfig, TLoader>
        {
            return Resources.Load<TConfig>(operation.Loader.Key);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async UniTask<TConfig> FromResourcesAsync<TConfig, TLoader>(
            this LoadConfigOperation<TConfig, TLoader> operation)
            where TConfig : ConfigBase<TConfig, TLoader>
            where TLoader : struct, IConfigLoader<TConfig, TLoader>
        {
            return (TConfig) await Resources.LoadAsync<TConfig>(operation.Loader.Key);
        }

#if !UNITY_WEBGL
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TConfig FromAddressables<TConfig, TLoader>(
            this LoadConfigOperation<TConfig, TLoader> operation)
            where TConfig : ConfigBase<TConfig, TLoader>
            where TLoader : struct, IConfigLoader<TConfig, TLoader>
        {
            return Addressables.LoadAssetAsync<TConfig>(operation.Loader.Key).WaitForCompletion();
        }
#endif

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async UniTask<TConfig> FromAddressablesAsync<TConfig, TLoader>(
            this LoadConfigOperation<TConfig, TLoader> operation)
            where TConfig : ConfigBase<TConfig, TLoader>
            where TLoader : struct, IConfigLoader<TConfig, TLoader>
        {
            return await Addressables.LoadAssetAsync<TConfig>(operation.Loader.Key);
        }

#if CONFIG_CONTENT_CONTROLLER_INTEGRATION
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static async UniTask<ContentOperation<TConfig>> FromContentControllerAsync<TConfig, TLoader>(
            this LoadConfigOperation<TConfig, TLoader> operation)
            where TConfig : ConfigBase<TConfig, TLoader>
            where TLoader : struct, IConfigLoader<TConfig, TLoader>
        {
            return await ContentController.Default.LoadAsync<TConfig>(operation.Loader.Key);
        }
#endif
    }
}