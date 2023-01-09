function checkChecked(arr) {
    arr.forEach((item) => {
        if (item.checked === true) {
            item.parentNode.classList.add("active");
        }
    });
}

function addActiveCheck(arr) {
    checkChecked(arr);
    if (arr.length > 0) {
        arr.forEach((item) => {
            item.addEventListener("change", (e) => {
                if (e.target.checked === true) {
                    e.target.parentNode.classList.add("active");
                } else {
                    e.target.parentNode.classList.remove("active");
                }
            });
        });

    }
}

function addActiveRadio(arr) {
    checkChecked(arr);
    if (arr.length > 0) {
        arr.forEach((item) => {
            item.addEventListener("click", (e) => {
                arr.forEach((item) => {
                    item.parentNode.classList.remove("active");
                });
                if (e.target.checked === true) {
                    e.target.parentNode.classList.add("active");
                }
            });
        });
    }
}

const inputCheck = document.querySelectorAll(".seat-ticket-item input");
addActiveCheck(inputCheck);

const cityItem = document.querySelectorAll(".city-item label input");
addActiveRadio(cityItem);

const roomItem = document.querySelectorAll(".time-room-list label input");
addActiveRadio(roomItem);

const itemDate = document.querySelectorAll(".ticket-date label input");
addActiveRadio(itemDate);