<template>
  <div>
    <div class="panel panel-danger" v-if="message !== null">
      {{message}}
    </div>
    <h2>Customers</h2>
    <table class="table">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">Company</th>
          <th scope="col">Town</th>
          <th scope="col">City</th>
          <th scope="col">Email</th>
          <th scope="col">CEO</th>
        </tr>
      </thead>
        <tbody
        v-if="customers.length > 0">
          <tr 
          v-for="customer in customers"
          :key="customer.id">
            <td>{{customer.id}}</td>
            <td>{{customer.companyName}}</td>
            <td>{{customer.town}}</td>
            <td>{{customer.city}}</td>
            <td>{{customer.email}}</td>
            <td>{{customer.ceoName}}</td>
          </tr>
        </tbody>
    </table>
  </div>
</template>

<script>
export default {
  components: {
  }
  ,data(){
    return{
      message:null,
      customers:[]      
    }
  }
  ,mounted(){
    this.$axios.get('https://localhost:5001/api/customers')
    .then(response => {
      this.customers = response.data
    })
    .catch(e => {
      this.message=e.response;
    })
  }
}
</script>

<style>
.title {
  font-family: 'Quicksand', 'Source Sans Pro', -apple-system, BlinkMacSystemFont,
    'Segoe UI', Roboto, 'Helvetica Neue', Arial, sans-serif;
  display: block;
  font-weight: 300;
  font-size: 100px;
  color: #35495e;
  letter-spacing: 1px;
}

.subtitle {
  font-weight: 300;
  font-size: 42px;
  color: #526488;
  word-spacing: 5px;
  padding-bottom: 15px;
}

.links {
  padding-top: 15px;
}
</style>
