$(document).ready(function () {
    var updateResources = function () {
        updateResource("Clay");
        updateResource("Wheat");
        updateResource("Wood");
        updateResource("Iron");
    };
    var updateResource = function (resourcename) {
        var start = new Date();
        var currentProduction = 0;
        var currentValue = parseFloat($(".res-value." + resourcename).text());
        var lastUpdate = Date.parse($(".res-update." + resourcename).text());
        //console.log(currentValue);
        var mines = $(".mines").find("." + resourcename);
        $.each(mines, function (index, value) {
            currentProduction += parseInt($(value).find(".hourProduction").text());
            console.log(currentProduction);
        })
        var nextValue = (currentValue + ((start.getTime() - lastUpdate) / 1000 / 60 / 60) * currentProduction).toFixed(4);
        $(".res-value." + resourcename).text(nextValue);
        $(".res-value." + resourcename).text(start.strftime("%Y-%m-%d %H:%M:%S"));
    };
    setInterval(updateResources, 500);
})