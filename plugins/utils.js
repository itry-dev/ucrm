import utils from '@/core/utils'

export default (ctx, inject) => {
    const enoUtils = utils(ctx)
    inject('utils', enoUtils)
}