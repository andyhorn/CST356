var students = '{"students": [{"id": "123456789", "email": "john.doe@oit.edu"}, {"id": "987654321", "email": "jane.doe@oit.edu"}, {"id": "2468101214", "email": "jon.snow@oit.edu"}]}'

function getStudents() {
    return JSON.parse(students)
}

function loadStudents() {
    var data = getStudents()
    displayStudents(data.students)
}

function displayStudents(list) {
    var tableHtml = ""

    for (var i = 0; i < list.length; i++) {
        let id = list[i].id
        let email = list[i].email

        tableHtml += `<tr><td>${id}</td><td>${email}</td></tr>`
    }

    document.getElementById('table-body').innerHTML = tableHtml
}