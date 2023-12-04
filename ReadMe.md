#### This is a new FFmpeg GUI Tool

##### 项目分解

### 1. SupperFFmpeg

##### 主应用

###### 目录结构

1. Assets
   
   1. 应用图片和FFmpeg编译包

2. Contracts，应用服务层接口定义，以下是该目录下的其他目录解释。
   
   1. Interfaces，应用UI的接口定义，列表子项（IItems）和用户控件(IUserControl）
   
   2. Services，应用的所有服务层，不可继承不可重写。

3. Converters，UI数据绑定转换器。

4. Models，UI实体类文件夹。

5. Selectors，对DataTemplate的一个分类筛选选择器文件夹。

6. ViewModels，视图模型层
   
   1. Bases，一些视图模型的基类，可重写可继承。
   
   2. ControlViewModels，用户控件的视图模型，继承与Bases文件夹下的**ControlControlBase**
   
   3. ItemViewModels，用户子项的视图模型，继承与Bases文件夹之下的**ItemControlBase**

7. Views，视图层，所有的界面都在这里。

### 2. SupperFFmpeg.Core

###### 目录

1. Arguments，生成FFmpeg命令行参数
   
   1. Processers，生成对象，以下文件夹中类都继承于**Processer**抽象类，不可继承不可重写。

2. Common，主要是用作帮助的一些静态方法。
   
   1. JsonConverters，非静态类文件夹，主要是**System.Text.Json**命名空间下的Json自写转换器。

3. Contracts，协议（Interface）
   
   1. Models，一定会被实体类继承的接口，而并非抽象类。

4. Toolkits，静态方法，对FFmpeg实行转换的工具类集合，例如视频快照，视频流信息。

### 3. SupperFFmpeg.UI

###### 目录

1. Controls，自写控件。
   
   1. ImageEx，抄的CommunityToolkit.Windows的图片组件。
   
   2. DropFileCard，文件拖动识别路径控件。
   
   3. TitleBar，对现有的可支持的标题栏功能封装。

2. Styles，对*Controls*的控件样式编写。

##### 4. Core.Test

单元测试项目


