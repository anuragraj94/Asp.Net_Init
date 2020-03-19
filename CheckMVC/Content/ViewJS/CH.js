$(document).ready(function () {
    $("#loading").hide();
    //addTblHeader();
    //loop();
});
function fun() {
    var id = $("#ID").val();
    addTblHeader();
    loop();
    if ($("form")[0].checkValidity()) {
        //$.ajax({
        //    type: 'POST',
        //    url: '@Url.Action("tblData","Default")',
        //    data: { ID: id },
        //    dataType: 'json',
        //    success: function (data) {                
        //        //$.each(data, function (i, item) {
        //        //    //CreateLogTable();
        //        //    var rows = "<tr>"
        //        //        + "<td>" + item.OrderId + "</td>"
        //        //        + "<td>" + item.ShiftFrom + "</td>"
        //        //        + "<td>" + item.QuantityOrdered + "</td>"
        //        //        + "<td>" + item.ShiftTo + "</td>"
        //        //        + "<td>" + item.Capacity + "</td>"
        //        //        + "<td>" + item.QuantityInWarehouse + "</td>"
        //        //        + "</tr>";

        //        //    $('#tableData tbody').append(rows);

        //        //}); 
        //        alert("Success");
        //    },
        //    error: function (ex) {
        //        //var r = jQuery.parseJSON(response.responseText);
        //        //alert("Message: " + r.Message);
        //        //alert("StackTrace: " + r.StackTrace);
        //        //alert("ExceptionType: " + r.ExceptionType);
        //        alert("Error");
        //    }

        //});
        $.ajax({
            type: 'POST',
            cache: false,
            url: '/Default/tblData',
            dataType: 'json',
            data: {ID:id},
            error: function () {
                alert("error")
            },
            success: function (result) {
                alert("success")
            }
        });
    }
}

//function fun() {
//    var id = $("#ID").val();
//    $("#loading").show();
//    $.get('/Default/tblData?Id='+id+'', function (data) {
//        var res = data;
//        alert('Hey');
//        alert(res);
//        if (res != "") {
//            $('#tableData').empty();
//            addTblHeader();
//            for (var i = 0; i < res.length; i++) {
//                t = '<tr>';
//                t += '<td>' + (parseInt(i) + 1) + '</td>';
//                t += '<td>' + res[i].ShiftFrom + '</td>';
//                t += '<td>' + res[i].QuantityOrdered + '</td>';
//                t += '<td>' + res[i].ShiftTo + '</td>';
//                t += '<td>' + res[i].Capacity + '</td>';
//                t += '<td>' + res[i].QuantityInWarehouse + '</td>';                

//                //t += '<td><button type="button"  class="btn-link btn-action btn-edit" data-toggle="tooltip" data-placement="bottom" title="Edit!"> <i class="fa fa-edit"></i></button> <button type="button" class="btn-link btn-action btn-delete" data-toggle="tooltip" data-placement="bottom" title="Delete!"><i class="fa fa-trash-o"></i></button></td>';

//                t += '</tr>';
//                $('#tableData').append(t);
//            }
//            $("#loading").hide();
//        }
//        else {
//            ShowAlert("error", "Oops ! There is No Record for this Search", "error");
//            $('#tableData').empty();
//        }
//    });
//}

function CreateLogTable() {

    var rows = "<tr>"
        + "<td>" + item.OrderId + "</td>"
        + "<td>" + item.ShiftFrom + "</td>"
        + "<td>" + item.QuantityOrdered + "</td>"
        + "<td>" + item.ShiftTo + "</td>"
        + "<td>" + item.Capacity + "</td>"
        + "<td>" + item.QuantityInWarehouse + "</td>"        
        + "</tr>";

    $('#tableData tbody').append(rows);

}

function loop() {
    var i = 1;
    while (i <= 100) {
        Demo(i);
        i++;
    }
    i = 1;
}

function Demo(i) {

    var rows = "<tr>"
        + "<td>" + i + "</td>"
        + "<td>" + i + 1 + "</td>"
        + "<td>" + i + 2 + "</td>"
        + "<td>" + i + 3 + "</td>"
        + "<td>" + i + 4 + "</td>"
        + "<td>" + i + 5 + "</td>"
        + '<td><button type="button"  class="btn-link btn-action btn-edit" data-toggle="tooltip" data-placement="bottom" title="Edit!" onclick="Edit(' + i + ')"> <i class="fa fa-edit"></i></button> <button type="button" class="btn-link btn-action btn-delete" data-toggle="tooltip" data-placement="bottom" title="Delete!" onclick="Delete(' + i +')"><i class="fa fa-trash-o"></i></button></td>';
        + "</tr>";

    $('#tableData tbody').append(rows);

}

function Edit(i) {
    //alert("Edit "+i);
    $.get('/Default/Edit?Id='+i+'')
}

function Delete(i) {
    //alert("Delete " + i);
    $.get('/Default/Delete?Id=' + i + '')
}

function addTblHeader() {
    var tbl = '<table class="table table-bordered text-center" id="tableData">                                        <thead>                        <tr>                            <th scope="col">Order Id </th>                            <th scope="col">Shift From</th>                            <th scope="col">Quantity Ordered</th>                            <th scope="col">Shift To</th>                            <th scope="col">Capacity</th>                            <th scope="col">Quantity In Warehouse</th>     <th scope="col">Action</th>                        </tr>                    </thead><tbody></tbody>            </table> ';
    document.getElementById("dtbl").innerHTML = tbl;
}