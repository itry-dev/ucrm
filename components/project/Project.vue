<template>
    <form>
        <h2>Add a Project</h2>

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
            <input type="text" class="form-control" id="name" v-model="internalProject.name">
        </div>
        <div class="form-group">
            <label for="startDate">Start Date</label>
            <DatePicker placeholder="DD/MM/YYYY" id="startDate" :bootstrap-styling="true" :full-month-name="true" format="dd/MM/yyyy" v-model="internalProject.startDate" />
        </div>
        <div class="form-group">
            <label for="endDate">End Date</label>
            <DatePicker placeholder="DD/MM/YYYY" id="endDate" :bootstrap-styling="true" :full-month-name="true" format="dd/MM/yyyy" v-model="internalProject.endDate" />
        </div>
        <div class="form-group">
            <label for="totalAmount">Total Amount</label>
            <input type="text" class="form-control" id="totalAmount" v-model="internalProject.totalAmount">
        </div>
        <div class="form-group">
            <label for="hourlyRate">Hourly Rate</label>
            <input type="text" class="form-control" id="hourlyRate" v-model="internalProject.hourlyRate">
        </div>  
        <div class="form-group pt-2">
            <label for="notes">Additional Notes</label>
            <textarea class="form-control" id="notes" rows="3" v-model="internalProject.additionalNotes"></textarea>
        </div>                    
        <button type="button" 
            class="btn btn-primary"
            @click="saveData()">Save</button>
    </form>
</template>
<script>
import c from '@/core/costants'

export default {
    name:'Customer'
    ,data(){
        return{
            customer:{},
            customers:[],
            internalProject:{
                id:'',
                name:'',
                startDate:'',
                endDate:'',
                totalAmount:0,
                hourlyRate:0,
                additionalNotes:'',
                customerId:''
            }
        }
    }
    ,props:{
        project:{
            type:Object
            ,requred:false
        }
    }
    ,methods:{
        saveData(){
            this.$emit(c.EMIT_ACTIONS.HAS_CLICKED_SAVE_PROJECT, this.internalProject)          
        }
        ,getCustomer(val){
            this.$apiManager.getCustomersByText(val)
            .then((response) => {
                this.customers=response.data
            })
            .catch((e) => {
                this.$emit(c.EMIT_ACTIONS.THROW_ERROR, this.$utils.getError(e))    
            })
        }
        ,setCustomer(result){
            this.internalProject.customerId=result.id
        }
    }
    ,watch: {
      project: function(value, oldValue){
        if (value){

            this.internalProject.id = value.id
            this.internalProject.name = value.name
            this.internalProject.startDate = value.startDate
            this.internalProject.endDate = value.endDate
            this.internalProject.totalAmount = value.totalAmount
            this.internalProject.hourlyRate = value.hourlyRate
            this.internalProject.customerId = value.customerId

            if (value.customer){
                this.customer=value.customer
            }
                        
        }else{
            this.internalProject.id = ''
            this.internalProject.name = ''
            this.internalProject.startDate = ''
            this.internalProject.endDate = ''
            this.internalProject.totalAmount = 0
            this.internalProject.hourlyRate = 0
            this.internalProject.customerId = ''
            this.customer={}
        }
      }
    }
}
</script>