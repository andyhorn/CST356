<template>
    <div>
        <h1 class="table-heading">Instructors</h1>
        <table>
            <thead>
                <tr>
                    <th>First Name</th>
                    <th>Middle Initial</th>
                    <th>Last Name</th>
                </tr>
            </thead>
            <tbody id='table-body'>
                <tr v-for="instructor in instructors" v-bind:key="instructor">
                    <td>{{ instructor.firstName }}</td>
                    <td>{{ instructor.middleInitial }}</td>
                    <td>{{ instructor.lastName }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
export default {
    name: 'Instructors',
    data() {
        return {
            instructors: []
        }
    },
    mounted() {
        this.instructors = getInstructors()
    }
}

function getInstructors() {
    return JSON.parse(instructors)
}

var instructors = '[{"firstName": "John", "middleInitial": "A", "lastName": "Doe"}, {"firstName": "Jane", "middleInitial": "B", "lastName": "Doe"}, {"firstName": "Billy", "middleInitial": "B", "lastName": "Smith"}, {"firstName": "George", "middleInitial": "X", "lastName": "Jones"}, {"firstName": "Sarah", "middleInitial": "S", "lastName": "Smith"}]'
</script>

<style scoped>
.table-heading {
    font-family: sans-serif;
    text-decoration: underline;
}
td, th {
    margin: 0;
    padding: 5px;
    border-bottom: 1px solid black;
}

td {
    min-width: 100px;
}
</style>