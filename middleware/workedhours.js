import c from '@/core/costants'

/**
 * Get worked hours data.
 */
export default function ({app, store, route, query}){

    if (typeof query.id !== 'undefined'){
        console.log('workedhours:middleware',`loading hours with id: ${query.id}`);

        return store.dispatch(c.WORKED_HOURS_STORE+'/loadHour',{context:store, id:query.id})
            .then(response => {
                console.info('hours loaded')
            })
            .catch(e => {
                console.error(e)
            })
    }     
}