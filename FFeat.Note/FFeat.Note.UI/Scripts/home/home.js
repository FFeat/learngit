$(function () {
    //点击Note按钮
    $("#note").click(function () {
        //清空重复点击下的列表
        $(" tbody").empty();
        $("#PagingNavigation0").empty();
        $("#PagingNavigation1").empty();
        $("#PagingNavigation2").empty();
        $("#PagingNavigation3").empty();
        //获取note信息
        GetAllNote();
    });

    //点击tr行事件，请求对应ID的noteInfo
    $("tbody").on("click", "tr", function () {


        var Id = $(this).attr("id");
        $.post("/Home/GetNoteInfoById", { Id: Id }, function (json) {
            //加载noteInfo
            GetNoteInfo(json);
        });
        $('.bgPop,.pop').show();

    });

    //绑定C#基础的分页导航点击事件，并且显示界面
    $("#PagingNavigation0").on("click", ".pageLink", function () {

        var pageIndex = $(this).attr("pageIndex");
        var pageSize = $(this).attr("pageSize");
        //清空重复点击下的列表
        $("#BasicTable tbody").empty();
        $("#PagingNavigation0").empty();
        $.post("/Home/GetAllBasicNote", { pageIndex: pageIndex, pageSize: pageSize }, function (json) {
            CreateTable(json, 0);
        });

    });
    //绑定Winform的分页导航点击事件，并且显示界面
    $("#PagingNavigation1").on("click", ".pageLink", function () {

        var pageIndex = $(this).attr("pageIndex");
        var pageSize = $(this).attr("pageSize");
        //清空重复点击下的列表
        $("#winformTable tbody").empty();
        $("#PagingNavigation1").empty();
        $.post("/Home/GetAllWinformNote", { pageIndex: pageIndex, pageSize: pageSize }, function (json) {
            CreateTable(json, 1);
        });

    });
    //绑定Webform的分页导航点击事件，并且显示界面
    $("#PagingNavigation2").on("click", ".pageLink", function () {

        var pageIndex = $(this).attr("pageIndex");
        var pageSize = $(this).attr("pageSize");
        //清空重复点击下的列表
        $("#webformTable tbody").empty();
        $("#PagingNavigation2").empty();
        $.post("/Home/GetAllWebformNote", { pageIndex: pageIndex, pageSize: pageSize }, function (json) {
            CreateTable(json, 2);
        });

    });
    //绑定Aspmvc的分页导航点击事件，并且显示界面
    $("#PagingNavigation3").on("click", ".pageLink", function () {

        var pageIndex = $(this).attr("pageIndex");
        var pageSize = $(this).attr("pageSize");
        //清空重复点击下的列表
        $("#mvcTable tbody").empty();
        $("#PagingNavigation3").empty();
        $.post("/Home/GetAllAspmvcNote", { pageIndex: pageIndex, pageSize: pageSize }, function (json) {
            CreateTable(json, 3);
        });

    });
    //按esc键关闭弹窗
    $(document).keyup(function (e) {
        var key = e.which;
        if (key == 27) {
            $('.bgPop,.pop').hide();
        }
    })
    //点击图标关闭弹窗
    $('.pop-close').click(function () {
        $('.bgPop,.pop').hide();
    });




});
//加载笔记详情信息
function GetNoteInfo(data) {

    var title = data.NoteName;
    var content = data.SubContent;
    var subTime = eval(data.SubTime.replace(/\/Date\((\d+)\)\//gi, "new Date($1)")).pattern("yyyy-MM-dd hh:mm:ss")
    $("#title").text(title);
    $("#subTimeSpan").text(subTime);
    $("#contentSpan").html(content);

}


//加载所有笔记信息的列表
function GetAllNote() {
    $.getJSON("/Home/GetAllBasicNote", {}, function (json) {
        CreateTable(json, 0);
    });
    $.get("/Home/GetAllWinformNote", {}, function (json) {
        CreateTable(json, 1);
    });
    $.get("/Home/GetAllWebformNote", {}, function (json) {
        CreateTable(json, 2);
    });
    $.get("/Home/GetAllAspmvcNote", {}, function (json) {
        CreateTable(json, 3);
    });
}
//初始化表格
function CreateTable(data, identifying) {
    var pagingStr = data.pagingString;
    switch (identifying) {

        case 0: $("#PagingNavigation0").append(pagingStr);

            break;
        case 1: $("#PagingNavigation1").append(pagingStr);
            break;
        case 2: $("#PagingNavigation2").append(pagingStr);
            break;
        case 3: $("#PagingNavigation3").append(pagingStr);

            break;
    }
    for (var i in data.rows) {
        var num = Number(i) + 1;
        var id = data.rows[i].Id;
        var time = eval(data.rows[i].SubTime.replace(/\/Date\((\d+)\)\//gi, "new Date($1)")).pattern("yyyy-MM-dd hh:mm:ss");
        var strTr = "<tr class='change' id=" + id + "><td>" + num + "</td><td>" + data.rows[i].NoteName + "</td><td>" + time + "</td></tr>";

        switch (identifying) {
            case 0: $("#BasicTable tbody").append(strTr);
                break;
            case 1: $("#winformTable tbody").append(strTr);
                break;
            case 2: $("#webformTable tbody").append(strTr);
                break;
            case 3: $("#mvcTable tbody").append(strTr);

                break;

        }

    }
}