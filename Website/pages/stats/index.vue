<template>
    <div>
        <h1>Annual incomings</h1>
        {{ report }}
    </div>
</template>
<script>
export default {
    name:'AnnualIncomgins'
    ,data(){
        return{
            report:null
        }
    }
    ,mounted(){
        this.$apiManager.getWorkedHoursReport(new Date().getFullYear())
        .then((response) => {            
            this.report = response.data
        })
        .catch(e => {
        })
    }
}
</script>