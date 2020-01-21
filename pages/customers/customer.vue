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
            customer:[]
            ,feedback:''
            ,isErrMsg:false
            ,isLoading:false
        }
    }
    ,components:{
        Customer,
        Feedback
    }
    ,methods:{
        loadCustomer(id){
            this.$axios.$get(`/customers/${id}`)
            .then((response) => {
                this.isErrMsg=false
                this.customer=response
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

            if (customer && customer.id !== ''){
                return this.$axios.$put(`/Customers/${customer.id}`,customer)
                .then((response) => {
                    this.isLoading=false
                    this.isErrMsg=false
                    this.feedback='New Customer added!'
                })
                .catch((e) => {
                    this.isLoading=false
                    this.isErrMsg=true
                    this.feedback=this.$utils.getError(e)
                })
            }else{
                return this.$axios.$post('/Customers',customer)
                .then((response) => {
                    this.isLoading=false
                    this.isErrMsg=false
                    this.feedback='Customer updated!'
                })
                .catch((e) => {
                    this.isLoading=false
                    this.isErrMsg=true
                    this.feedback=this.$utils.getError(e)
                })

            }
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