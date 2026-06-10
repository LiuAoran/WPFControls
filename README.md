# WPFControls

一个基于 **.NET 6.0-windows** 的 WPF 自定义控件与示例集合，涵盖主题切换、MVVM、动画、插件架构、国际化等多个方向的实践示例。

---

## 目录

- [项目结构](#项目结构)
- [控件与示例列表](#控件与示例列表)
  - [主题 / 样式](#主题--样式)
  - [按钮类控件](#按钮类控件)
  - [输入类控件](#输入类控件)
  - [列表 / 树形控件](#列表--树形控件)
  - [窗口 / 布局控件](#窗口--布局控件)
  - [动画 / 状态控件](#动画--状态控件)
  - [系统集成](#系统集成)
  - [工具与基础设施](#工具与基础设施)
  - [MEF 插件示例](#mef-插件示例)
- [环境要求](#环境要求)
- [快速开始](#快速开始)

---

## 项目结构

```
WPFControls/
├── ButtonPlus/              # 自定义按钮样式
├── ColorPicker/             # 颜色选择器
├── ComboBoxPlus/            # 自定义下拉框
├── CustomListView/          # 自定义 ListView 容器
├── DarkMode/                # 明暗主题切换
├── DragWrapListBox/         # 可拖拽的流式列表
├── FadeInFadeOut/           # 淡入淡出动画
├── FloatWindow/             # 悬浮窗口
├── GlobalLanguage/          # 国际化多语言
├── HelperTools/             # 工具库
├── ImageDisplayer/          # 图片展示控件
├── ListSettings/            # 设置历史列表
├── ListViewPlus/            # 带搜索的增强 ListView
├── LoadingControl/          # 加载动画控件
├── MefExample.Core/         # MEF 插件核心接口
├── MefExample.Main/         # MEF 主程序
├── MefExample.PluginOne/    # MEF 插件示例一
├── MefExample.PluginTwo/    # MEF 插件示例二
├── MenuBar/                 # 自定义菜单栏
├── MultiPageWrapListBox/    # 分页流式列表
├── MvvmPasswordBox/         # MVVM 密码框
├── PasswordBox/             # 自定义密码框
├── PasswordBoxPlus/         # 带占位符的密码框
├── RadioButtonPlus/         # 图标式单选按钮
├── RountedEventExample/     # 路由事件示例
├── SerializationReplyListBox/ # 可序列化回复列表
├── Settings.Demo/           # 设置面板示例
├── SettingsListView/        # 设置列表
├── Shortcut/                # 键盘快捷键绑定
├── Slider/                  # 带刻度的滑块
├── SortableListView/        # 可排序 ListView
├── SqlDemo/                 # 数据库操作示例
├── StateChange/             # 视觉状态切换
├── TabControl/              # 自定义选项卡
├── TabControls/             # Dragablz 可拖拽选项卡
├── TextBoxPlus/             # 增强输入框 / 数字输入控件
├── TitleBar/                # 自定义标题栏
├── ToggleButtonPlus/        # 滑动开关按钮
├── TrayApp/                 # 系统托盘应用
├── TreeViewPlus/            # 增强树形控件
├── TreeviewPlus/            # 树形控件扩展
└── WrapListBox/             # 流式布局列表
```

---

## 控件与示例列表

### 主题 / 样式

#### DarkMode — 明暗主题切换
演示如何使用 `DynamicResource` 在运行时动态切换 Light Mode、Dark Mode 和默认主题，无需重启应用即可生效。

#### TabControl — 自定义选项卡
提供多种 Tab 样式（矩形 / 下划线），通过动态资源切换主题外观。

#### TabControls — 可拖拽选项卡
集成 [Dragablz](https://github.com/ButchersBoy/Dragablz) 库，支持选项卡的拖拽、浮动和重新排列。

---

### 按钮类控件

#### ButtonPlus — 自定义按钮
提供多种语义化样式：`Success`、`Pass`、`Warning`、`Joy`、`Danger`、`Common`、`Unknown`、`Default`，通过 `ResourceDictionary` 统一管理。

#### RadioButtonPlus — 图标式单选按钮
`TCIRadioButton`（Title / Content / Icon RadioButton），每个选项支持标题、描述文本和图标，适用于选项卡式导航场景。

#### ToggleButtonPlus — 滑动开关
呈现为滑动开关（Toggle Switch）样式的 `ToggleButton`，适合设置页面开/关选项。

---

### 输入类控件

#### TextBoxPlus — 增强输入框
包含以下子控件：
- **TextBoxWithUnitControl** — 带单位后缀的文本框
- **LimitedNumberBoxWithUnitControl** — 带范围限制和单位的数字输入框
- **NumberBoxDropDownControl** — 带下拉列表的数字输入框
- **NumericUpDownControl** — 数字步进器（Numeric UpDown）
- **PageTurningControl** — 翻页/页码跳转控件

#### PasswordBox / PasswordBoxPlus / MvvmPasswordBox — 密码框系列
- **PasswordBox** — 基础自定义密码框（`PasswordBoxPlus` 类）
- **PasswordBoxPlus** — 带水印/占位符文本的密码框
- **MvvmPasswordBox** — 支持 MVVM 绑定的密码框，解决 WPF 原生 `PasswordBox` 无法双向绑定的问题

#### ComboBoxPlus — 自定义下拉框
为原生 `ComboBox` 应用自定义样式，与整体主题保持一致。

#### ColorPicker — 颜色选择器
`ColorSelectorControl`，提供可视化颜色拾取界面。

#### Slider — 带刻度滑块
`TickSlideControl`，支持刻度标记和最大值配置。

#### Shortcut — 键盘快捷键绑定
支持组合键（如 `Ctrl+K`）的快捷键注册与可视化状态反馈。

---

### 列表 / 树形控件

#### ListViewPlus — 增强 ListView
`ListPlus` 控件，内置搜索/过滤功能，实时筛选列表项。

#### SortableListView — 可排序 ListView
支持点击列头对数据进行升序/降序排序。

#### CustomListView — 自定义 ListView 容器
自定义 ListView 扩展的基础容器项目。

#### WrapListBox — 流式布局列表
使用 `WrapPanel` 作为 `ItemsPanel`，列表项自动换行排列。

#### DragWrapListBox — 可拖拽流式列表
在 `WrapListBox` 基础上支持拖拽排序。

#### MultiPageWrapListBox — 分页流式列表
`MultiPageWrapListBoxControl`，在 `WrapListBox` 基础上添加分页功能。

#### SerializationReplyListBox — 可序列化回复列表
带有 `ReplyListManager` 和 `NotifyObject` 的回复/评论树形列表，支持序列化持久化。

#### ListSettings / SettingsListView — 设置历史列表
专门用于展示设置项历史记录的列表控件，支持添加和清除操作。

#### TreeViewPlus / TreeviewPlus — 增强树形控件
`TreePlus` 控件，在原生 `TreeView` 基础上进行功能扩展与样式美化。

---

### 窗口 / 布局控件

#### TitleBar — 自定义标题栏
基于 `WindowChrome` 实现的自定义标题栏，包含最小化、最大化、关闭按钮及菜单项，支持完全自定义外观。

#### FloatWindow — 悬浮窗口
圆形透明悬浮窗，具有置顶、无任务栏图标等特性，适合全局快捷工具悬浮展示。

#### MenuBar — 自定义菜单栏
自定义 `MenuItem` 模板，支持多级下拉菜单和展开/收起动画。

#### ImageDisplayer — 图片展示控件
`ImageDisplayerControl`，提供图片加载与操作（Add/Sub）功能。

---

### 动画 / 状态控件

#### FadeInFadeOut — 淡入淡出动画
演示 WPF 动画中淡入（Fade In）和淡出（Fade Out）效果的实现方式。

#### StateChange — 视觉状态切换
使用 `VisualStateManager` 在 `Busy`、`Free`、`Normal` 等状态间切换，并附带颜色过渡动画。

#### LoadingControl — 加载动画控件
转圈加载（Loading Spinner）控件，用于异步操作时的等待状态展示。

#### RountedEventExample — 路由事件示例
演示 WPF 路由事件（Routed Events）冒泡机制，通过 `Button.Click` 在父容器统一处理子按钮事件。

---

### 系统集成

#### TrayApp — 系统托盘应用
MVVM 模式下的系统托盘（Notification Icon）集成，使用 `NotifyIconWrapper` 实现托盘图标、气泡提示和右键菜单命令。

#### SqlDemo — 数据库操作示例
演示在 WPF 应用中进行 SQL 数据库操作的基本模式。

#### Settings.Demo — 设置面板示例
应用设置/偏好配置界面的综合示例。

---

### 工具与基础设施

#### GlobalLanguage — 国际化多语言
演示基于资源文件（`.resx`）的运行时语言切换，内置 `zh-CN`（简体中文）和 `en-US`（英语）支持。  
> 详见项目内 `README` 了解接入方式。

#### HelperTools — 工具库
公共工具方法集合，供其他项目引用。

---

### MEF 插件示例

演示使用 **Managed Extensibility Framework (MEF)** 构建可扩展插件系统的完整流程：

| 项目 | 职责 |
|------|------|
| `MefExample.Core` | 定义插件接口与公共基类 |
| `MefExample.Main` | 主程序，运行时动态加载并展示插件 |
| `MefExample.PluginOne` | 插件示例一 |
| `MefExample.PluginTwo` | 插件示例二 |

---

## 环境要求

| 项目 | 要求 |
|------|------|
| .NET | 6.0-windows 或更高 |
| IDE | Visual Studio 2022（推荐）|
| OS | Windows 10 / 11 |

---

## 快速开始

1. 克隆仓库：
   ```bash
   git clone https://github.com/LiuAoran/WPFControls.git
   ```

2. 用 Visual Studio 打开解决方案：
   ```
   WPFControls/WPFControls.sln
   ```

3. 在解决方案资源管理器中，右键选择想要运行的子项目，设为「启动项目」，然后按 `F5` 运行。

4. 每个子项目均为独立可运行的示例，互不依赖（MEF 示例除外，需同时编译 Core 与 Plugin 项目）。
