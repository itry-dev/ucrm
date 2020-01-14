<template>
    <full-calendar 
    :events="workedHours"
    @has-clicked-date="hasClickedDate"
    @has-clicked-workedhours="hasClickedWorkedHours" />
</template>
<script>
import c from '@/core/costants'

export default {
    name:'WorkedHoursList'
    ,data(){
        return{
            message:null,
            results:[],
            workedHours:[]
        }
    }
    ,mounted(){
        var clazz=this
        return this.$axios.$get('/workedhours')
        .then((response) => {

            response.forEach(function(el) {
                clazz.workedHours.push({title:el.hours, date:el.date, whId:el.id})
            })

        })
        .catch(e => {
            throw e
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