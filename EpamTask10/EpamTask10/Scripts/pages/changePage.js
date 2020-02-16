$('#ToMain').click(function myfunction() {
    location.href = '/Pages/Index';
});


$('#ToUser').click(function myfunction() {
    location.href = '/Pages/User/Index';
});

$('#ToAward').click(function myfunction() {
    location.href = '/Pages/Award/Index';
});


$('#ToCreateAward').click(function myfunction() {
    location.href = '/Pages/Award/Create';
});

$('#ToDeleteAward').click(function myfunction() {
    location.href = '/Pages/Award/Delete';
});

$('#ToShowAward').click(function myfunction() {
    location.href = '/Pages/Award/Show';
});


$('#ToCreateUser').click(function myfunction() {
    location.href = '/Pages/User/Create';
});

$('#ToDeleteUser').click(function myfunction() {
    location.href = '/Pages/User/Delete';
});

$('#ToShowUser').click(function myfunction() {
    location.href = '/Pages/User/Show';
});

$('#SaveAwardEdit').click(function myfunction() {

});

$('#SaveUserEdit').click(function myfunction() {
    var checkBoxes = document.getElementsByClassName("AwardCheckbox");
    var checkedData;
    for (var i = 0; i < checkBoxes.length; i++) {
        checkedData[i] = $(".AwardCheckbox#"+i).is(":checked");

    }
});