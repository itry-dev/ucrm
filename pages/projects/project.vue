<template>
<div>
    <Feedback :feedback="feedback" :isErrMsg="isErrMsg" />
    <Project :project="project" />   
</div>
</template>
<script>
import Feedback from '@/components/UI/Feedback.vue'
import Project from '@/components/project/Project.vue'
import c from '@/core/costants'

export default {
    name:'CustomerPage'
    ,data(){
        return {
            project:null
            ,feedback:''
            ,isErrMsg:false
        }
    }
    ,components:{
        Project
        ,Feedback
    }
    ,methods:{
        loadProject(id){
            return this.$axios.$get(`/projects/${id}`)
            .then((response) => {
                project=response
            })
            .catch(e => {
                feedback = this.$utils.getError(e)
                this.isErrMsg=true
            })
        }
        ,setEmptyObject(){
            this.project.id=''
            // this.project.date=''
            // this.project.hours=''
            // this.project.hourlyRate=''
            // this.project.atCustomerOffice=false
            // this.project.additionalNotes=''
            // this.project.projectId=''
            // this.project.project=null            
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