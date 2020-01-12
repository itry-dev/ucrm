<template>
    <Customer :customer="customer" />   
</template>
<script>
import Customer from '@/components/customer/Customer.vue'
import c from '@/core/costants'
import { mapGetters } from 'vuex'

export default {
    name:'CustomerPage'
    ,middleware:'customer'
    ,computed:{
        ...mapGetters(c.CUSTOMERS_STORE,{
            customer:'getCustomer'
        })
    }
    ,components:{
        Customer
    }
}
</script>