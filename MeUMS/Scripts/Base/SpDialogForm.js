/********************************************************************************
** 作者： 
** 创始时间：2016-12-3
** 创建人：张青云
** 修改人：
** 修改时间：
** 描述：弹出框通用类（集成artDialog和Extjs Form）
*********************************************************************************/
Sp.SpDialogForm = function (config) {
    config = config == null ? {} : config;
    this._config = config;
    this._dialogForm = null; //弹出框对象
    this._formPanel = null; //extjs的FormPanel对象
    this._title = config.title == null ? "表单窗体" : config.title; //弹出框标题
    this._isDialog = config.isDialog == null ? true : config.isDialog; //是否为弹出框显示
    this._domId = config.domId == null ? null : config.domId;
    this._fieldsets = config.fieldsets; //以fieldset方式进行表单内容存储和初始化
    this._dialogButton = config.dialogButton == null ? [] : config.dialogButton; //弹出框下方的按钮（格式直接和artDialog的button属性一致）；
    this._formId = config.formId;
    this._width = config.width == null ? 500 : config.width;
    this._height = config.height == null ? 360 : config.height;
    this._isClose = config.isClose == null ? true : config.isClose; //true表示闭关,false表示不关闭（若点击某按钮想实现不关闭窗体，则可通过SetIsClose方法传参实现）
};
Sp.SpDialogForm.prototype = {
    //#region 公共方法
    Execute: function (type) {
        //this.Destroy();
        this._formPanel = Ext.getCmp('panel' + this._formId);
        if (null != this._formPanel) {
            this.Destroy();
        }
        var dialogFormConfig = null;
        var renderTo = null;
        if (this._isDialog) {
            dialogFormConfig = {
                title: this._title,
                padding: 0,
                content: "<div id='div" + this._formId + "' style='width:" + this._width + "px;height:" + this._height + "px;overflow-y:auto;overflow-x:hidden;'></div>",
                lock: true,
                fixed: true,
                drag: true,
                resize: false,
                close: Sp.Delegate(this, function () {
                    if (this._isClose) {
                        if (null != this._formPanel) {
                            //销毁对象
                            this._formPanel.destroy();
                            this._formPanel = null;
                        }
                        if (null != this._dialogForm) {
                            this._dialogForm = null;
                        }
                    }
                    else {
                        this._isClose = true; //点击后恢复到可以直接关闭状态
                        return false;
                    }
                })
            };

            //初始化弹出框下方按钮
            if (null != this._dialogButton && this._dialogButton.length > 0) {
                dialogFormConfig.button = this._dialogButton;
            }
            this._dialogForm = art.dialog(dialogFormConfig);
            renderTo = 'div' + this._formId;
        }
        else {
            renderTo = this._domId;
        }
        //初始化面板表单内容
        var formPanelConfig = {
            renderTo: renderTo,
            border: false,
            id: 'panel' + this._formId,
            bodyStyle: 'padding:12px',
            autoDestroy: true,
            defaultType: 'textfield',
            labelAlign: 'right',
            scope: this,
            frame: false,
            autoScroll: false,
            defaults: {
                labelStyle: 'margin:6px 0px 6px 0px',
                style: 'margin:6px 0px 6px 0px'
            },
            items: []
        };
        for (var f = 0; f < this._fieldsets.length; f++) {
            if (null == this._fieldsets[f].title) {
                this._fieldsets[f].title = "分组信息";
            }
            var fieldset = {
                xtype: 'fieldset',
                width: "100%",
                title: this._fieldsets[f].title,
                style: 'padding:0px 6px 6px 6px',
                layout: 'column', //解决横向并排的方法
                defaults: {
                    labelWidth: 90,
                    border: false
                },
                items: []
            };
            for (var k = 0; k < this._fieldsets[f].forms.length; k++) {
                if (null == this._fieldsets[f].forms[k].columnWidth) {
                    this._fieldsets[f].forms[k].columnWidth = 1;
                }
                var itemForm;
                if (null == this._fieldsets[f].forms[k].columnHeight) {//自动适应高度
                    itemForm = {
                        columnWidth: this._fieldsets[f].forms[k].columnWidth,
                        labelAlign: 'right',
                        layout: 'form',
                        items: this._fieldsets[f].forms[k].items
                    }
                }
                else {//固定高度
                    itemForm = {
                        columnWidth: this._fieldsets[f].forms[k].columnWidth,
                        labelAlign: 'right',
                        height: this._fieldsets[f].forms[k].columnHeight,
                        layout: 'form',
                        items: this._fieldsets[f].forms[k].items
                    }
                }
                fieldset.items.push(itemForm);
            }
            formPanelConfig.items.push(fieldset);
        }
        if (null == this._formPanel) {
            this._formPanel = new Ext.form.FormPanel(formPanelConfig);
            this._formPanel.show();
        }
    },
    SetIsClose: function (isClose) {
        /// <summary>
        /// 设置点击按钮是否关闭窗体
        /// </summary>
        /// <param name="isClose"></param>
        this._isClose = isClose;
    },
    Destroy: function () {
        /// <summary>
        /// 注销
        /// </summary>
        if (null != this._formPanel) {
            this._formPanel.destroy();
            this._formPanel = null;;
        }
        if (null != this._dialogForm) {
            this._dialogForm.close();
            this._dialogForm = null;
        }
    },
    GetFormPanel: function () {
        /// <summary>
        /// 获取表单FormPanel对象
        /// </summary>
        /// <returns type=""></returns>
        if (null != this._formPanel) {
            return this._formPanel;
        }
        else {
            alert("弹出窗口面板失效,请刷新后再试");
        }
    },
    GetDialogForm: function () {
        /// <summary>
        /// 获取表单DialogForm对象
        /// </summary>
        /// <returns type=""></returns>
        if (null != this._dialogForm) {
            return this._dialogForm;
        }
        else {
            alert("弹出窗口对象失效,请刷新后再试");
        }
    },
    SetFormWidth: function (width) {
        /// <summary>
        /// 设置FormPanel面板宽度
        /// </summary>
        /// <param name="width">宽度（数值）</param>
        if (null == this._formPanel) {
            alert("请先初始化表单对象!");
        }
        else {
            this._formPanel.setWidth(width);
        }
    },
    SetFormHight: function (height) {
        /// <summary>
        /// 设置FormPanel面板高度
        /// </summary>
        /// <param name="height">高度（数值）</param>
        if (null == this._formPanel) {
            alert("请先初始化表单对象!");
        }
        else {
            this._formPanel.setHeight(height);
        }
    },
    SetFormSize: function (width, height) {
        /// <summary>
        /// 设置FormPanel面板尺寸
        /// </summary>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        if (null == this._formPanel) {
            alert("请先初始化表单对象!");
        }
        else {
            this._formPanel.setSize(width, height);
        }
    },
    SetValues: function (data) {
        /// <summary>
        /// 设置表单数据值
        /// </summary>
        /// <param name="data">对象数组</param>
        if (null == this._formPanel) {
            alert("请先初始化表单对象!");
        }
        else {
            this._formPanel.getForm().setValues(data);
        }
    },
    GetValues: function () {
        /// <summary>
        /// 获取表单数据值
        /// </summary> 
        var result = {};
        if (null == this._formPanel) {
            alert("请先初始化表单对象!");
        }
        else {
            result = this._formPanel.getForm().getValues();
        }
        return result;
    },
    IsValid: function () {
        /// <summary>
        /// 判断表单是否满足输入要求
        /// </summary>
        var vResult = {};
        if (this._formPanel.getForm().isValid()) {
            vResult.isValid = true;
            vResult.msg = "验证通过";
        }
        else {
            var errorFieldLabel = [];
            var fields = this._formPanel.getForm().getFields().items;
            fields.forEach(function (b) {
                if (!b.validate()) {
                    errorFieldLabel.push("【" + b.fieldLabel + "】");
                }
            });
            vResult.isValid = false;
            vResult.msg = errorFieldLabel.join("、") + "输入不合法";
        }
        return vResult;
    }
    //#endregion
    //#region 私有方法

    //#endregion
}