新建:
	1) 写一个继承PropertyAttribute的特性类A,
	2) 写一个继承PropertyDrawer的编辑器类B,
	3) B修饰[CustomPropertyDrawer(typeof(A))]
	4) public override void OnGUI
	5）绘制对象的框: EditorGUI.PropertyField(position, property, label);
		// 基本不能修饰数组, 修饰数组的PropertyDrawer会给到数组中的每一项而非数组本身。
	6) 如果想要更高的占位: public override float GetPropertyHeight

小注:
	1) 能获取数组对象的情况下绘制Unity对数组的Inspector绘制;
		var list = new ReorderableList(property.serializedObject, property);
        list.drawHeaderCallback = ;
        list.drawElementCallback = ;
        list.elementHeightCallback = ;
        list.DoLayoutList();	// 回调很多,仅列举一些

1.[Colored(float r, float g, float b)]
	演示类,仅改变GUI颜色。
	用例
		[Colored(1,1,1)]
		public int i;
2.[EnumFilter(Type type)]
	Type必须是枚举类型,当枚举项数量多时使用,下拉框中会匹配输入框中的内容。
***	非自定义的枚举有一些问题,比如KeyCode 选择手柄相关的Key会报错。
	用例
		[EnumFilter(typeof(E_ItemKey))]
        public E_ItemKey itemKey = E_ItemKey.None;
3.[GUIReadOnly]
*** 不支持修饰Array。
	被修饰的对象在Inspector上只读显示。
	对于public的对象,只需要使用这个特性;
	对于其他保护性的对象,需要配合[SerializeField]使用(无序)。
4.[GUIAlias(string alias)]
*** 不支持修饰Array。
	将使用传入的'alias'参数 取代变量名的显示。