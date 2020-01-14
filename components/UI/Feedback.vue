<template>
    <div 
        :class="{'d-none' : feedback==='', 'alert alert-danger' : isErrMsg, 'alert alert-success' : !isErrMsg}">
            <span v-html="feedback"></span>
        </div>
</template>
<script>
export default {
    name:'Feedback'
    ,props:{
        feedback:{
            type:String
            ,required:true
        }
        ,isErrMsg:{
            type:Boolean
            ,required:true
        }
    }
}
</script>