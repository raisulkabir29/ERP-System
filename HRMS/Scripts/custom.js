
$("#btnPrint").live("click", function () {

    var divContents = $("#dvContainer").html();
    var printContents = divContents;
    var originalContents = document.body.innerHTML;
    document.body.innerHTML = printContents;
    window.focus();
    window.print();
   
    document.body.innerHTML = originalContents;
    window.location.href = window.location;


    /*var printWindow = window.open('', '', 'height=700,width=900');
    printWindow.document.write('<html><head>');
    printWindow.document.write('<link href="../../Content/theme/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />');
    printWindow.document.write('</head><body >');
    
    var divContents = $("#dvContainer").html();
    
    
    printWindow.document.write(divContents);
    printWindow.document.write('</body></html>');
    printWindow.document.close();
    printWindow.focus();
    printWindow.print();
    printWindow.close();*/



});