<template>
    <div>
        <h1 class="table-heading">Instructors</h1>
        <form @submit="createInstructor">
            <table>
                <tr>
                    <th>First Name</th>
                    <td>
                        <input
                            type="text"
                            id="fName"
                            ref="firstName"
                            required
                        >
                    </td>
                </tr>
                <tr>
                    <th>Middle Initial</th>
                    <td>
                        <input
                            type="text"
                            id="middleInitial"
                            ref="middleInitial"
                            required
                        >
                    </td>
                </tr>
                <tr>
                    <th>Last Name</th>
                    <td>
                        <input
                            type="text"
                            id="lastName"
                            ref="lastName"
                            required
                        >
                    </td>
                </tr>
            </table>
            <button type="submit">Save</button>
        </form>
        <table class="bordered">
            <thead>
                <tr>
                    <th>First Name</th>
                    <th>Middle Initial</th>
                    <th>Last Name</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody id='table-body'>
                <tr v-for="instructor in instructors" v-bind:key="instructor.instructorId">
                    <td>{{ instructor.firstName }}</td>
                    <td>{{ instructor.middleInitial }}</td>
                    <td>{{ instructor.lastName }}</td>
                    <td>
                        <button 
                            @click="deleteInstructor(instructor.instructorId)"
                        >
                            Delete
                        </button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import Vue from 'vue';
export default {
    name: 'Instructors',
    data() {
        return {
            instructors: [],
            apiServer: process.env.VUE_APP_API_SERVER,
            apiUrl: null
        }
    },
    mounted() {
        this.apiUrl = `http://${this.apiServer}/api/instructor`;
        this.getInstructors();
    },
    methods: {
        getInstructors() {
            Vue.axios.get(this.apiUrl).then(res => {
                this.instructors = res.data;
            })
            .catch(err => {
                console.log(err);
            });
        },
        createInstructor(e) {
            e.preventDefault();

            let instructor = this.makeInstructor();
            
            Vue.axios.post(this.apiUrl, instructor).then(() => {
                this.getInstructors();
            })
            .catch(err => {
                console.log(err);
            })
        },
        deleteInstructor(id) {
            let url = `${this.apiUrl}/${id}`;
            Vue.axios.delete(url).then(() => {
                this.getInstructors();
            })
            .catch(err => {
                console.log(err);
            })
        },
        makeInstructor() {
            let instructor = {
                firstName: this.$refs.firstName.value,
                middleInitial: this.$refs.middleInitial.value,
                lastName: this.$refs.lastName.value
            };

            this.$refs.firstName.value = null;
            this.$refs.middleInitial.value = null;
            this.$refs.lastName.value = null;

            return instructor;
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
table.bordered td, table.bordered th {
    border-bottom: 1px solid black;
}
form {
    margin-top: 15px;
    margin-bottom: 15px;
}
</style>