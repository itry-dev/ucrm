<template>
    <form>
        <h2>Add a Customer</h2>

        <div class="form-group">
            <label for="companyName">Company Name</label>
            <input type="text" class="form-control" id="companyName" v-model="customer.companyName">
        </div>
        <div class="form-group">
            <label for="nation">Nation</label>
            <input type="text" class="form-control" id="nation" v-model="customer.country">
        </div>
        <div class="form-group">
            <label for="city">City</label>
            <input type="text" class="form-control" id="city" v-model="customer.city">
        </div>
        <div class="form-group">
            <label for="town">Town</label>
            <input type="text" class="form-control" id="town" v-model="customer.town">
        </div>
        <div class="form-group">
            <label for="vat">VAT</label>
            <input type="text" class="form-control" id="vat" v-model="customer.vat">
        </div>
        <div class="form-group">
            <label for="phoneNr">Phone Number</label>
            <input type="text" class="form-control" id="phoneNr" v-model="customer.phoneNr">
        </div>
        <div class="form-group">
            <label for="email">Email</label>
            <input type="email" class="form-control" id="email" v-model="customer.email">
        </div>
        <div class="form-group">
            <label for="ceo">CEO Name</label>
            <input type="text" class="form-control" id="ceo" v-model="customer.ceoName">
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
            feedback:''
        }
    }
    ,props:{
        customer:{
            type:Object
        }
    }
    ,methods:{
        saveData(){
            this.$emit(c.EMIT_ACTIONS.HAS_CLICKED_SAVE_CUSTOMER, this.customer)          
        }
    }
}
</script>