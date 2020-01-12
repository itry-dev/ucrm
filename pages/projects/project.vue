<template>
    <Project :project="project" />   
</template>
<script>
import Project from '@/components/project/Project.vue'
import c from '@/core/costants'
import { mapGetters } from 'vuex'

export default {
    name:'CustomerPage'
    ,middleware:'project'
    ,computed:{
        ...mapGetters(c.PROJECTS_STORE,{
            project:'getProject'
        })
    }
    ,components:{
        Project
    }
}
</script>