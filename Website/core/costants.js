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
 })
 