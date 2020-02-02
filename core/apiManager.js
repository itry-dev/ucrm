import c from '@/core/costants'
import axios from 'axios';

const BASE_URL = process.env.NODE_ENV !== 'production' ? 'http://192.168.1.10:82/api' :'http://localhost:5002/api'
export default $context => ({
    
    API_ENDPOINTS:{
        PROJECTS: BASE_URL + '/projects'
        ,CUSTOMERS: BASE_URL + '/customers'
        ,WORKED_HOURS: BASE_URL + '/workedhours'
        ,PROJECT_SUMMARY: BASE_URL + '/WorkedHours/MonthlyAmount'
        ,EXPORT_WORKEDHOURS: BASE_URL + '/WorkedHours/Export'
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
        if (project && project.id && project.id !== ''){
            return axios.put(`${this.API_ENDPOINTS.PROJECTS}/${project.id}`,project)
        }else{
            delete project.id
            return axios.post(`${this.API_ENDPOINTS.PROJECTS}`,project)
        }
    }
    ,getProjectSummary(projectId, year, month){
        return axios.get(`${this.API_ENDPOINTS.PROJECT_SUMMARY}?projectId=${projectId}&year=${year}&month=${month}`)
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
        if (customer && customer.id !== ''){
            return axios.put(`${this.API_ENDPOINTS.CUSTOMERS}/${customer.id}`,customer)
        }else{
            delete customer.id
            return axios.post(`${this.API_ENDPOINTS.CUSTOMERS}`,customer)
        }
    }

    ,getWorkedHours(year, month){
        return axios.get(`${this.API_ENDPOINTS.WORKED_HOURS}?year=${year}&month=${month}`)
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