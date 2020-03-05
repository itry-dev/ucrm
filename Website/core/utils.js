export default $context => ({
    isUndef(obj){
        if (typeof obj === 'undefined' || obj === null){
           return true;
        }  
        return false;
    }
    ,getError(error,onBeginRedirectToLogin,onGetServerMessage){
      
        //controllo se è una risposta dal server
        if (!this.isUndef(error.response)){
           //recupero lo stato http della risposta
           if (!this.isUndef(error.response.status)){
              if (error.response.status===401){
                 //TODO
              }else{
                
                var err=''
                if (error.response.data){
                    if (error.response.data.errors){
                        for(const property in error.response.data.errors) {
                            err += error.response.data.errors[property]+'<br />'
                        }
                    }else if (error.response.data.title) {
                        err=error.response.data.title
                    } 
                }
                
                if (err === ''){
                    err='An unknown error occured'
                }

                return err
              }
           }
        }else{
           console.log(error)
        }
    }

    ,getTimeZoneDate(date) {
        if (typeof date ==='string') date = new Date(date)
         
        return date.getFullYear() + '/' + 
        (date.getMonth() + 1 < 10 ? '0'+(date.getMonth() + 1) : date.getMonth() + 1) + '/' + 
        (date.getDate() < 10 ? '0'+date.getDate() : date.getDate());
    }

});