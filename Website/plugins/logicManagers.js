import apiManager from '@/core/apiManager'
import userManager from '@/core/userManager'

export default (ctx, inject) => {
    const apiMng = apiManager(ctx)
    inject('apiManager', apiMng)

    const userMng = userManager(ctx)
    inject('userManager', userMng)
}