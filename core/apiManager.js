import c from '@/core/costants'
import axios from 'axios';

const BASE_URL = process.env.NODE_ENV !== 'production' ? 'https://localhost:5001/api' : ''  
export default $context => ({
    
    API_ENDPOINTS:{
        PROJECTS: BASE_URL+'/projects'
        ,PROJECT_SUMMARY: BASE_URL+'/WorkedHours/MonthlyAmount'
    }
    
    ,getProjects(){
        return axios.get(this.API_ENDPOINTS.PROJECTS)
    }
    ,getProjectSummary(projectId, year, month){
        return axios.get(`${this.API_ENDPOINTS.PROJECT_SUMMARY}?projectId=${projectId}&year=${year}&month=${month}`)
    }
});