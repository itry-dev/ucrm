<template>
    <div>
        <Feedback :feedback="feedback" :isErrMsg="isErrMsg" />
        <WorkedHours
        v-if="notHasDeleted" 
        :workedHours="workedHours"
        @has-clicked-save-wh="saveWH"
        @has-clicked-del-wh="deleteWH" />
    </div>    
</template>
<script>
import WorkedHours from '@/components/project/WorkedHours.vue'
import Feedback from '@/components/UI/Feedback.vue'
import c from '@/core/costants'

export default {
    name:'WorkedHoursPage'
    ,data(){
        return{
            id:''
            ,feedback:''
            ,isErrMsg:false
            ,notHasDeleted:true
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
        ,Feedback
    }
    ,methods:{
        loadWorkedHours(id){
            this.isErrMsg=false
            this.feedback='loading data'

            this.$axios.$get(`/workedhours/${id}`)
            .then((response) => {
                this.workedHours=response
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
            if (this.workedHours && this.workedHours.id !== ''){
                this.$axios.$put(`/workedhours/${this.workedHours.id}`
                ,this.workedHours)
                .then(response => {
                    this.isErrMsg=false
                    this.feedback=response
                })
                .catch(e => {
                    this.isErrMsg=true
                    this.feedback=this.$utils.getError(e)
                })
            }else{
                const newWh = Object.assign({}, this.workedHours);
                delete newWh.id;

                this.$axios.$post('/workedhours'
                ,newWh)
                .then(response => {
                    this.isErrMsg=false
                    this.feedback=response
                })
                .catch(e => {
                    this.isErrMsg=true
                    this.feedback=this.$utils.getError(e)
                })

            }
        }
        ,deleteWH(id){
            this.$axios.$delete(`/workedhours/${id}`)
            .then((response) => {
                this.isErrMsg=false
                this.feedback='Workedhours deleted'
            })
            .catch(e => {
                this.isErrMsg=true
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