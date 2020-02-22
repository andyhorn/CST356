<template>
    <div>
        <h1 class="table-heading">Students</h1>
        <table>
            <thead>
                <tr>
                    <th>Student ID</th>
                    <th>Email Address</th>
                </tr>
            </thead>
            <tbody id="table-body">
                <tr v-for="student in students" v-bind:key="student">
                    <td>{{ student.id }}</td>
                    <td>{{ student.email }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
export default {
    name: 'Students',
    mounted() {
        this.students = getStudents()
    },
    data() {
        return {
            students: []
        }
    }
}

function getStudents() {
    return JSON.parse(students)
}

var students = '[{"id": "123456789", "email": "john.doe@oit.edu"}, {"id": "987654321", "email": "jane.doe@oit.edu"}, {"id": "2468101214", "email": "jon.snow@oit.edu"}]'
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