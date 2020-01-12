<template>
    <form>
        <h2>Add a Customer</h2>
        <div 
        :class="{'d-none':!isUploading, 'progress': isUploading}">
            <div class="progress-bar progress-bar-striped bg-danger" role="progressbar" style="width: 100%" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100"></div>
        </div>
        <div 
        :class="{'d-none' : opSentData===0, 'alert alert-danger' : opSentData===-1, 'alert alert-success' : opSentData===1 }">
            <span>{{feedback}}</span>
        </div>
        <div class="form-group">
            <label for="companyName">Company Name</label>
            <input type="text" class="form-control" id="companyName" v-model="tempCu.companyName">
        </div>
        <div class="form-group">
            <label for="nation">Nation</label>
            <input type="text" class="form-control" id="nation" v-model="tempCu.nation">
        </div>
        <div class="form-group">
            <label for="city">City</label>
            <input type="text" class="form-control" id="city" v-model="tempCu.city">
        </div>
        <div class="form-group">
            <label for="town">Town</label>
            <input type="text" class="form-control" id="town" v-model="tempCu.town">
        </div>
        <div class="form-group">
            <label for="vat">VAT</label>
            <input type="text" class="form-control" id="vat" v-model="tempCu.vat">
        </div>
        <div class="form-group">
            <label for="phoneNr">Phone Number</label>
            <input type="text" class="form-control" id="phoneNr" v-model="tempCu.phoneNr">
        </div>
        <div class="form-group">
            <label for="email">Email</label>
            <input type="email" class="form-control" id="email" v-model="tempCu.email">
        </div>
        <div class="form-group">
            <label for="ceo">CEO Name</label>
            <input type="text" class="form-control" id="ceo" v-model="tempCu.ceoName">
        </div>                        
        <button type="button" 
            class="btn btn-primary"
            @click="saveData()">Save</button>
    </form>
</template>
<script>
export default {
    name:'Customer'
    ,data(){
        return{
            isUploading:false,
            opSentData:0,
            feedback:'',
            tempCu:{
                companyName:'',
                nation:'',
                city:'',
                town:'',
                vat:'',
                phoneNr:'',
                email:'',
                ceoName:''
            }
        }
    }
    ,props:{
        customer:{
            type:Object
        }
    }
    ,mounted(){
        if (this.customer){
            this.tempCu.id=this.customer.id
            this.tempCu.companyName=this.customer.companyName
            this.tempCu.email=this.customer.email
            this.tempCu.nation=this.customer.nation
            this.tempCu.city=this.customer.city
            this.tempCu.town=this.customer.town
            this.tempCu.phoneNumber=this.customer.phoneNumber
            this.tempCu.ceoName=this.customer.ceoName
            this.tempCu.deleted=this.customer.deleted
        }
    }
    ,methods:{
        saveData(){
            this.isUploading=true
            if (this.customer && this.customer.id !== ''){
                return this.$axios.$put(`/Customers/${this.customer.id}`
                ,this.tempCu)
                .then(response => {
                    this.handleOkServerResponse(response)
                })
                .catch(e => {
                    this.handleKoServerResponse(e)
                })
            }else{
                return this.$axios.$post('/Customers'
                ,this.tempCu)
                .then(response => {
                    this.handleOkServerResponse(response)
                })
                .catch(e => {
                    this.handleKoServerResponse(e)
                })

            }
        }
        ,handleOkServerResponse(response){
            this.isUploading=false
            this.opSentData=1
            this.feedback='Customer saved' + (typeof response.id !== 'undefined' ? ' new Id: '+response.id : '')
        }
        ,handleKoServerResponse(e){
            console.error(e)
            this.isUploading=false
            this.opSentData=-1
            this.feedback='An error occured while saving data: '+this.$utils.getError(e)
        }
    }
}
</script>