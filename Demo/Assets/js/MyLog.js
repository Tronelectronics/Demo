var city = "";
var country = "";
var description = "";
var district = "";
var ip = "";
var isp = "";
var province = "";
var type = "";

window.onbeforeunload = onbeforeunload_handler;
window.onunload = onunload_handler;

function addLog(async, remark) {
    debugger;
    var clientInformation = new Browser();

    var clientInformationString =
        "浏览器:" + clientInformation.browser + "," +
        "版本:" + clientInformation.version + "," +
        "内核:" + clientInformation.engine + "," +
        "操作系统:" + clientInformation.os + ' ' + clientInformation.osVersion + "," +
        "设备:" + clientInformation.device + "," +
        "语言:" + clientInformation.language + "."

    var log = {
        "City": city,
        "ClientInformation": clientInformationString,
        "Country": country,
        "Description": description,
        "District": district,
        "Id": "00000000-0000-0000-0000-000000000000",
        "Ip": ip,
        "Isp": isp,
        "Province": province,
        "Remark": remark,
        "Time": "1900-01-01 00:00:00",
        "Type": type
    };

    $.ajax({
        async: async,
        contentType: "application/json",
        data: JSON.stringify(log),
        type: "POST",
        url: "api/Logs/",
        success: function (msg) {
            //alert(JSON.stringify(msg));
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(errorThrown);
            alert(XMLHttpRequest.readyState);
            alert(XMLHttpRequest.status);
            alert(XMLHttpRequest.statusText);
            alert(textStatus);
        },
        complete: function (XMLHttpRequest, textStatus) {

        }
    });
}

function callSinaAPI(async, logMessage) {
    debugger;
    $.getScript('http://int.dpool.sina.com.cn/iplookup/iplookup.php?format=js', function () {
        debugger;
        city = remote_ip_info.city;
        country = remote_ip_info.country;
        description = remote_ip_info.desc;
        district = remote_ip_info.district;
        isp = remote_ip_info.isp;
        province = remote_ip_info.province;
        type = remote_ip_info.type;

        addLog(async, logMessage);
    });
}

function callSohuAPI(async, logMessage) {
    debugger;
    $.getScript('http://pv.sohu.com/cityjson', function () {
        debugger;
        ip = returnCitySN.cip;

        callSinaAPI(async, logMessage);
    });
}

function log(async, logMessage) {
    debugger;
    callSohuAPI(async, logMessage);
}

function onbeforeunload_handler() {
    debugger;
    addLog(false, "Url:" + window.location.href + ",Function:onbeforeunload.");
}

function onunload_handler() {
    debugger;
    addLog(false, "Url:" + window.location.href + ",Function:onunload.");
}