<template>
    <div>

        <Feedback :feedback="feedback" :isErrMsg="isErrMsg" :isLoading="isLoading" />

        <h2>Projects</h2>
        <table class="table">
        <thead>
            <tr>
            <th scope="col">Customer</th>
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
                <td>{{project.customer.companyName}}</td>
                <td>{{project.name}}</td>
                <td>{{project.totalAmount}}</td>
                <td>{{project.hourlyRate}}</td>
                <td>{{project.startDate}}</td>
                <td>{{project.endDate}}</td>
                <td>
                    <nuxt-link :to="`/projects/project?id=${project.id}`">
                    <i class="material-icons">create</i>
                    </nuxt-link>
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
            feedback:null,
            isErrMsg:false,
            isLoading:false,
            projects:[]
        }
    }
    ,mounted(){
        this.isLoading=true

        this.$apiManager.getProjects()
        .then((response) => {            
            this.projects=response.data
            this.isLoading=false
            this.feedback=''            
        })
        .catch((e) => {
            this.isLoading=false
            this.isErrMsg=true
            this.feedback=this.$utils.getError(e)
        })
    }
}
</script>