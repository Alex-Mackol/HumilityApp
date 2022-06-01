$(document).ready(function () {
    let buttonCreate = document.querySelector("#createButton");
    let formCreate = document.querySelector("#createForm");

    console.log(buttonCreate);
    console.log(formCreate);

    buttonCreate.addEventListener("click", () => {
        if (buttonCreate.classList.contains("js-active")) {
            buttonCreate.classList.remove("js-active");
            formCreate.classList.remove("open");
        } else {
            buttonCreate.classList.add("js-active");
            formCreate.classList.add("open");
        }
    });

    function checkValidDataForCreate(data) {
        let errorsList = [];
        if (!data.Price && isNaN(parseFloat(data.Price))){
            errorsList.push("Ціна не валідна!");
        }
        if (!data.Street || !isNaN(parseInt(data.Street))) {
            errorsList.push("Назва вулиці не правильна!");
        }
        if (!data.RoomsAmount && isNaN(parseInt(data.RoomsAmount))) {
            errorsList.push("Кількість комнат не валідна!");
        }
        if (!data.PeopleCount && isNaN(parseInt(data.PeopleCount))) {
            errorsList.push("Кількість комнат не валідне!");
        }

        return errorsList;
    }

    $('#btnSend').click(() => {

        let goPost = false;
        
        let data = {
            TypeOfHouse: $('#typeApart').val(),
            Price: $('#priceApart').val(),
            Street: $('#streetApart').val(), 
            RoomsAmount: $('#peopleAmountApart').val(), 
            PeopleCount: $('#roomsApart').val()
        };

        let errorList = checkValidDataForCreate(data);
        if (errorList.length == 0) {
            goPost = true;
        }
        else {
            alert("Errors list: " + errorList.join('\n'));
        }

        if (goPost) {
            $.post("/Apartament/Create",
                data,
                function(response) {
                    if (response.succeed) {
                        alert(`${response.message}`);
                        window.location.href = "/Apartament";
                    } else {
                        alert(`Error: ${response.message}`);
                    }
                });
        }
    });

    //Entity delete
    let btnDel = document.getElementsByClassName('js-btnDel');
    Array.from(btnDel).forEach(btn => {
        btn.addEventListener('click', function () {
            let entityId = $(this).data('entityid');
            $.post("/Apartament/Delete",
                { id: entityId },
                function (response) {
                    if (response.succeed) {
                        window.location.href = "/Apartament";
                    } else {
                        alert(`Error: ${response.message}`);
                    }
                });
        });
    });

});