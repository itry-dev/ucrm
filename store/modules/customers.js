export const state = () => ({
    customers:[],
    customer:null
})

export const mutations = {
    setCustomers(state, customers){
        state.customers = customers;
    }
    ,setCustomer(state, customer){
        state.customer = customer;
    }
}

export const actions = {

    loadCustomer(context,{id}){
        return this.$axios.$get(`/customers/${id}`)
        .then((response) => {
            context.commit('setCustomer',response)
        })
        .catch(e => {
            throw e
        })
    }
    ,loadCustomers(context){
        return this.$axios.$get('/customers?q=')
        .then((response) => {
            context.commit('setCustomers',response)
        })
        .catch(e => {
            throw e
        })
    }

}

export const getters = {
    getCustomers(context){
        return context.customers;
    },
    getCustomer(context){
        return context.customer;
    }
}