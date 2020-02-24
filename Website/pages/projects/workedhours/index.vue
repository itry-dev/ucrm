<template>
<div>
    <Feedback :feedback="feedback" :isErrMsg="isErrMsg" :isLoading="isLoading" />

    <Badge
    v-if="projects.length>0"
    :dataItems="projects"
    dataText="name"
    dataValue="id"
    @has-clicked-badge-item="removeProjectFilter" />

    <full-calendar 
    :events="workedHours"
    @has-clicked-date="hasClickedDate"
    @has-clicked-workedhours="hasClickedWorkedHours"
    @has-cleared-date="loadCurrentMonth"
    @has-changed-date="changeMonth" />
</div>
</template>
<script>
import c from '@/core/costants'

export default {
    name:'WorkedHoursList'
    ,data(){
        return{
            message:null
            ,results:[]
            ,workedHours:[]
            ,projects:[]
            ,feedback:''
            ,isErrMsg:false
            ,isLoading:false
            ,year:0
            ,month:0
            ,projectId:''
        }
    }
    ,mounted(){
        this.loadCurrentMonth()
    }
    ,methods:{
        removeProjectFilter(which/*, isOn*/){

/*             console.log(which.name+' '+isOn)
            if (isOn){
                this.projects.push(
                {
                    id:which.id,
                    name:which.name
                })
            }else{ */
                this.projects=this.projects.filter(function(el){
                    return el.id !== which.id
                })
            /*}*/
            
            this.loadData(this.projects)
        }
        ,loadData(projectsIds){
            var clazz=this
            clazz.isLoading=true
            clazz.workedHours=[]
            
            clazz.$apiManager.getWorkedHours(clazz.year, clazz.month, (typeof(projectsIds) !== 'undefined' ? projectsIds.map(x => x.id) : []))
            .then((response) => {

                response.data.forEach(function(el) {
                    clazz.workedHours.push(
                    {
                        title:el.project.customer.companyName.substring(0,5).toUpperCase()+': '+el.hours
                        ,start:el.date
                        ,end:el.date
                        ,whId:el.id
                        /*,color: ...*/
                    })

                    //projects array
                    var obj=clazz.projects.findIndex(x => x.id === el.project.id);
                    if (obj===-1){
                        clazz.projects.push(
                        {
                            id: el.project.id,
                            name: el.project.name
                        });
                    }
                })
                clazz.isLoading=false
            })
            .catch((e) => {
                clazz.isLoading=false
                clazz.isErrMsg=true
                clazz.feedback=this.$utils.getError(e)
            })
        }
        ,hasClickedDate(arg){
            this.$router.push({name:'projects-workedhours-hours', params: { selectedDate:arg}})
        }
        ,hasClickedWorkedHours(e){
            this.$router.push(`${c.URLS.TO_ADD_WORKEDHOURS}?id=${e}`)
        }
        ,changeMonth(d){
            if (d && d !== null){
                this.year=d.getFullYear()
                this.month=d.getMonth()+1
                this.loadData()
            }
        }
        ,loadCurrentMonth(){
            this.setCurrentMonth()
            this.loadData()
        }
        ,setCurrentMonth(){
            var d = new Date()
            this.year = d.getFullYear() 
            this.month= d.getMonth()+1
        }
    }
}
</script>