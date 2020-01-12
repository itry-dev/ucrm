export const state = () => ({
    projects:[],
    project:null
})

export const mutations = {
    setProjects(state, projects){
        state.projects = projects;
    }
    ,setProject(state, project){
        state.project = project;
    }
}

export const actions = {

    loadProject(context,{id}){
        return this.$axios.$get(`/projects/${id}`)
        .then((response) => {
            context.commit('setProject',response)
        })
        .catch(e => {
            throw e
        })
    }
    ,loadProjects(context){
        return this.$axios.$get('/projects?q=')
        .then((response) => {
            context.commit('setProjects',response)
        })
        .catch(e => {
            throw e
        })
    }

}

export const getters = {
    getProjects(context){
        return context.projects;
    },
    getProject(context){
        return context.project;
    }
}