import utils from '@/core/utils'

export default (ctx, inject) => {
    const ctorUtils = utils(ctx)
    inject('utils', ctorUtils)
}