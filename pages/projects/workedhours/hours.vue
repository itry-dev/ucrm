<template>
    <div>
        <div 
        :class="{'d-none' : feedback==='', 'alert alert-danger' : isErrMsg, 'alert alert-success' : !isErrMsg}">
            <span v-html="feedback"></span>
        </div>
        <WorkedHours
        v-if="notHasDeleted" 
        :workedHours="workedHours"
        @has-clicked-del-wh="deleteWH" />
    </div>    
</template>
<script>
import WorkedHours from '@/components/project/WorkedHours.vue'
import c from '@/core/costants'
/*import { mapGetters } from 'vuex'*/

export default {
    name:'WorkedHoursPage'
    /*,middleware:'workedhours'
     ,computed:{
        ...mapGetters(c.WORKED_HOURS_STORE,{
            workedHours:'getHour'
        })
    } */
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
    }
    ,methods:{
        loadWorkedHours(id){
            this.$axios.$get(`/workedhours/${id}`)
            .then((response) => {
                this.workedHours=response
            })
            .catch(e => {
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
        ,deleteWH(id){
            this.$axios.$delete(`/workedhours/${id}`)
            .then((response) => {
                this.isErrMsg=false
                this.notHasDeleted=false
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
    }    
    ,beforeRouteUpdate(to, from, next){
        if (!to.query.id){
            this.setEmptyObject()
        }
        next()
    }
}
</script>