var myDialog = null;
// 提示框 
function showMessage(title, content, width, height, isSuccess, okFun) {
    var icon = "error";

    if (isSuccess) {
        icon = "succeed";
    }

    myDialog = art.dialog({
        title: title,
        content: content,
        icon: icon,
        lock: true,
        ok: okFun,
        okVal: "确定",
        width: width,
        height: height,
        show: true
    });

    return false;
}

//弹出框打开页面
function OpenPage(url, title, width, height) {
    var cont = "<iframe width='" + width + "' height='" + height + ";' scrolling='no' frameborder='0' src='" + url + "'></iframe>";
    myDialog = art.dialog({
        title: title,
        content: cont,
        lock: false,
        width: width,
        height: height,
        show: true
    });

    return false;
}

//确认框
function OpenConfirm(title, content, width, height, okFun) {
    myDialog = art.dialog({
        title: title,
        content: content,
        icon: "question",
        lock: true,
        width: width,
        height: height,
        show: true, 
        okVal: "确定",
        cancelVal: "取消",
        cancel: true,
        ok: okFun
        
    });

    return false;
}

//关闭弹出框
function closeDialog() {
    var parentDialog = window.parent.myDialog;
    if (parentDialog) {
        parentDialog.close();
        return true;
    }
}

//特殊字符过来
function InputCheck(value) {
    var pattern = new RegExp("[\ ,\。,\`,\~,\!,\@,\#,\$,\%,\^,\+,\*,\&,\\,\/,\?,\|,\:,\.,\<,\>,\{,\},\(,\),\'',\;,\=,\",]"); 
    var res = pattern.test(value);
    if (res) {
        return true;
    } else {
        return false;
    } 
}

//表单 文本框特殊字符验证
function FormCheck(formId) {
    var checkResult = 0;
    $("#" + formId + " :text").each(function () {
        var val = $(this).val();
        if (val) {
            var res = InputCheck(val);
            if (res) {
                checkResult += 1;
            }
        }
    });

    if (checkResult > 0) {
        //showMessage("系统提示", "系统检测到特殊字符,请检查并重新输入!", 350, 100, false, true);
        return false;
    } else {
        return true;
    }
}
  
 