document.addEventListener('DOMContentLoaded', function () {
    var sortOrder = "asc";
    function toggleSortOrder() {
        if (sortOrder === "asc") {
            sortOrder = "desc";
        } else {
            sortOrder = "asc";
        }
    }
    $("#finishedDate").click(function () {

        sortTable(0);
    });

    $("#category").click(function () {

        sortTable(1);
    });

    $("#user-full-name").click(function () {

        sortTable(2);
    });




    $("#questionCount").click(function () {

        sortTable(3);
    });
    $("#score").click(function () {

        sortTable(4);
    });

    function sortTable(index) {
        toggleSortOrder();
        var tableBody = $("tbody");
        var rows = tableBody.children();
        rows.sort(function (a, b) {
            var valueA = $(a).find("td:eq(" + index + ")").text();
            //var valueB = $(b).find("td:eq("+index+")").text();
            var valueB = $(b).find(`td:eq(${index})`).text();
            if (sortOrder === "asc") {
                return valueA.localeCompare(valueB);
            } else {
                return valueB.localeCompare(valueA);
            }
        });
        tableBody.html(rows);
    }
});