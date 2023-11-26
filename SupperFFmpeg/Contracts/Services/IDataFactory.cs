using SupperFFmpeg.Contracts.Interfaces;

namespace SupperFFmpeg.Contracts.Services;

public interface IDataFactory
{
    public T SetData<T, Value>(Value data)
        where T : IItemData<Value>;
}
