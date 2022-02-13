#if NET6_0
#else
namespace System.Runtime.CompilerServices;

using System.ComponentModel;

[EditorBrowsable(EditorBrowsableState.Never)]
public sealed class IsExternalInit
{
}
#endif
