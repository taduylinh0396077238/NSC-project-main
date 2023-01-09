
var ddl = document.getElementById('city');
var link = document.getElementById('ticketTheater');
console.log(ddl)
console.log(link)

ddl.addEventListener('change', function () {

    console.log(link)
    var selectedValue = ddl.options[ddl.selectedIndex].value;  // get selected value
    link.href = link.href + '?theaterId=' + selectedValue;              // update link href

    link.innerText = link.href;  // dont include this, this just shows the url text
});
