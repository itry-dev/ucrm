<template>
    <div v-if="!isLoading"
        :class="{'d-none' : feedback==='', 'alert alert-danger' : isErrMsg, 'alert alert-success' : !isErrMsg}">
            <span v-html="feedback"></span>
    </div>
    <div v-else
        :class="{'d-none':!isLoading, 'progress': isLoading}">
            <div class="progress-bar progress-bar-striped bg-danger" role="progressbar" style="width: 100%" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100"></div>
        </div>
</template>
<script>
export default {
    name:'Feedback'
    ,props:{
        feedback:{
            type:String
            ,required:false
        }
        ,isErrMsg:{
            type:Boolean
            ,required:false
        }
        ,isLoading:{
            type:Boolean
            ,required:false
        }
    }
}
</script>