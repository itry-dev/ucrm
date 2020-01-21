<template>
    <form>
        <h2>Add a Project</h2>

        <Feedback :feedback="autoCompleteErrors" :isErrMsg="isErrMsg" />

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
            <input type="text" class="form-control" id="name" v-model="project.name">
        </div>
        <div class="form-group">
            <label for="startDate">Start Date</label>
            <DatePicker placeholder="DD/MM/YYYY" id="startDate" :bootstrap-styling="true" :full-month-name="true" format="dd/MM/yyyy" v-model="project.startDate" />
        </div>
        <div class="form-group">
            <label for="endDate">End Date</label>
            <DatePicker placeholder="DD/MM/YYYY" id="endDate" :bootstrap-styling="true" :full-month-name="true" format="dd/MM/yyyy" v-model="project.endDate" />
        </div>
        <div class="form-group">
            <label for="totalAmount">Total Amount</label>
            <input type="text" class="form-control" id="totalAmount" v-model="project.totalAmount">
        </div>
        <div class="form-group">
            <label for="hourlyRate">Hourly Rate</label>
            <input type="text" class="form-control" id="hourlyRate" v-model="project.hourlyRate">
        </div>  
        <div class="form-group pt-2">
            <label for="notes">Additional Notes</label>
            <textarea class="form-control" id="notes" rows="3" v-model="project.additionalNotes"></textarea>
        </div>                    
        <button type="button" 
            class="btn btn-primary"
            @click="saveData()">Save</button>
    </form>
</template>
<script>
import c from '@/core/costants'
import Feedback from '@/components/UI/Feedback.vue'

export default {
    name:'Customer'
    ,data(){
        return{
            autoCompleteErrors:'',
            isErrMsg:false,
            customer:null,
            customers:[]
        }
    }
    ,props:{
        project:{
            type:Object
            ,requred:false
        }
    }
    ,components:{
        Feedback
    }
    ,mounted(){
        if (this.project && this.project.customer) this.customer=this.project.customer
    }
    ,methods:{
        saveData(){
            this.$emit(c.EMIT_ACTIONS.HAS_CLICKED_SAVE_PROJECT, this.project)          
        }
        ,getCustomer(val){
            this.$axios.$get('/customers?q='+val)
            .then((response) => {
                this.customers=response
            })
            .catch((e) => {
                this.isErrMsg=true
                this.autoCompleteErrors=this.$utils.getError(e)
            })
        }
        ,setCustomer(result){
            this.customer.customerId=result.id
        }
    }
}
</script>