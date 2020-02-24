<template>
<div>
    <Feedback :feedback="feedback" :isErrMsg="isErrMsg" :isLoading="isLoading" />
    <Customer 
    :customer="customer"
    @has-clicked-save-customer="saveCustomer" />   
</div>    
</template>
<script>
import Customer from '@/components/customer/Customer.vue'
import c from '@/core/costants'

export default {
    name:'CustomerPage'
    ,data(){
        return {
            customer:{}
            ,feedback:''
            ,isErrMsg:false
            ,isLoading:false
        }
    }
    ,components:{
        Customer
    }
    ,methods:{
        loadCustomer(id){
            this.$apiManager.getCustomer(id)
            .then((response) => {
                this.isErrMsg=false
                this.customer=response.data
            })
            .catch((e) => {
                this.isErrMsg=true
                this.feedback=this.$utils.getError(e)
            })
        }
        ,setEmptyObject(){
            this.customer.id=''
            this.customer.companyName=''
            this.customer.country=''
            this.customer.city=''
            this.customer.town=''
            this.customer.vat=''
            this.customer.phoneNr=''
            this.customer.email=''
            this.customer.ceoName=''
        }
        ,saveCustomer(customer){
            this.isLoading=true

            this.$apiManager.doModifyCustomer(customer)
            .then((response) => {
                this.isLoading=false
                this.isErrMsg=false
                this.feedback= 'Customer saved!'
            })
            .catch((e) => {
                this.isLoading=false
                this.isErrMsg=true
                this.feedback=this.$utils.getError(e)
            })
        }
    }
    ,mounted(){
        if (this.$route.query.id){
            this.loadCustomer(this.$route.query.id)
        }
    } 
    ,beforeRouteUpdate(to, from, next){
        if (!to.query.id){
            this.setEmptyObject()
        }
        next()
    }
}
</script>