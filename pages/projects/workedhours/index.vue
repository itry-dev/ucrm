<template>
<div>
    <Feedback :feedback="feedback" :isErrMsg="isErrMsg" :isLoading="isLoading" />

    <full-calendar 
    :events="workedHours"
    @has-clicked-date="hasClickedDate"
    @has-clicked-workedhours="hasClickedWorkedHours" />
</div>
</template>
<script>
import c from '@/core/costants'
import Feedback from '@/components/UI/Feedback.vue'

export default {
    name:'WorkedHoursList'
    ,data(){
        return{
            message:null
            ,results:[]
            ,workedHours:[]
            ,feedback:''
            ,isErrMsg:false
            ,isLoading:false
        }
    }
    ,components:{
        Feedback
    }
    ,mounted(){
        var clazz=this
        clazz.isLoading=true

        this.$axios.$get('/workedhours')
        .then((response) => {

            response.forEach(function(el) {
                clazz.workedHours.push(
                    {
                        title:el.project.customer.companyName.substring(0,5).toUpperCase()+': '+el.hours
                        ,start:el.date
                        ,end:el.date
                        ,whId:el.id
                        /*,color: ...*/
                    })
            })

            clazz.isLoading=false
        })
        .catch((e) => {
            clazz.isLoading=false
            clazz.isErrMsg=true
            clazz.feedback=this.$utils.getError(e)
        })
    }
    ,methods:{
        hasClickedDate(arg){
            this.$router.push({name:'projects-workedhours-hours', params: { selectedDate:arg}})
        }
        ,hasClickedWorkedHours(e){
            this.$router.push(`${c.URLS.TO_ADD_WORKEDHOURS}?id=${e}`)
        }
    }
}
</script>