<template>
<div>
    <Feedback :feedback="feedback" :isErrMsg="isErrMsg" :isLoading="isLoading" />

    <Project 
    :project="project"
    @has-clicked-save-project="saveProject" />   
</div>
</template>
<script>
import Feedback from '@/components/UI/Feedback.vue'
import Project from '@/components/project/Project.vue'
import c from '@/core/costants'

export default {
    name:'ProjectPage'
    ,data(){
        return {
            project:{}
            ,feedback:''
            ,isErrMsg:false
            ,isLoading:false
        }
    }
    ,components:{
        Project
        ,Feedback
    }
    ,methods:{
        loadProject(id){
            this.$axios.$get(`/projects/${id}`)
            .then((response) => {
                this.project=response
            })
            .catch(e => {
                this.feedback = this.$utils.getError(e)
                this.isErrMsg=true
            })
        }
        ,setEmptyObject(){
            this.project.id=''
            this.project.name=''
            this.project.startDate=''
            this.project.endDate=''
            this.project.totalAmount=''
            this.project.additionalNotes=''
            this.project.hourlyRate=''
            this.project.customer=null        
        }
        ,saveProject(project){
            if (project && project.id !== ''){
                this.$axios.$put(`/projects/${project.id}`
                ,project)
                .then(response => {
                    this.isLoading=false
                    this.isErrMsg=false
                    this.feedback='New Project added!'
                })
                .catch(e => {
                    this.isLoading=false
                    this.isErrMsg=true
                    this.feedback=this.$utils.getError(e)
                })
            }else{
                this.$axios.$post(`/projects`
                ,project)
                .then(response => {
                    this.isLoading=false
                    this.isErrMsg=false
                    this.feedback='Project updated!'
                })
                .catch(e => {
                    this.isLoading=false
                    this.isErrMsg=true
                    this.feedback=this.$utils.getError(e)
                })

            }
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