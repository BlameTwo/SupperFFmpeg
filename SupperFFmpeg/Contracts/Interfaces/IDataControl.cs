using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupperFFmpeg.Contracts.Interfaces;

public interface IDataControl<T>
{
    public T DataBase { get; set; }

    public void SetControlData(T value);
}
