export const state = () => ({
    hours:[],
    hour:null
})

export const mutations = {
    setHours(state, hours){
        state.hours = hours;
    }
    ,setHour(state, hour){
        state.hour = hour;
    }
}

export const actions = {

    loadHour(context,{id}){
        return this.$axios.$get(`/workedhours/${id}`)
        .then((response) => {
            context.commit('setHour',response)
        })
        .catch(e => {
            throw e
        })
    }
    ,loadHours(context){
        return this.$axios.$get('/workedhours')
        .then((response) => {
            context.commit('setHours',response)
        })
        .catch(e => {
            throw e
        })
    }

}

export const getters = {
    getHours(context){
        return context.hours;
    },
    getHour(context){
        return context.hour;
    }
}