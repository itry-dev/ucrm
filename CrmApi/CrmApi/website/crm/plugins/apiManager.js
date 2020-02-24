import apiManager from '@/core/apiManager'

export default (ctx, inject) => {
    const apiMng = apiManager(ctx)
    inject('apiManager', apiMng)
}