using CommunityToolkit.Mvvm.ComponentModel;
using SupperFFmpeg.Contracts.Interfaces;
using SupperFFmpeg.Core.Contracts.Models;
using System.Threading.Tasks;

namespace SupperFFmpeg.ViewModels.Bases;

public partial class ControlControlBase<T> : ObservableObject, IDataControl<T>
{
    public T DataBase { get; set; }


    public async Task SetControlDataAsync(T value)
    {
        this.DataBase = value;
        await Task.CompletedTask;
    }
}
