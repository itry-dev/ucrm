<template>
    <form>
        <h2>Worked Hours</h2>

        <Feedback :feedback="autoCompleteErrors" :isErrMsg="true" />

        <!-- project search --> 
        <div class="form-group" v-if="!workedHours.project">
            <label for="name">Project Name</label>
            <AutoComplete 
            v-on:is-typing="getProject" 
            v-on:has-clicked-result="setProject"
            :items="projects"
            dataValue="id"
            dataText="name"
            :isAsync="true" />
        </div>
        <!-- modifying data -->
        <div class="alert alert-success" v-else>
            <div>
                <span class="d-block text-uppercase font-weight-bold">customer</span>
                <span>{{workedHours.project.customer.companyName}}</span>
            </div>
            <div>
                <span class="d-block text-uppercase font-weight-bold">project name</span>
                <span>{{workedHours.project.name}}</span>
            </div>
        </div>
        <div class="form-group">
            <label for="date">Date</label> 
            <DatePicker 
            placeholder="DD/MM/YYYY" 
            :monday-first="true"
            id="date" 
            :bootstrap-styling="true" 
            :full-month-name="true" 
            format="dd/MM/yyyy"  
            v-model="workedHours.date" />
        </div>
        <div class="form-group">
            <label for="hours">Hours</label>
            <input type="text" class="form-control" id="hours" v-model="workedHours.hours">
        </div>
        <div class="form-group">
            <label for="hourlyRate">Hourly Rate</label>
            <input type="text" class="form-control" id="hourlyRate" v-model="workedHours.hourlyRate">
        </div>
        <div class="form-check">
            <input type="checkbox" class="form-check-input" id="atOffice" v-model="workedHours.atCustomerOffice">
            <label for="atOffice" class="form-check-label">At Customer office</label>            
        </div>
        <div class="form-group pt-2">
            <label for="notes">Additional Notes</label>
            <textarea class="form-control" id="notes" rows="3" v-model="workedHours.additionalNotes"></textarea>
        </div>
        <button type="button" 
            class="btn btn-primary"
            @click="saveData">Save</button>

        <button 
            v-if="workedHours && workedHours.id !== ''"
            type="button" 
            class="btn btn-danger"
            @click="deleteData">Delete</button>
    </form>
</template>
<script>
import c from '@/core/costants'

export default {
    name:'WorkedHours'
    ,data(){
        return{
            projects:[],
            project:null,
            autoCompleteErrors:'',
            pickerDate:''
        }
    }
    ,props:{
        workedHours:{
            type:Object
            ,required:false            
        }
    }
    ,mounted(){
        if (this.workedHours.date===''){
            this.workedHours.date=new Date()
        }
    }
    ,methods:{
        saveData(){              
            this.workedHours.date=this.$utils.getTimeZoneDate(this.workedHours.date)
            this.$emit(c.EMIT_ACTIONS.HAS_CLICKED_SAVE_WH, this.workedHours)          
        }
        ,deleteData(){
            this.$bvModal.msgBoxConfirm('Please confirm that you want to delete this entry.', {
                title: 'Please Confirm',
                size: 'sm',
                buttonSize: 'sm',
                okVariant: 'danger',
                okTitle: 'YES',
                cancelTitle: 'NO',
                footerClass: 'p-2',
                hideHeaderClose: false,
                centered: true
            })
            .then(value => {
                if (value){
                    this.$emit(c.EMIT_ACTIONS.HAS_CLICKED_DEL_WH, this.workedHours.id)
                }                
            })
            .catch(err => {
                console.log(err)
            })
        }        
        ,getProject(val){
            this.$apiManager.getProjectsByText(val)
            .then((response) => {
                var data=[]
                response.data.forEach(function(el) {
                    data.push({id:el.id, name: el.customer.companyName+': '+el.name})
                })
                this.projects=data
            })
            .catch((e) => {
                this.autoCompleteErrors=this.$utils.getError(e)
            })
        }
        ,setProject(result){
            this.workedHours.projectId=result.id
        }
    }

}
</script>