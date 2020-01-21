<template>
    <div>
        <div class="panel panel-danger" v-if="message !== null">
        {{message}}
        </div>
        <h2>Projects</h2>
        <table class="table">
        <thead>
            <tr>
            <th scope="col">Name</th>
            <th scope="col">Total Amount</th>
            <th scope="col">Hourly Rate</th>
            <th scope="col">Start</th>
            <th scope="col">End</th>
            <th scope="col">&nbsp;</th>
            </tr>
        </thead>
            <tbody
            v-if="projects.length > 0">
            <tr 
            v-for="project in projects"
            :key="project.id">
                <td>{{project.name}}</td>
                <td>{{project.totalAmount}}</td>
                <td>{{project.hourlyRate}}</td>
                <td>{{project.startDate}}</td>
                <td>{{project.endDate}}</td>
                <td>
                    <nuxt-link :to="`/projects/project?id=${project.id}`">edit</nuxt-link>
                </td>
            </tr>
            </tbody>
        </table>
  </div>
</template>
<script>

export default {
    name:'ProjectsList'
    ,data(){
        return{
            message:null,
            projects:[]
        }
    }
    ,mounted(){

        this.$apiManager.getProjects()
        .then((response) => {            
            this.projects=response.data
        })
        .catch((e) => {
            this.message=this.$utils.getError(e)
        })
    }
}
</script>