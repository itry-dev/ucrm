<template>
  <div>
    <span v-if="message !== ''">{{message}}</span>
    <h4>Incomings for {{ new Date().toLocaleString('default', {month:'long'}) }}, {{year}}</h4>
    <!-- year and month filter -->
    <div class="pb-2">
    <b-form inline>
      
      <label class="mr-sm-2 pr-2" for="date">Filter data by period</label>
      <DatePicker 
          class="mb-2 mr-sm-2 mb-sm-0"
            :minimumView="'month'" 
            :maximumView="'year'"
            placeholder="year and month" 
            id="date" 
            :bootstrap-styling="true" 
            :full-month-name="true"
            format="MMMM yyyy"
            :clearButton="true"
            @cleared="dateHasBeenCleared"
            v-model="dateFilter" />

      <b-button variant="primary" @click="filterByDates" >Apply</b-button>
    </b-form>
    </div>
    <div v-if="summaries && summaries.length>0">
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
    <div v-if="summaries && summaries.length===0">
      <span class="h6">No incomings for the selected period</span>
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
            month:0,
            dateFilter:''
        }
    }
    ,mounted(){
      this.setInitialPeriod()
      this.loadData()
    }
    ,methods:{
      dateHasBeenCleared(){
        this.setInitialPeriod()
        this.loadData()
      }
      ,setInitialPeriod(){
        var d=new Date();
        this.year=d.getFullYear()
        this.month=d.getMonth()+1
      }
      ,loadData(){
        var clazz=this
        
        clazz.$apiManager.getProjects()
        .then((response) => {            
          clazz.summaries=[]
          clazz.totalIncomings=0

            response.data.forEach(element => {
              clazz.$apiManager.getProjectSummary(element.id, clazz.year, clazz.month)
              .then((response) => {

                if (response.data){
                  clazz.totalIncomings += parseFloat(response.data.totalAmount)
                  clazz.summaries.push(response.data)
                }

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
      ,filterByDates(){
        var d = this.$utils.getTimeZoneDate(this.dateFilter)
        this.year=parseInt(d.split('/')[0])
        this.month=parseInt(d.split('/')[1])

        this.loadData()
      }
    }
}
</script>

