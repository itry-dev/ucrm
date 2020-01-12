<template>
    <div>
    <div class="panel panel-danger" v-if="message !== null">
      {{message}}
    </div>
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
                <nuxt-link :to="`/customers/customer?id=${customer.id}`">edit</nuxt-link>
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
            message:null,
            customers:[]
        }
    }
    ,mounted(){
      this.$axios.$get('/customers')
      .then((response) => {
          this.customers=response
      })
      .catch(e => {
          this.message=this.$utils.getError(e)
      })
    }
}
</script>