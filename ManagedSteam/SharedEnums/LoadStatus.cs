#if !__cplusplus
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam
{
#endif

#if __cplusplus
namespace SteamAPIWrap
{
    struct ELoadStatus
    {

    enum Enum
#else
    /// <summary>
    /// The load status of the native dll
    /// </summary>
    enum LoadStatus
#endif
    {
        NotLoaded,
        Loaded,
        Unloaded,
    }
#if __cplusplus
        ;
    };
#endif

} // namespace, used by both c# and C++
