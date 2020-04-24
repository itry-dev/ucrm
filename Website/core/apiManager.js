import c from '@/core/costants'
import axios from 'axios';

export default $context => ({
    
    getUserToken(){
        return 'ab'
    }

    ,getProjects(){
        return axios.get(c.API_ENDPOINTS.PROJECTS,{
            headers: {
                'Authorization': `Bearer ${this.getUserToken()}`
            }
        })
    }
    ,getProjectsByText(val){
        return axios.get(`${c.API_ENDPOINTS.PROJECTS}?q=${encodeURIComponent(val)}`)
    }
    ,getProject(id){
        return axios.get(`${c.API_ENDPOINTS.PROJECTS}/${id}`)
    }
    ,modifyProject(project){
        if (project && typeof project.id !== 'undefined'){
            return axios.put(`${c.API_ENDPOINTS.PROJECTS}/${project.id}`,project)
        }else{
            delete project.id
            return axios.post(`${c.API_ENDPOINTS.PROJECTS}`,project)
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

        return axios.get(`${c.API_ENDPOINTS.WORKED_HOURS_REPORT}?${qs}`)
    }
    ,exportWorkedHoursDetails(projectId, year, month){
        return axios.get(`${c.API_ENDPOINTS.EXPORT_WORKEDHOURS}?projectId=${projectId}&year=${year}&month=${month}`)
    }

    ,getCustomers(){
        return axios.get(c.API_ENDPOINTS.CUSTOMERS)
    }
    ,getCustomersByText(val){
        return axios.get(`${c.API_ENDPOINTS.CUSTOMERS}?q=${encodeURIComponent(val)}`)
    }
    ,getCustomer(id){
        return axios.get(`${c.API_ENDPOINTS.CUSTOMERS}/${id}`)
    }
    ,doModifyCustomer(customer){
        if (customer && typeof customer.id !== 'undefined'){
            return axios.put(`${c.API_ENDPOINTS.CUSTOMERS}/${customer.id}`,customer)
        }else{
            delete customer.id
            return axios.post(`${c.API_ENDPOINTS.CUSTOMERS}`,customer)
        }
    }

    ,getWorkedHours(year, month, projectsIds){
        // 
        if ( !projectsIds || !Array.isArray(projectsIds) || projectsIds.length<=0 ){
            return axios.get(`${c.API_ENDPOINTS.WORKED_HOURS}?year=${year}&month=${month}`)
        }
        
        return axios.post(`${c.API_ENDPOINTS.WORKED_HOURS_ON_PROJECT}?year=${year}&month=${month}`, projectsIds) 
    }
    ,getWorkedHoursById(id){
        return axios.get(`${captureEvents.API_ENDPOINTS.WORKED_HOURS}/${id}`)
    }
    ,modifyWorkedHours(wh, isDeleteOp){
        if (wh && wh.id !== ''){
            return axios.put(`${c.API_ENDPOINTS.WORKED_HOURS}/${wh.id}`,wh)
        }else{
            delete wh.id
            return axios.post(`${c.API_ENDPOINTS.WORKED_HOURS}`,wh)
        }
    }
    ,deleteWorkedHours(id){
        return axios.delete(`${c.API_ENDPOINTS.WORKED_HOURS}/${id}`)
    }
});