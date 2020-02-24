<template>
<div>
    <Feedback :feedback="feedback" :isErrMsg="isErrMsg" :isLoading="isLoading" />

    <Project 
    :project="project"
    @has-clicked-save-project="saveProject"
    @on-error="catchError" />   
</div>
</template>
<script>
import Project from '@/components/project/Project.vue'

export default {
    name:'ProjectPage'
    ,data(){
        return {
            project:{
                id:'',
                name:'',
                startDate:'',
                endDate:'',
                totalAmount:0,
                additionalNotes:'',
                hourlyRate:0,
                customerId:'',
                customer:{}
            }
            ,feedback:''
            ,isErrMsg:false
            ,isLoading:false
        }
    }
    ,components:{
        Project
    }
    ,methods:{
        loadProject(id){
            this.$apiManager.getProject(id)
            .then((response) => {
                this.project=response.data
            })
            .catch(e => {
                this.feedback = this.$utils.getError(e)
                this.isErrMsg=true
            })
        }
        ,setEmptyObject(){
            this.project=null
        }
        ,saveProject(project){
            this.isLoading=true
            this.isErrMsg=false
            this.feedback=''

            var prj =
            {
                id: project.id,
                name: project.name,
                startDate: project.startDate,
                endDate: project.endDate,
                totalAmount: project.totalAmount,
                hourlyRate: project.hourlyRate,
                additionalNotes: project.additionalNotes,
                customerId: project.customerId
            }
            
            this.$apiManager.modifyProject(prj)
            .then(response => {
                this.isLoading=false
                this.isErrMsg=false
                this.feedback='Project saved!'
            })
            .catch(e => {
                this.isLoading=false
                this.isErrMsg=true
                this.feedback=this.$utils.getError(e)
            })
        }
        ,catchError(error){
            this.isLoading=false
            this.isErrMsg=true
            this.feedback=error
        }
    }
    ,mounted(){
        if (this.$route.query.id){
            this.loadProject(this.$route.query.id)
        }
    } 
    ,beforeRouteUpdate(to, from, next){
        if (!to.query.id){
            this.setEmptyObject()
        }
        next()
    }
}
</script>