const BASE_URL = process.env.NODE_ENV === 'production' ? 'http://192.168.1.10:82/api' :'http://localhost:5002/api'
export default Object.freeze({
    CUSTOMERS_STORE:'modules/customers'
    ,PROJECTS_STORE:'modules/projects'
    ,WORKED_HOURS_STORE:'modules/workedhours'
    ,EMIT_ACTIONS:{
        HAS_CLICKED_DATE:'has-clicked-date'
        ,HAS_CLICKED_WORKEDHOURS:'has-clicked-workedhours'
        ,HAS_CLICKED_SAVE_CUSTOMER:'has-clicked-save-customer'
        ,HAS_CLICKED_SAVE_PROJECT:'has-clicked-save-project'
        ,HAS_CLICKED_DEL_WH:'has-clicked-del-wh'
        ,HAS_CLICKED_SAVE_WH:'has-clicked-save-wh'
        ,HAS_CLEARED_DATE:'has-cleared-date'
        ,HAS_CHANGED_DATE:'has-changed-date'
        ,HAS_CLICKED_RESULT:'has-clicked-result'
        ,HAS_CLICKED_BADGE_ITEM:'has-clicked-badge-item'
        ,HAS_CLICKED_REMOVE_BADGE_ITEM:'has-clicked-remove-badge-item'
        ,IS_TYPING:'is-typing'
        ,THROW_ERROR:'on-error'        
    }
    ,URLS:{
        TO_ADD_WORKEDHOURS:'/projects/workedhours/hours'
    }
    ,CALENDAR_COLORS:{
        WEEKEND:'#ccc'
    }
    ,API_ENDPOINTS:{
        PROJECTS: BASE_URL + '/projects'
        ,CUSTOMERS: BASE_URL + '/customers'
        ,WORKED_HOURS: BASE_URL + '/workedhours'
        ,WORKED_HOURS_ON_PROJECT: BASE_URL + '/workedhours/workedHoursOnProjects'
        ,WORKED_HOURS_REPORT: BASE_URL + '/workedhours/Report'
        ,EXPORT_WORKEDHOURS: BASE_URL + '/workedhours/Export'
        ,USER_AUTHENTICATE: BASE_URL +'/user/authenticate'
    }
 })
 