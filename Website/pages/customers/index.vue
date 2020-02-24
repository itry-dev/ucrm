<template>
    <div>
      <Feedback :feedback="feedback" :isErrMsg="isErrMsg" :isLoading="isLoading" />

      <h2>Customers</h2>
      <table class="table">
        <thead>
          <tr>
            <th scope="col">Company</th>
            <th scope="col">Town</th>
            <th scope="col">City</th>
            <th scope="col">Email</th>
            <th scope="col">CEO</th>
            <th scope="col">&nbsp;</th>
          </tr>
        </thead>
          <tbody
          v-if="customers.length > 0">
            <tr 
            v-for="customer in customers"
            :key="customer.id">
              <td>{{customer.companyName}}</td>
              <td>{{customer.town}}</td>
              <td>{{customer.city}}</td>
              <td>{{customer.email}}</td>
              <td>{{customer.ceoName}}</td>
              <td>
                  <nuxt-link :to="`/customers/customer?id=${customer.id}`">
                  <i class="material-icons">create</i>
                  </nuxt-link>
              </td>
            </tr>
          </tbody>
      </table>
    </div>
</template>
<script>

export default {
    name:'CustomersList'
    ,data(){
        return{
            feedback:null,
            isErrMsg:false,
            isLoading:false,
            customers:[]
        }
    }
    ,mounted(){
        this.isLoading=true

        this.$apiManager.getCustomers()
        .then((response) => {          
            this.customers=response.data
            this.isLoading=false
            this.feedback=''
        })
        .catch((e) => {
            this.isLoading=false
            this.isErrMsg=true
            this.feedback=this.$utils.getError(e)
        })
    }
}
</script>