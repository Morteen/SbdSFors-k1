

    $(document).ready(function () {


        
    })
function ConfirmDelete(AtCourseId) {
    $("#hiddenApplicationId").val(AtCourseId);
    $("#deleteModal").modal("show");
}
//Sletter brukere ved kurs
function DeleteApplication() {
    $("#loaderDiv").show();
    var CorId = $("#hiddenApplicationId").val();

    $.ajax({
        type: "POST",
        url: "/Account/AtCourseDelete",
        data: { AtCourseId: CorId },
        success: function (result) {
            $("#loaderDiv").hide();
            $("#row_" + CorId).remove();
            $("#deleteModal").modal('hide');
        },
        error: function (xhr, status, error) {
            alert("En feil oppsto ved sletting - " + error);
            $("#loaderDiv").hide();
            $("#deleteModal").modal('hide');
        }
    })
}
