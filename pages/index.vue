<template>
  <div>
    <span v-if="message !== ''">{{message}}</span>
    <h4>Incomings for {{ new Date().toLocaleString('default', {month:'long'}) }}, {{year}}</h4>
    <div>
      <b-card-group deck>
        <b-card 
        v-for="(summary,index) in summaries"
        v-bind:key="index"
        :title="summary.companyName">
          <b-card-text class="p-2">
            <div class="text-uppercase">
            {{summary.projectName}}
            </div>
            <div class="pt-2">Worked Hours: {{summary.hours}}</div>
            <div class="pt-2">Total Amount: <b>{{summary.totalAmount | format}}</b></div>
          </b-card-text>
        </b-card>
      </b-card-group>
    </div>
    <div class="pt-2">
      <span>Total Incomings</span> <span class="font-weight-bold">{{ totalIncomings | format }}</span>
    </div>

</div>
</template>
<script>
export default {
  name:'Dashboard'
  ,data(){
        return{
            message:null,
            summaries:[],
            totalIncomings:0,
            year:0,
            month:0
        }
    }
    ,mounted(){
      var clazz=this
      var d=new Date();
      this.year=d.getFullYear()
      this.month=d.getMonth()+1

      clazz.$apiManager.getProjects()
      .then((response) => {            
          response.data.forEach(element => {
            clazz.$apiManager.getProjectSummary(element.id, clazz.year, clazz.month)
            .then((response) => {
              clazz.totalIncomings += parseFloat(response.data.totalAmount)
              clazz.summaries.push(response.data)
            })
            .catch((e) => {
              clazz.message=this.$utils.getError(e)

            }) 
          });
      })
      .catch(e => {
          clazz.message=this.$utils.getError(e)
      })
    }
}
</script>

