import c from '@/core/costants'
import axios from 'axios';

const BASE_URL = process.env.NODE_ENV === 'production' ? 'http://192.168.1.10:82/api' :'http://localhost:5002/api'
export default $context => ({
    
    API_ENDPOINTS:{
        PROJECTS: BASE_URL + '/projects'
        ,CUSTOMERS: BASE_URL + '/customers'
        ,WORKED_HOURS: BASE_URL + '/workedhours'
        ,WORKED_HOURS_ON_PROJECT: BASE_URL + '/workedhours/workedHoursOnProjects'
        ,WORKED_HOURS_REPORT: BASE_URL + '/workedhours/Report'
        ,EXPORT_WORKEDHOURS: BASE_URL + '/workedhours/Export'
    }
    
    ,getProjects(){
        return axios.get(this.API_ENDPOINTS.PROJECTS)
    }
    ,getProjectsByText(val){
        return axios.get(`${this.API_ENDPOINTS.PROJECTS}?q=${encodeURIComponent(val)}`)
    }
    ,getProject(id){
        return axios.get(`${this.API_ENDPOINTS.PROJECTS}/${id}`)
    }
    ,modifyProject(project){
        if (project && typeof project.id !== 'undefined'){
            return axios.put(`${this.API_ENDPOINTS.PROJECTS}/${project.id}`,project)
        }else{
            delete project.id
            return axios.post(`${this.API_ENDPOINTS.PROJECTS}`,project)
        }
    }
    ,getWorkedHoursReport(year, month, projectId){
        var qs = `year=${year}`
        
        if (typeof(month) !== 'undefined'){
            qs += `&month=${month}`
        }
        
        if (typeof(projectId) !== 'undefined'){
            qs += `&projectId=${projectId}`
        }

        return axios.get(`${this.API_ENDPOINTS.WORKED_HOURS_REPORT}?${qs}`)
    }
    ,exportWorkedHoursDetails(projectId, year, month){
        return axios.get(`${this.API_ENDPOINTS.EXPORT_WORKEDHOURS}?projectId=${projectId}&year=${year}&month=${month}`)
    }

    ,getCustomers(){
        return axios.get(this.API_ENDPOINTS.CUSTOMERS)
    }
    ,getCustomersByText(val){
        return axios.get(`${this.API_ENDPOINTS.CUSTOMERS}?q=${encodeURIComponent(val)}`)
    }
    ,getCustomer(id){
        return axios.get(`${this.API_ENDPOINTS.CUSTOMERS}/${id}`)
    }
    ,doModifyCustomer(customer){
        if (customer && typeof customer.id !== 'undefined'){
            return axios.put(`${this.API_ENDPOINTS.CUSTOMERS}/${customer.id}`,customer)
        }else{
            delete customer.id
            return axios.post(`${this.API_ENDPOINTS.CUSTOMERS}`,customer)
        }
    }

    ,getWorkedHours(year, month, projectsIds){
        // 
        if ( !projectsIds || !Array.isArray(projectsIds) || projectsIds.length<=0 ){
            return axios.get(`${this.API_ENDPOINTS.WORKED_HOURS}?year=${year}&month=${month}`)
        }
        
        return axios.post(`${this.API_ENDPOINTS.WORKED_HOURS_ON_PROJECT}?year=${year}&month=${month}`, projectsIds) 
    }
    ,getWorkedHoursById(id){
        return axios.get(`${this.API_ENDPOINTS.WORKED_HOURS}/${id}`)
    }
    ,modifyWorkedHours(wh, isDeleteOp){
        if (wh && wh.id !== ''){
            return axios.put(`${this.API_ENDPOINTS.WORKED_HOURS}/${wh.id}`,wh)
        }else{
            delete wh.id
            return axios.post(`${this.API_ENDPOINTS.WORKED_HOURS}`,wh)
        }
    }
    ,deleteWorkedHours(id){
        return axios.delete(`${this.API_ENDPOINTS.WORKED_HOURS}/${id}`)
    }
});