using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;
using System;

namespace SupperFFmpeg.UI.Controls;

[TemplatePart(Name = "MainGrid", Type = typeof(Grid))]
[ContentProperty(Name = "Content")]
public partial class DropFileCard:Control
{
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




    public DataTemplate ContentTemplate
    {
        get { return (DataTemplate)GetValue(ContentTemplateProperty); }
        set { SetValue(ContentTemplateProperty, value); }
    }

    public static readonly DependencyProperty ContentTemplateProperty =
        DependencyProperty.Register("ContentTemplate", typeof(DataTemplate), typeof(DropFileCard), new PropertyMetadata(null));



    #endregion

    protected override void OnApplyTemplate()
    {
        this._mainGrid = (Grid)GetTemplateChild("MainGrid");
        InitUI();
        base.OnApplyTemplate();
        
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

    private void _mainGrid_Drop(object sender, DragEventArgs e)
    {

    }
}
