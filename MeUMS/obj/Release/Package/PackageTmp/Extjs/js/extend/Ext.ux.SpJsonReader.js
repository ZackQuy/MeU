Ext.define('Ext.ux.SpJsonReader', {
    extend: 'Ext.data.JsonReader',
    read: function (response) {
        var json = response.responseText;
        var o = Ext.decode(json);
        var datas = {};
        if (!o) {
            throw { message: '返回值json字符串不满足要求！' };
        }
        if (!o.success) {
            //Ext.Msg.alert("温馨提示","网络链接异常,请检查网络");
            Sp.Msg.alert("网络链接异常,请检查网络", "warning");
            //throw { message: o.message };
        }
        datas.total = o.message.total;
        var dataArray = [];
        if (o.message.total > 0) {
            for (var i = 0; i < o.message.features.length; i++) {
                var mydata = {};
                for (var j = 0; j < o.message.columns.length; j++) {
                    mydata[o.message.columns[j].columnName] = o.message.features[i].attributes[j];
                }
                dataArray.push(mydata);
            }
        }
        else {
            //alert("没有符合条件的查询结果！");
        }
        datas.attributes = dataArray;
        return this.readRecords(datas);
    },
    constructor: function () {
        this.callParent(arguments);
    }
});