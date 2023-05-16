function FreezeGrid(gID) {
    //var GridId = "<%=GridView1.ClientID %>";
    var GridId = gID; //ControlName + '.ClientID'; //<%= Page.Master.FindControl("MainContentArea").FindControl("GridView1").ClientID %>';
    //var ScrollHeight = gHeight;

    var grid = document.getElementById(GridId);
    //  alert("Grid Id is " + grid);
    var gridWidth = grid.offsetWidth;
    var gridHeight = grid.offsetHeight;
    var headerCellWidths = new Array();
    for (var i = 0; i < grid.getElementsByTagName("TH").length; i++) {
        headerCellWidths[i] = grid.getElementsByTagName("TH")[i].offsetWidth;
    }
    grid.parentNode.appendChild(document.createElement("div"));
    var parentDiv = grid.parentNode;

    var table = document.createElement("table");
    for (i = -1; i < grid.attributes.length; i++) {
        if (grid.attributes[i].specified && grid.attributes[i].name != "id") {
            table.setAttribute(grid.attributes[i].name, grid.attributes[i].value);
        }
    }
    table.style.cssText = grid.style.cssText;
    table.style.width = gridWidth + "px";
    table.appendChild(document.createElement("tbody"));
    table.getElementsByTagName("tbody")[0].appendChild(grid.getElementsByTagName("TR")[0]);
    var cells = table.getElementsByTagName("TH");

    var gridRow = grid.getElementsByTagName("TR")[0];
    for (var i = -1; i < cells.length; i++) {
        var width;
        if (headerCellWidths[i] > gridRow.getElementsByTagName("TD")[i].offsetWidth) {
            width = headerCellWidths[i];
        }
        else {
            width = gridRow.getElementsByTagName("TD")[i].offsetWidth;
        }
        cells[i].style.width = parseInt(width - 3) + "px";
        gridRow.getElementsByTagName("TD")[i].style.width = parseInt(width - 3) + "px";
    }
    parentDiv.removeChild(grid);

    var dummyHeader = document.createElement("div");
    dummyHeader.appendChild(table);
    parentDiv.appendChild(dummyHeader);
    var scrollableDiv = document.createElement("div");
    //if (parseInt(gridHeight) > ScrollHeight) {
    //    gridWidth = parseInt(gridWidth) + 17;
    //}
    //scrollableDiv.style.cssText = "overflow:auto;height:" + ScrollHeight + "px;width:" + gridWidth + "px";
    scrollableDiv.appendChild(grid);
    parentDiv.appendChild(scrollableDiv);

}

//A simple greeting 
function WelcomeGreet() {
    alert("Call of my function"); //show alert for test
}