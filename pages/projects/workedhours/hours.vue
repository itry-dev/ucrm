<template>
    <div>
        <Feedback :feedback="feedback" :isErrMsg="isErrMsg" :isLoading="isLoading" />
        <WorkedHours
        v-if="!wasDeleted" 
        :workedHours="workedHours"
        @has-clicked-save-wh="saveWH"
        @has-clicked-del-wh="deleteWH" />
    </div>    
</template>
<script>
import WorkedHours from '@/components/project/WorkedHours.vue'
import c from '@/core/costants'

export default {
    name:'WorkedHoursPage'
    ,data(){
        return{
            id:''
            ,feedback:''
            ,isErrMsg:false
            ,isLoading:false
            ,wasDeleted:false
            ,workedHours:{
                id:''
                ,date:''
                ,hours:''
                ,hourlyRate:''
                ,atCustomerOffice:false
                ,additionalNotes:''
                ,projectId:''
                ,project:null
            }
        }
    }
    ,components:{
        WorkedHours
    }
    ,methods:{
        loadWorkedHours(id){
            this.isErrMsg=false
            this.isLoading=true

            this.$apiManager.getWorkedHoursById(id)
            .then((response) => {
                this.workedHours=response.data
                this.isLoading=false
                this.feedback=''
            })
            .catch(e => {
                this.isErrMsg=true
                this.feedback=this.$utils.getError(e)
            })
        }
        ,setEmptyObject(){
            this.workedHours.id=''
            this.workedHours.date=''
            this.workedHours.hours=''
            this.workedHours.hourlyRate=''
            this.workedHours.atCustomerOffice=false
            this.workedHours.additionalNotes=''
            this.workedHours.projectId=''
            this.workedHours.project=null            
        }
        ,saveWH(wh){
            this.isLoading=true
            
            this.$apiManager.modifyWorkedHours(wh)
            .then(response => {
                this.isErrMsg=false
                this.isLoading=false
                this.feedback='Data saved!'
            })
            .catch(e => {
                this.isErrMsg=true
                this.isLoading=false
                this.feedback=this.$utils.getError(e)
            })
        }
        ,deleteWH(id){
            this.isLoading=true

            this.$apiManager.deleteWorkedHours(id)
            .then(response => {
                this.isErrMsg=false
                this.wasDeleted=true
                this.isLoading=false
                this.feedback='Data deleted!'
            })
            .catch(e => {
                this.isErrMsg=true
                this.isLoading=false
                this.feedback=this.$utils.getError(e)
            })
        }
    }
    ,mounted(){
        if (this.$route.query.id){
            this.loadWorkedHours(this.$route.query.id)
        }

        if (this.$route.params && this.$route.params.selectedDate){
            this.workedHours.date=this.$route.params.selectedDate
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