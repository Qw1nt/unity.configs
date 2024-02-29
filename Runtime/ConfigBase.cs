using UnityEngine;

namespace Qw1nt.Runtime.Config
{
    public abstract class ConfigBase : ScriptableObject
    {
        protected const string BaseMenuName = "Configs/";
    }
    
    public abstract class ConfigBase<TConfig, TLoader> : ConfigBase  
        where TConfig : ConfigBase<TConfig, TLoader>
        where TLoader: IConfigLoader<TConfig, TLoader>
    {
    }
}