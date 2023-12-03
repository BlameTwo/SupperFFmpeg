using CommunityToolkit.Mvvm.ComponentModel;
using SupperFFmpeg.Contracts.Interfaces;
using SupperFFmpeg.Core.Contracts.Models;

namespace SupperFFmpeg.ViewModels.Bases;

public partial class ControlControlBase<T> : ObservableObject, IDataControl<T>
{
    public T DataBase { get; set; }

    public void SetControlData(T value)
    {
        this.DataBase = value;
    }
}
