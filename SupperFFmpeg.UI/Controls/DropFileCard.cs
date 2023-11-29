using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;

namespace SupperFFmpeg.UI.Controls;

[TemplatePart(Name = "MainGrid", Type = typeof(Grid))]
[ContentProperty(Name = "Content")]
[TemplateVisualState(GroupName ="DefaultOpenFileGroup",Name ="OpenFileState")]
[TemplateVisualState(GroupName ="DefaultOpenFileGroup",Name ="ClearFileState")]
public partial class DropFileCard:Control
{

    #region 事件
    public delegate void OpenFiledDelegate(object sender, string filePath);

    private OpenFiledDelegate OpenFiledHandler;
    public event OpenFiledDelegate OpenFiled
    {
        add => OpenFiledHandler += value;
        remove => OpenFiledHandler -= value;
    }

    #endregion
    public DropFileCard()
    {
        this.DefaultStyleKey = typeof(DropFileCard);
    }

    #region 控件模板
    private Grid _mainGrid;
    #endregion
    #region 依赖属性


    public string Title
    {
        get { return (string)GetValue(TitleProperty); }
        set { SetValue(TitleProperty, value); }
    }

    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register("Title", typeof(string), typeof(DropFileCard), new PropertyMetadata(null));

    public object Content
    {
        get { return (object)GetValue(ContentProperty); }
        set { SetValue(ContentProperty, value); }
    }

    public static readonly DependencyProperty ContentProperty =
        DependencyProperty.Register("Content", typeof(object), typeof(DropFileCard), new PropertyMetadata(null));




    public bool IsOpenFile
    {
        get { return (bool)GetValue(IsOpenFileProperty); }
        set { SetValue(IsOpenFileProperty, value); }
    }

    public static readonly DependencyProperty IsOpenFileProperty =
        DependencyProperty.Register("IsOpenFile", typeof(bool), typeof(DropFileCard), new PropertyMetadata(false,OnOpenFileBoolChanged));

    private static void OnOpenFileBoolChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if(e.NewValue is  bool bol && bol)
        {
            VisualStateManager.GoToState(d as DropFileCard, "OpenFileState", false);
        }
        else
        {
            VisualStateManager.GoToState(d as DropFileCard, "ClearFileState", false);
        }
    }

    public DataTemplate ContentTemplate
    {
        get { return (DataTemplate)GetValue(ContentTemplateProperty); }
        set { SetValue(ContentTemplateProperty, value); }
    }

    public static readonly DependencyProperty ContentTemplateProperty =
        DependencyProperty.Register("ContentTemplate", typeof(DataTemplate), typeof(DropFileCard), new PropertyMetadata(null));



    public string FileOpenHeaderText
    {
        get { return (string)GetValue(FileOpenHeaderTextProperty); }
        set { SetValue(FileOpenHeaderTextProperty, value); }
    }

    // Using a DependencyProperty as the backing store for FileOpenHeaderText.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty FileOpenHeaderTextProperty =
        DependencyProperty.Register("FileOpenHeaderText", typeof(string), typeof(DropFileCard), new PropertyMetadata("拖放文件到此处表示打开"));




    public string FilePath
    {
        get { return (string)GetValue(FilePathProperty); }
        set { SetValue(FilePathProperty, value); }
    }

    // Using a DependencyProperty as the backing store for FilePath.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty FilePathProperty =
        DependencyProperty.Register("FilePath", typeof(string), typeof(DropFileCard), new PropertyMetadata(""));

    /// <summary>
    /// 文件扩展名
    /// </summary>
    public string FileExtention => System.IO.Path.GetExtension(FilePath)?.Trim();
    #endregion


    protected override void OnApplyTemplate()
    {
        this._mainGrid = (Grid)GetTemplateChild("MainGrid");
        InitUI();
        base.OnApplyTemplate();
        Update();
    }

    private void Update()
    {
        if(this.IsOpenFile == true)
        {
            VisualStateManager.GoToState(this, "OpenFileState", false);
        }
        else
        {
            VisualStateManager.GoToState(this, "ClearFileState", false);
        }
    }

    private void InitUI()
    {
        _mainGrid.AllowDrop = true;
        _mainGrid.Drop += _mainGrid_Drop;
        _mainGrid.DragEnter += _mainGrid_DragOver;
    }

    private void _mainGrid_DragOver(object sender, DragEventArgs e)
    {
        e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Link;
    }

    private async void _mainGrid_Drop(object sender, DragEventArgs e)
    {
        if (e.DataView.Contains(StandardDataFormats.StorageItems))
        {
            Debug.WriteLine("[Info] DataView Contains StorageItems");
            var items = await e.DataView.GetStorageItemsAsync();

            //文件过滤 只取vcf文件 PS:如果拖过来的是文件夹 则需要对文件夹处理 取出文件夹文件
            items = items.OfType<StorageFile>().ToList() as IReadOnlyList<IStorageItem>;
            if(items.Count == 1)
            {
                this.OpenFiledHandler?.Invoke(this, items[0].Path);
                this.FilePath = items[0].Path;
                this.IsOpenFile = true;
                Update();
            }
        }
    }
}
