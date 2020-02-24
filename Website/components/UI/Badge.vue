<template>
<div>
    <button type="button" class="btn btn-primary ml-2"  
        v-for="(dataItem, index) in dataItems" 
        :key="index"
        @click="hasClikedItem($event, dataItem)">
        {{dataItem[dataText]}}
    </button>
</div>
</template>
<script>
import c from '@/core/costants'

export default {
    name:'Badge',
    props:{
        dataItems:{
            type:Array,
            required:true
        },
        dataText:{
            type:String,
            required:true
        },
        dataValue:{
            type:String,
            required:true
        }
    },
    methods:{
        hasClikedItem(event, dataItem){
            /* var isOn=false
            if (event.target.classList.contains('btn-primary')){
                event.target.classList.remove('btn-primary')
                event.target.classList.add('btn-secondary')
            }else{
                event.target.classList.remove('btn-secondary')
                event.target.classList.add('btn-primary')
                isOn=true
            } */

            this.$emit(c.EMIT_ACTIONS.HAS_CLICKED_BADGE_ITEM, dataItem/*, isOn*/)
        }
    }
}
</script>