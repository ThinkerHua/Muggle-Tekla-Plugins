# Muggl Tekla-Plugins
用于Tekla Structures的工具和插件
## ShowModelObjectCoordinateSystem(显示模型零件坐标系)
软件自带的宏每次均需双击启动，且只能运行一次。本工具可以一次启动，点选并显示多个零件的坐标系。调试时很有用。

![ShowModelObjectCoordinateSystem](https://github.com/ThinkerHua/Muggle-Tekla-Plugins/blob/master/Resources/Introduction_ShowModelObjectCoordinateSystem.gif)
## SelectBooleans(选择布尔操作对象)
在管桁架建模时很有用，当有很多布尔操作对象重叠在一起时，要选中某一个零件的布尔操作对象很困难，此工具可派上用场，即使视图中关闭了切割或对齐显示也依然能够选中。

![SelectBooleans](https://github.com/ThinkerHua/Muggle-Tekla-Plugins/blob/master/Resources/Introduction_SelectBooleans.gif)
## MG1001(门刚系列节点 - 门刚边柱与梁竖向连接)
特点是可以根据端板高度自动适配调整柱高度。参数化组件做不到这点，打完节点后还要手动调整柱高。

![MG1001](https://github.com/ThinkerHua/Muggle-Tekla-Plugins/blob/master/Resources/Introduction_MG1001.gif)
## MG1002(门刚系列节点 - 门刚中柱与梁横向连接)
没什么特点，不过在编写过程中对端板定位的问题费了点脑筋。

![MG1002](https://github.com/ThinkerHua/Muggle-Tekla-Plugins/blob/master/Resources/Introduction_MG1002.gif)
## HJ1001(桁架系列节点 - 圆管对接)
特点是对曲线梁(用CurvedBeam(曲梁)或PolyBeam(多边形梁)绘制)也适用。参数化组件只能用于直线梁对接，对于曲线梁无法胜任。

缺点是用在多边形梁上时，节点符号的位置会有错位，这是API自身的问题，无法解决。不过不影响使用，无伤大雅。

![HJ1001](https://github.com/ThinkerHua/Muggle-Tekla-Plugins/blob/master/Resources/Introduction_HJ1001.gif)
