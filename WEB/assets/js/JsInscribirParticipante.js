$(document).ready(function () {
    $('#cbParticipa').change(function () {
        var rbSelected1 = $("#<%= RbNovel.ClientID %>").is(":checked"); 
        var rbSelected2 = $("#<%= RbAmbos.ClientID %>").is(":checked"); 
        if (rbSelected1) {
            var PS = $("#lblprecioS").text();
            var PN = $("#lblprecioN").text();
            console.log(PS);
            console.log(PN);
            var sum = PS + PN;
            document.getElementById("H1").innerHTML = "S/."+sum;

        }
        else if (rbSelected2){
            
            var PS = $("#lblprecioS").text();
            var PN = $("#lblprecioN").text();
            console.log(PS);
            console.log(PN);
            var sum = PS + PN + PS;
            document.getElementById("H1").innerHTML = "S/." + sum;
        }
    });
}); 