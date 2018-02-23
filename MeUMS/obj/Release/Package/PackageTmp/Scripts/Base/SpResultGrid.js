/********************************************************************************
** 作者： 张青云
** 创始时间：2016年12月3日13:43:30
** 修改人：
** 修改时间：
** 描述：表格基础库
*********************************************************************************/
Sp.SpResultGrid = function (objectParam) {
    this._resultGrid = null; //表格对象
    this._title = objectParam._title == null ? "" : objectParam._title; //表格标题
    //this._tableDivID = "middle_center"; //表格div
    this._tableDivID = objectParam._tableDivID == null ? "middle_center" : objectParam._tableDivID;  //表格div
    this._fieldsArray = objectParam._fieldsArray; //字段配置数组
    this._fields = []; //字段数组
    this._pageSize = objectParam._pageSize == null ? 15 : objectParam._pageSize; //每页条数
    this._params = {}; //参数类
    this._params.action = objectParam._Action == null ? "pagingQuery" : objectParam._Action;
    this._params.tableName = objectParam._tableName;
    this._params.sort = objectParam._sort;
    this._handleMenu = objectParam._handleMenu;
    this._handleMenuWidth = objectParam._handleMenuWidth;
    this._preToolbarMenu = objectParam._preToolbarMenu; //搜索栏中，关键字前的控件
    this._toolbarMenu = objectParam._toolbarMenu; //搜索栏中，重置按钮后的控件
    this._beforeQueryFun = objectParam.BeforeQueryFun; //执行查询前调用的外部函数,便于组织查询条件
    this._searchTextTip = objectParam._searchTextTip;
    this._searchTextWidth = objectParam._searchTextWidth == null ? 200 : objectParam._searchTextWidth; //输入框宽度
    this._baseQueryBar = objectParam._baseQueryBar == null ? true : objectParam._baseQueryBar; //是否显示默认的搜索框、搜索、重置按钮,默认为：true，表示显示；false:表示隐匿（但要显示整个工具条）
    this._searchTextFields = objectParam._searchTextFields;
    this._initRender = objectParam._initRender;
    this._initGridBbar = objectParam._initGridBbar == false ? false : true; //渲染分页条,true:渲染（默认）,false：不渲染
    this._initTools = objectParam._initTools == null ? [] : objectParam._initTools; //表格Tools工具条
}
Sp.SpResultGrid.prototype = {
    Execute: function (strWhere) {
        this._CreateGrid(strWhere);
    },
    _CreateGrid: function (strWhere) {
        /// <summary>
        /// 创建表格
        /// </summary>
        this._fields = [];
        for (var i = 0; i < this._fieldsArray.length; i++) {
            this._fields.push(this._fieldsArray[i].lename)
        }
        this._params.start = 0;
        this._params.pageSize = this._pageSize;
        this._params.fields = this._fields.join(",");
        if (null != strWhere && "" != strWhere) {//初始化表格时,增加查询条件
            this._params.whereClause = " where " + strWhere;
        }
        //var gridConfig = { tbar: this._CreateToolbar(), sm: this._GetChkm(), fieldArray: this._fields, columnModel: this._CreateCM(), title: this._title, autoExpandColumn: 'description' }
        var gridConfig = {
            tbar: this._CreateToolbar(), fieldArray: this._fields, columnModel: this._CreateCM(), title: this._title, autoExpandColumn: 'description', pageSize: this._pageSize, bbar: this._initGridBbar, tools: this._initTools
        }
        this._resultGrid = new Sp.RemoteGridPanel(this._tableDivID, gridConfig);
        this._resultGrid.AddOnBeforeLoadAction(Sp.Delegate(this, this._StoreBeforeLoad));
        this._resultGrid.AddOnExceptionAction(function (dataProxy, type, action, options, response, arg) {
            if (response.isTimeout) {
                Ext.Msg.alert("网络链接超时,请检查网络");
            }
            else {
                Ext.Msg.alert(arg.message);
            }
        });
        this._resultGrid.Execute();
        this._resultGrid.SetWidth($("#" + this._tableDivID).width());
        this._resultGrid.SetHeight($("#" + this._tableDivID).height());
    },
    //_GetChkm: function () {
    //    if (null == this._chkm) {
    //        this._chkm = new Ext.grid.CheckboxSelectionModel();
    //    }
    //    return this._chkm;
    //},
    _StoreBeforeLoad: function (sender, operation) {
        /// <summary>store加载事件</summary>
        if (null == operation.params) {
            operation.params = {};
        }
        operation.params.action = this._params.action;
        operation.params.start = operation.start == null ? 0 : operation.start;
        operation.params.pageIndex = operation.page;
        operation.params.limit = this._params.pageSize;
        operation.params.tableName = this._params.tableName;
        operation.params.fields = this._params.fields;
        operation.params.whereClause = this._params.whereClause;
        operation.params.sort = this._params.sort;
    },
    _CreateCM: function () {
        /// <summary>
        /// 创建列模型
        /// </summary>
        var record_start = 0,
            fieldsArray = [];
        fieldsArray.push({
            header: "序号",
            width: 48,
            align: 'center',
            menuDisabled: true,
            renderer: function (value, metadata, record, rowIndex) {
                return record_start + 1 + rowIndex;
            }
        });
        //fieldsArray.push(this._GetChkm());
        if (null != this._handleMenu && "" != this._handleMenu) {
            fieldsArray.push({
                header: "操作",
                width: this._handleMenuWidth,
                scope: this,
                columnLines: true,
                autoScroll: true,
                autoDestroy: true,
                align: 'center',
                sortable: false,
                menuDisabled: true,
                renderer: function (value, cm, record) {
                    return this._handleMenu(record.data);
                }
            })
        }
        for (var i = 0; i < this._fieldsArray.length; i++) {//循环生成列
            var tempCms = {
                menuDisabled: true,
                header: this._fieldsArray[i].lcname,
                dataIndex: this._fieldsArray[i].lename,
                width: this._fieldsArray[i].width,
                hidden: this._fieldsArray[i].hidden,
                id: this._fieldsArray[i].id,
                isAutoWidth: this._fieldsArray[i].isAutoWidth,
                isRender: this._fieldsArray[i].isRender,
                sortable: false
            };
            tempCms.renderer = Sp.Delegate(this, function (value, cm, record, rowIndex, comIndex, store) {
                if (cm.column.isAutoWidth) {//自动换行
                    cm.style = 'overflow:auto;padding: 3px 6px;text-overflow: ellipsis;white-space: nowrap;white-space:normal;line-height:20px;';
                }
                if (cm.column.isRender == true) {
                    var columnName = cm.column.dataIndex;
                    return this._initRender(value, columnName, record);
                } else {
                    return value;
                }
            })
            fieldsArray.push(tempCms)
        }
        return fieldsArray;
    },
    _CreateToolbar: function () {
        var tbar = [];
        if (null != this._preToolbarMenu) {//搜索和重置按钮后的控件
            for (var p = 0; p < this._preToolbarMenu.length; p++)
                tbar.push(this._preToolbarMenu[p]);
        }
        if (this._baseQueryBar == true) {
            tbar.push('关键字：', {
                xtype: 'textfield',
                width: this._searchTextWidth,
                id: this._tableDivID + 'txtKeyWord',
                emptyText: this._searchTextTip
            }, {
                iconCls: 'iconSearchCls',
                text: '搜索',
                handler: Sp.Delegate(this, function () {
                    this._BtnQuery();
                })
            }, {
                iconCls: 'iconResetCls',
                text: '重置',
                handler: Sp.Delegate(this, function () {
                    //重置搜索前的控件
                    if (null != this._preToolbarMenu) {
                        for (var r = 0; r < this._preToolbarMenu.length; r++) {
                            var objItem = Ext.getCmp(this._preToolbarMenu[r].id);
                            switch (this._preToolbarMenu[r].xtype) {
                                case "combobox":
                                    objItem.setValue(objItem.store.data.items[0].data.id);
                                    objItem.setRawValue(objItem.store.data.items[0].data.name);
                                    break;
                                case "datefield":
                                case "monthfield":
                                    objItem.reset();
                                    break;
                            }
                        }
                    }
                    //重置关键字输入框
                    var txtKeyWord = Ext.getCmp(this._tableDivID + "txtKeyWord");
                    if (txtKeyWord) {
                        txtKeyWord.setValue("");
                        this._BtnQuery();                  
                    }
                    //Sp.SpUtil.GetInstance().CloseMask();
                })
            });
        }
        if (null != this._toolbarMenu) {//搜索和重置按钮后的控件
            for (var k = 0; k < this._toolbarMenu.length; k++)
                tbar.push(this._toolbarMenu[k]);
        }
        return tbar;
    },
    _BtnQuery: function () {
        /// <summary>
        /// 查询
        /// </summary>
        var txtKeyWord = Ext.getCmp(this._tableDivID + "txtKeyWord");
        if (txtKeyWord) {
            //实现跨列搜索
            if (null == this._searchTextFields) {
                alert("未指明查询字段,暂不支持查询");
            }
            else {
                //判断是否执行外部查询条件组织函数
                var baseWhere = "";
                if (null != this._beforeQueryFun) {
                    baseWhere = this._beforeQueryFun();
                }
                //判断是否添加外部查询条件
                if (null != baseWhere && "" != baseWhere.trim()) {
                    this._params.whereClause = "where " + this._searchTextFields + " like '%" + txtKeyWord.getValue().trim() + "%' and " + baseWhere;
                }
                else {
                    this._params.whereClause = "where " + this._searchTextFields + " like '%" + txtKeyWord.getValue().trim() + "%'";
                }
                if (this._resultGrid) {
                    var store = this._resultGrid.GetStore();
                    store.currentPage = 1;
                    store.load();
                }
            }
        }
    },
    QueryExecute: function (strWhere) {
        /// <summary>
        /// 外部直接执行查询,从而刷新列表数据
        /// </summary>
        /// <param name="strWhere">不带Where关键字的查询条件</param>
        if (null != strWhere && "" != strWhere.trim()) {
            this._params.whereClause = "where " + strWhere;
        }
        else {
            this._params.whereClause = "";
        }
        if (this._resultGrid) {
            var store = this._resultGrid.GetStore();
            store.currentPage = 1;
            store.load();
        }
    },
    PageResize: function () {
        /// <summary>
        /// 页面大小控制
        /// </summary>
        if (this._resultGrid) {
            $("#middle_center").height($("#middle").height());
            this._resultGrid.SetWidth($("#middle_center").width());
            this._resultGrid.SetHeight($("#middle_center").height());
        }
    },
    GetResultGrid: function () {
        /// <summary>
        /// 返回对象
        /// </summary>
        return this._resultGrid;
    },

}
Sp.SpDialogResultGrid = Sp.extend(Sp.SpResultGrid, {
    constructor: function (objectParam, containerId) {
        if (null == containerId || "" == containerId) {
            alert("缺失containerId参数");
            return false;
        }
        else {
            objectParam._tableDivID = containerId; //此类必须传递containerId,用于呈载弹出框中的表格
        }
        Sp.SpResultGrid.superclass.constructor.apply(this, [objectParam]);
    }
});