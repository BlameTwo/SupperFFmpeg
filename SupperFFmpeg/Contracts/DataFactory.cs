using SupperFFmpeg.Contracts.Interfaces;
using SupperFFmpeg.Contracts.Services;
using Windows.Services.Maps;

namespace SupperFFmpeg.Contracts;

public class DataFactory : IDataFactory
{
    public T SetData<T, Value>(Value data)
        where T : IItemData<Value>
    {
        var tvalue = AppLifeRegister.GetService<T>();
        tvalue.SetData(data);
        return tvalue;
    }
}
