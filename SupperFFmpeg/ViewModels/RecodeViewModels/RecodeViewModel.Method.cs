using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SupperFFmpeg.Contracts.Interfaces;
using SupperFFmpeg.Contracts.Services;
using SupperFFmpeg.Core.Models;
using SupperFFmpeg.Core.Toolkits;
using SupperFFmpeg.ViewModels.ControlViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupperFFmpeg.ViewModels;

public sealed partial class RecodeViewModel : ObservableRecipient
{
    public RecodeViewModel(IFileSelectService fileSelectService,IDataFactory dataFactory)
    {
        FileSelectService = fileSelectService;
        DataFactory = dataFactory;
        this.CodecVideoListSource = CodecToolkit.GetVideoOutput();
    }
}
