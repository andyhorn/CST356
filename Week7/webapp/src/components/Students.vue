<template>
    <div>
        <h1 class="table-heading">Students</h1>
        <form @submit="createStudent">
            <table>
                <tr>
                    <th>Email Address</th>
                    <td>
                        <input
                            type="email"
                            ref="emailAddress"
                            required
                        >
                    </td>
                </tr>
            </table>
            <button type="submit">Add</button>
        </form>
        <table class="bordered">
            <thead>
                <tr>
                    <th>Student ID</th>
                    <th>Email Address</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody id="table-body">
                <tr v-for="student in students" v-bind:key="student.studentId">
                    <td>{{ student.studentId }}</td>
                    <td>{{ student.emailAddress }}</td>
                    <td><button @click="deleteStudent(student.studentId)">Delete</button></td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import Vue from "vue"
export default {
    name: 'Students',
    mounted() {
        this.apiUrl = `http://${this.apiServer}/api/student`
        this.getStudents();
    },
    data() {
        return {
            students: [],
            apiServer: process.env.VUE_APP_API_SERVER,
            apiUrl: null
        }
    },
    methods: {
        getStudents() {
            Vue.axios.get(this.apiUrl).then((res) => {
                console.log(res.data);
                this.students = res.data;
            }, err => {
                console.log(err);
            });
        },
        createStudent(e) {
            e.preventDefault();
            let emailAddress = this.$refs.emailAddress.value;
            this.$refs.emailAddress.value = null;

            Vue.axios.post(this.apiUrl, { emailAddress }).then(() => {
                this.getStudents();
            })
            .catch(err => {
                console.log(err);
            });
        },
        deleteStudent(id) {
            let url = `${this.apiUrl}/${id}`;
            Vue.axios.delete(url).then(() => {
                this.getStudents();
            })
            .catch(err => {
                console.log(err);
            });
        }
    }
}
</script>

<style scoped>
.table-heading {
    font-family: sans-serif;
    text-decoration: underline;
}
td, th {
    margin: 0;
    padding: 5px;
}
td {
    min-width: 100px;
}
form {
    padding-top: 15px;
    padding-bottom: 15px;
}
label {
    display: block;
}
table.bordered td, table.bordered th {
    border-bottom: 1px solid black;
}
</style>