<template>
    <form>
        <h2>Add a Project</h2>
        <div 
        :class="{'d-none':!isUploading, 'progress': isUploading}">
            <div class="progress-bar progress-bar-striped bg-danger" role="progressbar" style="width: 100%" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100"></div>
        </div>
        <div 
        :class="{'d-none' : opSentData===0, 'alert alert-danger' : opSentData===-1, 'alert alert-success' : opSentData===1 }">
            <span v-html="feedback"></span>
        </div>
        <div class="form-group">
            <label for="name">Customer Name</label>
            <AutoComplete 
            v-on:is-typing="getCustomer" 
            v-on:has-clicked-result="setCustomer"
            :items="customers"
            :initialValue="customer"
            dataValue="id"
            dataText="companyName"
            :isAsync="true" />
        </div>
        <div class="form-group">
            <label for="name">Name</label>
            <input type="text" class="form-control" id="name" v-model="tempP.name">
        </div>
        <div class="form-group">
            <label for="startDate">Start Date</label>
            <DatePicker placeholder="DD/MM/YYYY" id="startDate" :bootstrap-styling="true" :full-month-name="true" format="dd/MM/yyyy" v-model="tempP.startDate" />
        </div>
        <div class="form-group">
            <label for="endDate">End Date</label>
            <DatePicker placeholder="DD/MM/YYYY" id="endDate" :bootstrap-styling="true" :full-month-name="true" format="dd/MM/yyyy" v-model="tempP.endDate" />
        </div>
        <div class="form-group">
            <label for="totalAmount">Total Amount</label>
            <input type="text" class="form-control" id="totalAmount" v-model="tempP.totalAmount">
        </div>
        <div class="form-group">
            <label for="hourlyRate">Hourly Rate</label>
            <input type="text" class="form-control" id="hourlyRate" v-model="tempP.hourlyRate">
        </div>                      
        <button type="button" 
            class="btn btn-primary"
            @click="saveData()">Save</button>
    </form>
</template>
<script>

export default {
    name:'Customer'
    ,data(){
        return{
            isUploading:false,
            opSentData:0,
            feedback:'',
            customers:[],
            customer:null,
            tempP:{
                name:'',
                startDate:'',
                endDate:null,
                totalAmount:null,
                hourlyRate:null,
                deleted:false,
                customerId:''
            }
        }
    }
    ,props:{
        project:{
            type:Object
        }
    }
    ,mounted(){
        
        if (this.project){
            this.tempP.id=this.project.id
            this.tempP.name=this.project.name
            this.tempP.startDate=this.project.startDate
            this.tempP.endDate=this.project.endDate
            this.tempP.totalAmount=this.project.totalAmount
            this.tempP.hourlyRate=this.project.hourlyRate
            this.tempP.deleted=this.project.deleted
            this.tempP.customerId=this.project.customer.id

            this.customer=this.project.customer
        }
        
    }
    ,methods:{
        saveData(){
            
            this.isUploading=true
            if (this.project && this.project.id !== ''){
                return this.$axios.$put(`/projects/${this.project.id}`
                ,this.tempP)
                .then(response => {
                    this.handleOkServerResponse(response)
                })
                .catch(e => {
                    this.handleKoServerResponse(e)
                })
            }else{
                return this.$axios.$post('/projects'
                ,this.tempP)
                .then(response => {
                    this.handleOkServerResponse(response)
                })
                .catch(e => {
                    this.handleKoServerResponse(e)
                })

            }
        }
        ,handleOkServerResponse(response){
            this.isUploading=false
            this.opSentData=1
            this.feedback='Project saved' + (typeof response.id !== 'undefined' ? ' new Id: '+response.id : '')
        }
        ,handleKoServerResponse(e){
            console.error(e)
            this.isUploading=false
            this.opSentData=-1
            this.feedback='An error occured while saving data:<br />'+this.$utils.getError(e)
        }
        ,getCustomer(val){
            this.$axios.$get('/customers?q='+val)
            .then((response) => {
                this.customers=response
            })
            .catch((e) => {
                this.feedback=this.$utils.getError(e)
            })
        }
        ,setCustomer(result){
            this.tempP.customerId=result.id
        }
    }
}
</script>