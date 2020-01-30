var instructors = '{"instructors": [{"firstName": "John", "middleInitial": "A", "lastName": "Doe"}, {"firstName": "Jane", "middleInitial": "B", "lastName": "Doe"}, {"firstName": "Billy", "middleInitial": "B", "lastName": "Smith"}, {"firstName": "George", "middleInitial": "X", "lastName": "Jones"}, {"firstName": "Sarah", "middleInitial": "S", "lastName": "Smith"}]}'

function getJson() {
    return JSON.parse(instructors)
}

function loadInstructors() {
    var data = getJson()
    displayInstructors(data.instructors)
}

function displayInstructors(list) {
    let tableHtml = ""

    for (let i = 0; i < list.length; i++) {
        let firstName = list[i].firstName
        let middleInitial = list[i].middleInitial
        let lastName = list[i].lastName

        tableHtml += `<tr><td>${firstName}</td><td>${middleInitial}</td><td>${lastName}</td></tr>`
    }

    document.getElementById('table-body').innerHTML = tableHtml
}