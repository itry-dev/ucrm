import c from '@/core/costants'

/**
 * Get customer data.
 */
export default function ({app, store, route, query}){

    if (typeof query.id !== 'undefined'){
        console.log('customer:middleware',`loading customer with id: ${query.id}`);

        return store.dispatch(c.CUSTOMERS_STORE+'/loadCustomer',{context:store, id:query.id})
            .then(response => {
                console.info('customer loaded')
            })
            .catch(e => {
                console.error(e)
            })
    }     
}