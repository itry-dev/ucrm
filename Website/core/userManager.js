import c from '@/core/costants'
import apiMng from '@/core/apiManager'
import axios from 'axios';

export default $userManger => ({

    login(user, password){
        var data = { username:'f', password:'f' }
        return axios.post(c.API_ENDPOINTS.USER_AUTHENTICATE,data)
    }


});