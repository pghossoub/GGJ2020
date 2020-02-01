
namespace Marsheleene.Architecture
{
    public abstract class GlobalManager<T> : GlobalSingletonGameObject<T> where T : GlobalManager<T>
    {

    }
}