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
                    }
                }

                if (err===''){
                    if (error.response.data.title) err=error.response.data.title
                }
                
                return err
              }
           }
        }else{
           console.log(error)
        }
     }

});